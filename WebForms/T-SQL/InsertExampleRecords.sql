USE VehicleManagement

GO
CREATE PROC insertExampleRecords
AS
INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber)
VALUES('Duje','Male�','+385987483746','67943783'),
	('�ime','Bili�','+385917495443','54348311'),
	('Ana','Gali�','+385956801333','73494582')
INSERT INTO Vehicle (Make,VehicleType,FirstRegistration,Mileage)
VALUES('BMW','Saloon','2017','87000'),
	('Ford','Estate Car','2020','32000'),
	('GMC','SUV','2012','185000')
GO


DROP PROCEDURE insertExampleRecords