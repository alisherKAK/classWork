create table Countrys
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null
)
go;
create table Citys
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null,
Population int not null,
CountryId uniqueidentifier references Countrys(Id) not null
)
go;
create table Streets
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null,
CityId uniqueidentifier references Citys(Id) not null
)
go;