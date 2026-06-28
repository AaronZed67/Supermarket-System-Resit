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

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Barcode NVARCHAR(50) NOT NULL UNIQUE,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,
    RestockDate DATETIME2 NOT NULL,
    AvailabilityStatus NVARCHAR(50) NOT NULL,
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,

    CONSTRAINT CK_Products_Price CHECK (Price > 0),
    CONSTRAINT CK_Products_StockQuantity CHECK (StockQuantity >= 0),

    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),

    CONSTRAINT FK_Products_Suppliers
        FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);
GO