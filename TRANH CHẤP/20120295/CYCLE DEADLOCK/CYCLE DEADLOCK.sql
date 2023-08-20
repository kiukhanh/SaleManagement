USE QL_BANHANG
GO

CREATE OR ALTER PROC sp_Them1HopDong @idHDcu VARCHAR(10),
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
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT * FROM DOITAC WHERE ID_DOITAC = @doitac)
	BEGIN
		 PRINT N'Mã đối tác không tồn tại'
         ROLLBACK TRAN
	END

	IF EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDmoi)
	BEGIN
         PRINT N'Mã hợp đồng mới đã tồn tại'
         ROLLBACK TRAN
	END

	IF NOT EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDcu)
	BEGIN
         PRINT N'Mã hợp đồng cũ không tồn tại'
         ROLLBACK TRAN
	END

	IF NOT EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDcu AND DOITAC = @doitac)
	BEGIN
         PRINT N'Đối tác không có hợp đồng cũ này'
         ROLLBACK TRAN
	END

	WAITFOR DELAY '0:0:05'

	BEGIN TRY
		INSERT INTO HOPDONG 
		VALUES (@idHDmoi, @mst, @ndd, @slcn, @stk,@nganhang, @ngaybd, @ngaykt, @tinhtrang, @doitac)
	END TRY
	BEGIN CATCH
		PRINT N'Xảy ra lỗi trong lúc thực hiện thêm hợp đồng mới'
		ROLLBACK TRAN
	END CATCH

	BEGIN TRY
		UPDATE HOPDONG
		SET TINHTRANG = N'Hết hạn'
		WHERE ID_HOPDONG = @idHDcu
	END TRY
	BEGIN CATCH
		PRINT N'Xảy ra lỗi trong lúc thực hiện cập nhật tình trạng hợp đồng cũ'
		ROLLBACK TRAN
	END CATCH
COMMIT TRAN
GO


CREATE OR ALTER PROC sp_CapNhatNDD @idHDcu VARCHAR(10),
								   @idHDmoi VARCHAR(10),
								   @doitac VARCHAR(10),
								   @ndd NVARCHAR(50)
AS
BEGIN TRAN

	IF NOT EXISTS(SELECT * FROM DOITAC WHERE ID_DOITAC = @doitac)
	BEGIN
		 PRINT N'Mã đối tác không tồn tại'
         ROLLBACK TRAN
	END

	IF EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDmoi)
	BEGIN
         PRINT N'Mã hợp đồng mới đã tồn tại'
         ROLLBACK TRAN
	END

	IF NOT EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDcu)
	BEGIN
         PRINT N'Mã hợp đồng cũ không tồn tại'
         ROLLBACK TRAN
	END

	IF NOT EXISTS (SELECT * FROM HOPDONG WHERE ID_HOPDONG = @idHDcu AND DOITAC = @doitac)
	BEGIN
         PRINT N'Đối tác không có hợp đồng cũ này'
         ROLLBACK TRAN
	END

	BEGIN TRY
		UPDATE HOPDONG
		SET NG_DAIDIEN = @ndd
		WHERE ID_HOPDONG = @idHDcu
	END TRY
	BEGIN CATCH
		PRINT N'Xảy ra lỗi khi cập nhật người đại diện ở hợp đồng cũ'
		ROLLBACK TRAN
	END CATCH

	BEGIN TRY
		UPDATE HOPDONG
		SET NG_DAIDIEN = @ndd
		WHERE ID_HOPDONG = @idHDmoi
	END TRY
	BEGIN CATCH
		PRINT N'Xảy ra lỗi khi cập nhật người đại diện ở hợp đồng mới'
		ROLLBACK TRAN
	END CATCH
COMMIT TRAN
GO







