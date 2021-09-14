CREATE DATABASE VehicleManagement

USE VehicleManagement


CREATE TABLE Driver(
	IDDriver int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	MobileNumber nvarchar(50),
	DriverLicenseNumber nvarchar(50)
);

CREATE TABLE Vehicle(
	IDVehicle int primary key identity,
	Make nvarchar(50),
	VehicleType nvarchar(50),
	FirstRegistration int,
	Mileage int
);

CREATE TABLE TravelWarrant(
	IDTravelWarrant int primary key identity,
	WarrantStatus nvarchar(20),
	DriverID int foreign key references Driver(IDDriver),
	VehicleID int foreign key references Vehicle(IDVehicle)

);

CREATE TABLE TWRoute(
	IDTWRoute int primary key identity,
	Duration int,
	StartX int,
	StartY int,
	StopX int,
	StopY int,
	Mileage float,
	AverageSpeed int,
	FuelConsumption int,
	TravelWarrantID int foreign key references TravelWarrant(IDTravelWarrant)
);