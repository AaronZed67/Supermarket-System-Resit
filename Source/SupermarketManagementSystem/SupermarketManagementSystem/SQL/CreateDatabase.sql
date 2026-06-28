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

CREATE TABLE StockRecords
(
    StockId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    QuantityAvailable INT NOT NULL,
    LastUpdated DATETIME2 NOT NULL,
    RestockDate DATETIME2 NOT NULL,

    CONSTRAINT CK_StockRecords_QuantityAvailable CHECK (QuantityAvailable >= 0),

    CONSTRAINT FK_StockRecords_Products
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

CREATE TABLE Sales
(
    SaleId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    QuantitySold INT NOT NULL,
    SaleDate DATETIME2 NOT NULL,

    CONSTRAINT CK_Sales_QuantitySold CHECK (QuantitySold > 0),

    CONSTRAINT FK_Sales_Products
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

CREATE TABLE SaleItems
(
    SaleItemId INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    QuantitySold INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,

    CONSTRAINT CK_SaleItems_QuantitySold CHECK (QuantitySold > 0),
    CONSTRAINT CK_SaleItems_UnitPrice CHECK (UnitPrice > 0),

    CONSTRAINT FK_SaleItems_Sales
        FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),

    CONSTRAINT FK_SaleItems_Products
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO