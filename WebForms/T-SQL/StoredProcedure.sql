use VehicleManagement
go

create proc GetVehicles
as
begin
	select * from Vehicle
end
go


create proc DeleteVehicle
	@idVehicle int
as
begin
	delete from Vehicle where IDVehicle = @idVehicle
end
go

create proc AddVehicle	
	@make nvarchar(50),
	@vehicleType nvarchar(50),
	@firstRegistration int,
	@mileage int,
	@idVehicle int output
as
begin
	insert into Vehicle (Make,VehicleType,FirstRegistration,Mileage) values(@make, @vehicleType, @firstRegistration, @mileage)
	set @idVehicle = SCOPE_IDENTITY()
end
go

create proc GetVehicle
	@idVehicle int
as
begin
	select * from Vehicle where IDVehicle = @idVehicle
end
go


create proc UpdateVehicle
	@idVehicle int,
	@make nvarchar(50),
	@vehicleType nvarchar(50),
	@firstRegistration int,
	@mileage int
as
begin
	update Vehicle set Make = @make, VehicleType=@vehicleType, FirstRegistration=@firstRegistration, Mileage=@mileage where IDVehicle = @idVehicle
end
go


CREATE PROC BACKUP_ALL
AS
	select * from Driver
	select * from TravelWarrant
	select * from TWRoute
	select * from Vehicle
GO


create proc AddDriverWithReturn	
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@mobileNumber nvarchar(50),
	@driverLicenseNumber nvarchar(50),
	@idDriver int output
as
begin
	insert into Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber) values(@firstName, @lastName, @mobileNumber, @driverLicenseNumber)
	set @idDriver = SCOPE_IDENTITY()
end
go

create proc AddTravelWarrant	
	@warrantStatus nvarchar(50),
	@driverID int,
	@vehicleID int,
	@idTravelWarrant int output
as
begin
	insert into TravelWarrant (WarrantStatus,DriverID,VehicleID) values(@warrantStatus, @driverID, @vehicleID)
	set @idTravelWarrant = SCOPE_IDENTITY()
end
go

create proc AddTWRoute	
	@duration nvarchar(50),
	@startX int,
	@startY int,
	@stopX int,
	@stopY int,
	@mileage float,
	@averageSpeed int,
	@fuelConsumption int,
	@travelWarrantID int
as
begin
	insert into TWRoute (Duration,StartX,StartY,StopX,StopY,Mileage,AverageSpeed,FuelConsumption,TravelWarrantID) 
	values(@duration, @startX, @startY, @stopX, @stopY, @mileage, @averageSpeed, @fuelConsumption, @travelWarrantID)
end
go

