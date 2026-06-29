USE SupermarketSystemResitDb;
GO

INSERT INTO Categories (CategoryName)
VALUES
('Dairy'),
('Bakery'),
('Drinks'),
('Fruit and Vegetables');
GO

INSERT INTO Suppliers (SupplierName, ContactNumber)
VALUES
('Fresh Foods Ltd', '07123456789'),
('Daily Dairy Supplies', '07234567890'),
('Bakery Wholesale Ltd', '07345678901');
GO

INSERT INTO Products
(
    ProductName,
    Barcode,
    Price,
    StockQuantity,
    RestockDate,
    AvailabilityStatus,
    CategoryId,
    SupplierId
)
VALUES
('Milk', '111', 1.50, 20, GETDATE(), 'In Stock', 1, 2),
('Bread', '222', 1.20, 5, GETDATE(), 'Low Stock', 2, 3),
('Orange Juice', '333', 2.00, 8, GETDATE(), 'In Stock', 3, 1),
('Apples', '444', 0.60, 4, GETDATE(), 'Low Stock', 4, 1);
GO

INSERT INTO StockRecords
(
    ProductId,
    QuantityAvailable,
    LastUpdated,
    RestockDate
)
VALUES
(1, 20, GETDATE(), GETDATE()),
(2, 5, GETDATE(), GETDATE()),
(3, 8, GETDATE(), GETDATE()),
(4, 4, GETDATE(), GETDATE());
GO

INSERT INTO Sales
(
    ProductId,
    QuantitySold,
    SaleDate
)
VALUES
(1, 2, GETDATE()),
(2, 1, GETDATE());
GO

INSERT INTO SaleItems
(
    SaleId,
    ProductId,
    QuantitySold,
    UnitPrice
)
VALUES
(1, 1, 2, 1.50),
(2, 2, 1, 1.20);
GO