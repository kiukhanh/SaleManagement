use QL_DH_GH
go



-- TÌNH HUỐNG: HAI NHÂN VIÊN CÙNG DUYỆT MỘT HỢP ĐỒNG: 
--		+ NV1 CHO RẰNG HỢP ĐỒNG PHẢI BỊ XÓA BỎ (bắt đầu cập nhật trước)
--		+ NV2 CHO RẰNG HỢP ĐỒNG SẼ ĐƯỢC DUYỆT QUA VÀ CHẤP NHẬN (Cập nhật ngay sau đó)
-- => Lỗi: LOST UPDATE

--T1': THIẾT ĐẶT TRẠNG THÁI (XOABO) CHO HỢP ĐỒNG B (USER: NHÂN VIÊN)
create
--alter
proc usp_Dat_Trang_Thai_XoaBo_HD
	@iD_HD varchar(10)
as
declare @tinhTrangHD nvarchar(100)
select @tinhTrangHD = TINHTRANG from HOPDONG where ID_HOPDONG = @iD_HD

begin tran
begin try
	if not exists (select * from HOPDONG where ID_HOPDONG = @iD_HD)
	begin
		print(N'Không tồn tại hợp đồng cần xóa')
		rollback tran
		return 1
	end
	--
	if exists (select * from HOPDONG where ID_HOPDONG = @iD_HD and TINHTRANG = 'XOABO')
	begin
		print(N'Hợp đồng đã ở trạng thái này từ trước')
		rollback tran
		return 1
	end
	if exists (select * from HOPDONG where ID_HOPDONG = @iD_HD and datediff(day,NGAYKETTHUCDK,getdate()) < 0 and TINHTRANG = 1)
	begin
		print(N'Hợp đồng đang còn hiệu lực, không thể thay đổi trạng thái')
		rollback tran
		return 1
	end
end try
begin catch
	print(N'Lỗi trạng thái HĐ')
	rollback tran
	return 1
end catch

--Đợi lần 1
waitfor delay '0:0:10'
update HOPDONG
set TINHTRANG = 'XOABO'
where ID_HOPDONG = @iD_HD

print N'Đã cập nhật trạng thái cho hợp đồng ' + @iD_HD + N' từ ' + @tinhTrangHD + ' sang XOABO'
waitfor delay '0:0:8'
commit tran
GO


-- T2': USP update 1 hợp đồng B có trạng thái chưa duyệt sang đã duyệt (user: Nhân viên)
create
--alter
proc usp_Update_1_Hop_Dong_Chua_Duyet_Sang_Da_Duyet
	@iD_HD varchar(10)

as
declare @tinhTrangHD nvarchar (100)
select @tinhTrangHD = TINHTRANG from HOPDONG where ID_HOPDONG = @iD_HD

begin tran
begin try
	if not exists (select * from HOPDONG where ID_HOPDONG = @iD_HD)
	begin
		print(N'Không tồn tại hợp đồng cần xóa')
		rollback tran
		return 1
	end
	if not exists (select * from HOPDONG where TINHTRANG = 0 and ID_HOPDONG = @iD_HD)--'CHUADUYET'
	begin
		print(N'Hợp đồng này đã được duyệt hoặc bị xóa bỏ')
		rollback tran
		return 1
	end
end try

begin catch
	print(N'Lỗi xóa hợp đồng cần xóa')
	rollback tran
	return 1
end catch
-- Đợi
waitfor delay '0:0:10'
if @tinhTrangHD = 0 --'CHUADUYET'
begin
	update HOPDONG
	set TINHTRANG = 1
	where ID_HOPDONG = @iD_HD
	print N'Đã cập nhật hợp đồng ' + @iD_HD + N' từ trạng thái CHUADUYET sang DADUYET'
end
waitfor delay '0:0:10'
commit tran


go
