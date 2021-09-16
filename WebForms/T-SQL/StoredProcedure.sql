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