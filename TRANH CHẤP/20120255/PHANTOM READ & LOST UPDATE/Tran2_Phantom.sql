use QL_DH_GH
go

--PHANTOM READ
--T2
exec usp_Them_Hop_Dong '1234518','12122002',N'Phạm Mai Thiên Bảo', 50, '630001452','ACB','2023-01-01','2025-01-01','001'
go

