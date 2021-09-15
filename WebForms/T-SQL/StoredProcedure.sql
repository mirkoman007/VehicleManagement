use VehicleManagement
go

create proc GetVehicles
as
begin
	select * from Vehicle
end
go