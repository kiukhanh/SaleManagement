use QUAN_LI_BAN_HANG
go


-- TÌNH HUỐNG: NHÂN VIÊN ĐANG LIỆT KÊ HỢP ĐỒNG CHƯA DUYỆT CỦA ĐỐI TÁC A, TRONG LÚC ĐÓ, ĐỐI TÁC A ĐANG THÊM MỘT HỢP ĐỒNG MỚI LÀ TĂNG TỔNG SỐ LƯỢNG HỢP ĐỒNG
-- => SỐ LƯỢNG HỢP ĐỒNG TĂNG LÊN NHƯNG NHÂN VIÊN VẪN NHẬN SỐ LƯỢNG HỢP ĐỒNG CŨ, KHI IN THỐNG TIN THÌ VẪN RA HỢP ĐỒNG MỚI THÊM CỦA ĐỐI TÁC
-- => KHÔNG THỐNG NHẤT DỮ LIỆU => LỖI: PHANTOM READ

-- T2: USP Đối tác A thêm hợp đồng với trạng thái mặc định là chưa duyệt (user: Đối tác)
create
--alter
proc usp_Them_Hop_Dong
	@iD varchar(10),
	@mST varchar(20),
	@ngDaiDien nvarchar(50),
	@sLChiNhanh int,
	@soTaiKhoan varchar(20),
	@nganHang nvarchar(50),
	@ngBD date,
	@ngKT date,
	@doiTac varchar(10)
as
begin tran
begin try
	if exists (select* from HOPDONG where ID_HOPDONG = @iD)
		begin
			print(N'Mã hợp đồng đã tồn tại')
			rollback tran
			return 1
		end
end try

begin catch
	if (@@ERROR <> 0)
		begin
			print(N'Lỗi thêm hợp đồng mới')
			rollback tran
			return 1
		end
end catch

insert into HOPDONG 
values(@iD,@mST,@ngDaiDien,@sLChiNhanh,@soTaiKhoan,@nganHang,@ngBD,@ngKT,0,@doiTac)--'CHUADUYET'

print N'Đã thêm một hợp đồng mới'

commit tran
go


-- T1: Liet ke HD chua duyet cua mot doi tac A (user: Nhân viên)
create
--alter
proc usp_Liet_Ke_HD_Chua_Duyet
	@iD_DoiTac varchar(10)
as
declare @soLuongHD int, @iD_HD varchar(10)
set @soLuongHD = 0
begin tran
begin try
	if not exists (select* from DOITAC where ID_DOITAC = @iD_DoiTac)
	begin
		print(N'Đối tác không tồn tại')
		rollback tran
		return 1
	end
	if not exists (select* from HOPDONG where DOITAC = @iD_DoiTac)
	begin
		print(N'Đối tác không có hợp đồng hợp lệ')
		rollback tran
		return 1
	end
	if not exists (select* from HOPDONG where DOITAC = @iD_DoiTac and TINHTRANG = 0) --'CHUADUYET'
	begin
		print(N'Đối tác không có hợp đồng chưa được duyệt')
		rollback tran
		return 1
	end
end try
begin catch
	print(N'Lỗi liệt kê hợp đồng chưa duyệt')
	rollback tran
	return 1
end catch

select @soLuongHD = COUNT(*) from HOPDONG where DOITAC = @iD_DoiTac
-- Đợi
waitfor delay '0:0:10'
-- Thêm 1 hợp đồng của đối tác A

declare curs cursor for
select ID_HOPDONG from HOPDONG where DOITAC = @iD_DoiTac
open curs
fetch next from curs into @iD_HD
while @@FETCH_STATUS = 0
begin
	print @iD_HD
	fetch next from curs into @iD_HD
	waitfor delay '0:0:5'
end
close curs
deallocate curs
print N'Tổng số hợp đồng chưa duyệt của đối tác ' + @iD_DoiTac + ': ' + cast (@soLuongHD as nvarchar)

waitfor delay '0:0:5'
commit tran
go

