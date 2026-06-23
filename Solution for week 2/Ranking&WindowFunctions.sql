CREATE DATABASE RetailStore;
USE RetailStore;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1,'Laptop A','Electronics',80000),
(2,'Laptop B','Electronics',75000),
(3,'Laptop C','Electronics',75000),
(4,'Mobile A','Electronics',60000),
(5,'TV A','Electronics',90000),
(6,'Sofa A','Furniture',50000),
(7,'Table A','Furniture',30000),
(8,'Chair A','Furniture',30000),
(9,'Bed A','Furniture',70000),
(10,'Cupboard A','Furniture',60000);

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS Row_Num
FROM Products;

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS Row_Num
    FROM Products
) AS RankedProducts
WHERE Row_Num <= 3;