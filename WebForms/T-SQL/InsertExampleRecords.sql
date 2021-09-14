USE VehicleManagement

GO
CREATE PROC insertExampleRecords
AS
INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber)
VALUES('Duje','Maleš','+385987483746','67943783'),
	('Šime','Biliæ','+385917495443','54348311'),
	('Ana','Galiæ','+385956801333','73494582')
GO
