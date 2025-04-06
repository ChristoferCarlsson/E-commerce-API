CREATE DATABASE ECommerceDb;
USE ECommerceDb;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordSalt VARBINARY(MAX) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(18, 2),
    Stock INT
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY,
    OrderDate DATETIME,
    TotalAmount DECIMAL(18, 2),
    UserId INT FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE OrderItems (
    Id INT PRIMARY KEY IDENTITY,
    OrderId INT FOREIGN KEY REFERENCES Orders(Id),
    ProductId INT FOREIGN KEY REFERENCES Products(Id),
    Quantity INT
);

-- Users
INSERT INTO Users (Username, Email, PasswordHash, PasswordSalt, Role) VALUES
('johndoe', 'john@example.com', CONVERT(VARBINARY, '0x1234ABCD'), CONVERT(VARBINARY, '0x5678DCBA'), 'Customer'),
('janedoe', 'jane@example.com', CONVERT(VARBINARY, '0xABCD1234'), CONVERT(VARBINARY, '0xDCBA5678'), 'Customer'),
('admin', 'admin@example.com', CONVERT(VARBINARY, '0xDEADBEEF'), CONVERT(VARBINARY, '0xBEEFDEAD'), 'Admin');

-- Products
INSERT INTO Products (Name, Description, Price, Stock) VALUES
('Laptop', 'High performance laptop', 1200.00, 10),
('Smartphone', 'Latest model smartphone', 800.00, 25),
('Headphones', 'Noise-cancelling over-ear headphones', 150.00, 50),
('Mouse', 'Wireless ergonomic mouse', 40.00, 100);

-- Orders
INSERT INTO Orders (OrderDate, TotalAmount, UserId) VALUES
('2025-04-01 10:00:00', 1240.00, 1),
('2025-04-02 12:30:00', 990.00, 2);

-- OrderItems
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES
(1, 1, 1),  -- John ordered 1 Laptop
(1, 4, 1),  -- John ordered 1 Mouse
(2, 2, 1),  -- Jane ordered 1 Smartphone
(2, 3, 2);  -- Jane ordered 2 Headphones
