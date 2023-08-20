USE QL_BANHANG
GO

DECLARE  @idHDcu VARCHAR(10),
		 @idHDmoi VARCHAR(10),
		 @doitac VARCHAR(10),
		 @mst VARCHAR(20),
		 @ndd NVARCHAR(50),
		 @slcn INT,
		 @stk VARCHAR(20),
		 @nganhang VARCHAR(50),
		 @ngaybd DATE,
		 @ngaykt DATE,
		 @tinhtrang NVARCHAR(50)


SET @idHDcu = 'HD0001'
SET @idHDmoi = 'HD0010'
SET @doitac = 'DT0001'
SET @mst = 'MST0001'
SET @ndd = N'Lâm Thương'
SET @slcn = 3
SET @stk = '1234567'
SET @nganhang = N'VP BANK'
SET @ngaybd = '2026-01-01'
SET @ngaykt = '2030-12-31'
SET @tinhtrang = 'DADUYET'

SELECT * FROM HOPDONG
EXEC sp_Them1HopDong @idHDcu,@idHDmoi,@doitac,@mst,@ndd ,@slcn,@stk, @nganhang,@ngaybd ,@ngaykt,@tinhtrang 
