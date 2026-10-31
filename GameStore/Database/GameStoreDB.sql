-- ============================================================
-- GameStoreDB - Database Setup Script
-- Run this script in SQL Server Management Studio (SSMS)
-- ============================================================

USE master;
GO

-- Drop database if exists (for clean re-run during dev)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'GameStoreDB')
BEGIN
    ALTER DATABASE GameStoreDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GameStoreDB;
END
GO

CREATE DATABASE GameStoreDB;
GO

USE GameStoreDB;
GO

-- ============================================================
-- Table: Products
-- ============================================================
CREATE TABLE Products (
    ProductID   NVARCHAR(20)    NOT NULL,   -- Business key, e.g. "P001", "P002"
    ProductName NVARCHAR(200)   NOT NULL,
    Category    NVARCHAR(50)    NOT NULL,   -- 'Console', 'PhysicalCopy', 'PCHardware'
    Price       DECIMAL(18, 2)  NOT NULL,
    ShortDesc   NVARCHAR(500)   NULL,
    InStock     BIT             NOT NULL DEFAULT 1,
    CreatedAt   DATETIME2       NOT NULL DEFAULT GETDATE(),
    UpdatedAt   DATETIME2       NULL,

    -- PRIMARY KEY auto-increment internal ID
    Id          INT             IDENTITY(1,1) PRIMARY KEY,

    -- UNIQUE constraint on business ProductID
    CONSTRAINT UQ_Products_ProductID UNIQUE (ProductID),

    -- CHECK: price must be positive
    CONSTRAINT CHK_Products_Price CHECK (Price > 0),

    -- CHECK: category must be one of valid values
    CONSTRAINT CHK_Products_Category CHECK (Category IN ('Console', 'PhysicalCopy', 'PCHardware'))
);
GO

-- ============================================================
-- Seed Data (sample records for testing)
-- ============================================================
INSERT INTO Products (ProductID, ProductName, Category, Price, ShortDesc, InStock)
VALUES
    ('P001', 'PlayStation 5',           'Console',      14990000, 'Sony PS5 Standard Edition',        1),
    ('P002', 'Xbox Series X',           'Console',      13990000, 'Microsoft Xbox Series X 1TB',      1),
    ('P003', 'The Last of Us Part II',  'PhysicalCopy',  990000,  'PS4/PS5 Physical Disc',            1),
    ('P004', 'RTX 4070 Super',          'PCHardware',   17500000, 'NVIDIA GeForce RTX 4070 Super 12GB', 0),
    ('P005', 'God of War Ragnarok',     'PhysicalCopy',  1290000, 'PS4/PS5 Physical Edition',         1);
GO

-- ============================================================
-- Verify
-- ============================================================
SELECT * FROM Products;
GO
