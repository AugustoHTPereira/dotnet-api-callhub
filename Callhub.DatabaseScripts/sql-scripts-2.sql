use Master;
drop database Callhub;
create database Callhub;
use Callhub;

create table Attachs (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  Type varchar(15) not null,
  Size bigint not null default 0,
  FullPath text,
  RelativePath text not null,
  TableName varchar(100) not null,
  TableRegisterId uniqueidentifier not null,
  CreatedAt datetime default getdate()
);

create table Categories (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  Description text null,
  Priority int not null default 1,
  CreatedAt datetime not null default getdate()
);

create table Companies (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  AttachId uniqueidentifier null foreign key references Attachs(Id),
  CreatedAt datetime not null default getdate()
);

create table Departments (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  CompanyId uniqueidentifier foreign key references Companies(Id),
  CreatedAt datetime not null default getdate()
);

create table Roles (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  CreatedAt datetime not null default getdate()
);

create table Sectors (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(255) not null,
  Priority int not null default 1,
  CreatedAt datetime not null default getdate()
);

create table Users (
  Id uniqueidentifier not null primary key default newid(),
  Name varchar(150) not null,
  Surname varchar(150) null,
  Email varchar(255) not null unique,
  Priority int not null default 1,
  Password varchar(max) not null,
  DepartmentId uniqueidentifier null foreign key references Departments(Id),
  RoleId uniqueidentifier null foreign key references Roles(Id),
  CreatedAt datetime not null default getdate()
);

create table Calls (
  Id uniqueidentifier not null primary key default newid(),
  Title varchar(255) not null,
  Description text,
  Priority int not null,
  ServiceLevel int null,
  Note int null,
  NoteObservation varchar(255),
  UserId uniqueidentifier not null foreign key references Users(Id),
  SectorDestinId uniqueidentifier not null foreign key references Sectors(Id),
  CategoryId uniqueidentifier null foreign key references Categories(Id),
  Situation varchar(100) not null default 'created',
  CreatedAt datetime default getdate()
);

create table CallTimeline (
  Id uniqueidentifier not null primary key default newid(),
  CallId uniqueidentifier not null foreign key references Calls(Id),
  Situation varchar(100) not null,
  Observation text null,
  CreatedAt datetime default getdate()
);


-- Init database

insert into Roles (
  Name
) values ('intern'), ('admin'), ('support')


-- Dev seeds