USE VehicleManagement

GO
CREATE PROC insertExampleRecords
AS
INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber)
VALUES('Duje','Maleš','+385987483746','67943783'),
	('Šime','Biliæ','+385917495443','54348311'),
	('Ana','Galiæ','+385956801333','73494582')
INSERT INTO Vehicle (Make,VehicleType,FirstRegistration,Mileage)
VALUES('BMW','Saloon','2017','87000'),
	('Ford','Estate Car','2020','32000'),
	('GMC','SUV','2012','185000')
INSERT INTO TravelWarrant (WarrantStatus,DriverID,VehicleID)
VALUES('open',11,5),
	('closed',14,7)
INSERT INTO TWRoute(Duration,StartX,StartY,StopX,StopY,Mileage,AverageSpeed,FuelConsumption,TravelWarrantID)
VALUES(120,1,1,5,5,10,200.0,20,1),
	(120,1,1,5,5,10,200,20,2)
GO


DROP PROCEDURE insertExampleRecords