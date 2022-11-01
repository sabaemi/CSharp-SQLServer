/*  Create DataBase */
USE master ;  
GO  
CREATE DATABASE myDatabase  
ON ( 
	NAME = myDatabase_dat,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\myDatabase.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 
	)  
LOG ON ( 
	NAME = myDatabase_log,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\myDatabase.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB 
	) ;  
GO
/* Use DataBase */
use myDatabase;
/*  Create Role Table */
CREATE TABLE Role (
    ID INT NOT NULL PRIMARY KEY --Relvar Constraint
	IDENTITY, --Attribute Constraint
    RoleName VARCHAR (50) --Type Constraint 
	NOT NULL --Attribute Constraint
);
/* Create User Table */
CREATE TABLE Userr(
    ID INT NOT NULL PRIMARY KEY --Relvar Constraint
	IDENTITY, --Attribute Constraint
    Name VARCHAR (50) --Type Constraint 
	NOT NULL, --Attribute Constraint
    Family VARCHAR (50) --Type Constraint
	NOT NULL, --Attribute Constraint
    Age INT NOT NULL DEFAULT 18 CHECK (Age BETWEEN 0 and 120), --Attribute Constraint
    RoleID INT, --Attribute Constraint
	CHECK ((Age<=30 AND RoleID<=2) OR Age>30), --Entity Constraint
    FOREIGN KEY (RoleID) REFERENCES Role (ID) --Relvar Constraint
    ON DELETE CASCADE --Database Constraint
	ON UPDATE CASCADE --Database Constraint
);
/*  Create Trigger for User Table*/
CREATE TRIGGER LimitTableUserr --Relvar Constraint
on Userr
after insert
as
    declare @tableCount int
    select @tableCount = Count(*)
    from Userr
    if @tableCount > 20 --Relvar Constraint
    begin
        rollback
    end
go