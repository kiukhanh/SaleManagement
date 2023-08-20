USE QL_BANHANG
GO 

DECLARE @idHDcu VARCHAR(10),@idHDmoi VARCHAR(10),@ndd NVARCHAR(50)

SET @idHDcu = 'HD0001'
SET @idHDmoi = 'HD0011'
SET @ndd = N'Quang Huy1'

EXEC sp_CapNhatNDD  @idHDcu,@idHDmoi,@ndd

