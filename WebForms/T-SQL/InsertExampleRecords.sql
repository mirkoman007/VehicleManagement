USE VehicleManagement

GO
CREATE PROC insertExampleRecords
AS
INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber)
VALUES('Duje','Male�','+385987483746','67943783'),
	('�ime','Bili�','+385917495443','54348311'),
	('Ana','Gali�','+385956801333','73494582')
GO
