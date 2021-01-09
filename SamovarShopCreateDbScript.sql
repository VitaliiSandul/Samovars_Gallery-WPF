create database SamovarShop;
go

use SamovarShop;
go

create table Manufacturer
(
	ManufacturerId int primary key identity(1,1),
	ManufacturerName varchar(50) not null
);

create table Samovar
(
	Id int primary key identity(1,1),
	ManufacturerId int foreign key references Manufacturer(ManufacturerId),
	Model varchar(50),
	Volume int not null,
	Price money not null,
	ImagePath varchar(max)
);

insert into Manufacturer(ManufacturerName)
values ('Beem'),
('Teile'),
('Vorontsev'),
('Lomov');

insert into Samovar(ManufacturerId, Model, Volume, Price, ImagePath)
values (1,'2017', 3, 6500,'Images/beem-2017.jpg'),
	(1,'2030', 3, 4400,'Images/beem-2030.jpg'),
	(1,'3006', 6, 11300,'Images/beem-3006.jpg'),
	(1,'3008', 8, 11900,'Images/beem-3008.jpg'),
	(1,'Katharina', 15, 52300,'Images/beem-Katharina.jpg'),
	(1,'Mr. Tea', 4, 5600,'Images/beem-MrTea.jpg'),
	(1,'Odessa', 3, 20900,'Images/beem-Odessa.jpg'),
	(1,'Odette Blanc', 5, 41900,'Images/beem-Odette-Blanc.jpg'),
	(1,'Pyramid A4', 4, 14900,'Images/beem-Pyramid-A4.jpg'),
	(1,'Pyramid A10', 10, 44850,'Images/beem-Pyramid-A4.jpg'),
	(1,'Rebecca', 5, 22400,'Images/beem-Rebecca.jpg'),
	(1,'Romanov', 5, 20900,'Images/beem-Romanov.jpg'),
	(1,'Royal', 15, 58300,'Images/beem-Royal.jpg'),
	(1,'Soraya', 10, 48999,'Images/beem-Soraya.jpg');