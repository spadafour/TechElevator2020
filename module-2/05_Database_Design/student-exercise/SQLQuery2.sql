USE master;
GO

DROP database if exists ProjectOrganizer;
CREATE database ProjectOrganizer;
Go

Use ProjectOrganizer
Go

begin transaction;

create table department
(
deptNumber int identity(1,1),
deptName varChar(64) not null,

constraint pk_deptNumber primary key (deptNumber)
);



create table jobTitle
(
jobTitleId int identity(1,1),
name varchar(64),

constraint pk_jobId primary key (jobTitleId)
);



create table employee
(
employeeId int identity(1,1),
jobTitleId int not null,
lastName varchar(64) not null,
firstName varchar(64) not null,
gender varchar(9) not null,
dateOfBirth date not null,
dateOfHire date not null,
deptNumber int null,

constraint pk_employee primary key (employeeId),
constraint fk_jobTitleId foreign key (jobTitleId) references jobTitle(jobTitleId),
constraint fk_deptNumber foreign key (deptNumber) references department(deptNumber),
CONSTRAINT gender_check CHECK ((gender = 'male') OR (gender = 'female') OR (gender = 'nonbinary'))
);



create table project
(
projNumber int identity(1,1),
projName varchar(64),

constraint pk_projNumber primary key (projNumber)
);



create table project_employee
(
projNumber int not null,
employeeId int not null,

constraint pk_project_employee primary key (projNumber, employeeId),
constraint fk_projNumber foreign key (projNumber) references project(projNumber),
constraint fk_employeeId foreign key (employeeId) references employee(employeeId)
);

commit