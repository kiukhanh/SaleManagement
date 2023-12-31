﻿USE QL_BANHANG
GO

CREATE OR ALTER
PROC USP_DT_SL_CHINHANH
	@soluong int 
AS
SET TRAN ISOLATION LEVEL READ COMMITTED 
BEGIN TRAN
	DECLARE @soluong_HT INT
	SET @soluong_HT = (SELECT SL_CHINHANH FROM UV_TTDOITAC )

	IF (@soluong_HT = @soluong)
	BEGIN
		PRINT N'SỐ LƯỢNG CHI NHÁNH MUỐN ĐỔI TRÙNG VỚI CHI NHÁNH HIỆN TẠI !'
		ROLLBACK TRAN
		RETURN
	END

	WAITFOR DELAY '0:0:05'

	BEGIN TRY
		UPDATE UV_TTDOITAC
		SET SL_CHINHANH = @soluong
	END TRY

	BEGIN CATCH 
		DECLARE @ERROR VARCHAR(2000)
		SELECT @ERROR = N'Lỗi: ' + ERROR_MESSAGE()
		RAISERROR(@ERROR, 16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH

COMMIT TRAN

GO
CREATE OR ALTER PROC USP_DT_NGUOIDAIDIEN
	@nguoidaidien nvarchar(20)
AS
SET TRAN ISOLATION LEVEL READ COMMITTED 
BEGIN TRAN
	DECLARE @nguoidaidienhientai nvarchar(30)
	SET @nguoidaidienhientai = (SELECT NG_DAIDIEN
								FROM UV_TTDOITAC)
	
	IF (@nguoidaidienhientai = @nguoidaidienhientai)
	BEGIN
		PRINT N'TÊN NGƯỜI ĐẠI DIỆN MUỐN ĐỔI TRÙNG VỚI NGƯỜI ĐẠI DIỆN BÂY GIỜ '
		ROLLBACK TRAN
		RETURN
	END

	WAITFOR DELAY '0:0:05'

	BEGIN TRY
		UPDATE UV_TTDOITAC
		SET NG_DAIDIEN = @nguoidaidien
		
	END TRY

	BEGIN CATCH 
		DECLARE @ERROR VARCHAR(2000)
		SELECT @ERROR = N'Lỗi: ' + ERROR_MESSAGE()
		RAISERROR(@ERROR, 16,1)
		ROLLBACK TRAN
		RETURN
	END CATCH

COMMIT TRAN