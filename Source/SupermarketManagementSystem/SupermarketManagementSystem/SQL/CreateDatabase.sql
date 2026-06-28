CREATE DATABASE SupermarketSystemResitDb;
GO

USE SupermarketSystemResitDb;
GO

CREATE TABLE Categories
(
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Suppliers
(
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL,
    ContactNumber NVARCHAR(50) NOT NULL
);
GO