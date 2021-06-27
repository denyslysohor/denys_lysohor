CREATE DATABASE [ShopInfo];
GO

use ShopInfo;
GO

CREATE TABLE Category 
(
Id INT PRIMARY KEY,
Name NVARCHAR(50) NOT NULL
);

GO

CREATE TABLE Discount 
(
Id INT PRIMARY KEY,
Value FLOAT NOT NULL
);
GO

CREATE TABLE Product
(
Id INT PRIMARY KEY,
CategoryId INT FOREIGN KEY REFERENCES Category(id),
Name NVARCHAR(50) NOT NULL,
Price FLOAT NOT NULL
);
GO

CREATE TABLE Users
(
Id INT PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) UNIQUE NOT NULL,
Age INT CHECK(Age>18) NOT NULL
);
GO

CREATE TABLE Cart 
(
Id INT PRIMARY KEY,
UserId INT UNIQUE FOREIGN KEY REFERENCES Users(Id),
DiscountId iNT FOREIGN KEY REFERENCES Discount(Id)
);
GO

CREATE TABLE CartItem
(
CartId INT FOREIGN KEY REFERENCES Cart(Id),
ProductId INT FOREIGN KEY REFERENCES Product(Id),
Count INT NOT NULL,
 PRIMARY KEY(CartId,ProductId)
);
GO

CREATE TABLE UserAddress
(
Id INT PRIMARY KEY,
UserId INT FOREIGN KEY REFERENCES Users(Id),
CountryCode INT NOT NULL,
State NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
Address NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL
);
GO


INSERT INTO Category VALUES
(1,'Eat'),
(2,'Clothing'),
(3,'Technics'),
(4,'Household chemicals');
GO

INSERT INTO Product VALUES
(1,1,'Apple',15),
(2,1,'Bread',10),
(3,3,'iPhone 11',30000),
(4,2,'Sneakers',1500),
(5,4,'Soap',5);
GO

INSERT INTO Discount VALUES 
(1,0.05),
(2,0.10),
(3,0.15),
(4,0.20),
(5,0.25);
GO

INSERT INTO Users VALUES 
(1,'Oleg','Klimenko','klimenko@gmail.com',21),
(2,'Ivan','Petrov','petrov@gmail.com',25),
(3,'Petr','Gut','gut@gmail.com',38),
(4,'Alexander','Linnik','linnik@gmail.com',19),
(5,'Max','Korshenko','korshenko@gmail.com',37);
GO

INSERT INTO UserAddress VALUES
(1,1,11,'Kyiv','Kyiv','Peremoga 11','0508291227'),
(2,2,12,'Kyiv','Kyiv','Svobody 22','0664382995'),
(3,3,13,'Kharkiv','Kharkiv','Naukova 14','0674932312'),
(4,4,14,'Kharkiv','Kharkiv','Naukova 22','0993212353'),
(5,5,15,'Kharkiv','Kharkiv','Nezaleshnosti 18','0502748229');
GO

INSERT INTO Cart VALUES 
(1,1,1),
(2,2,2),
(3,3,3),
(4,4,4),
(5,5,5);
GO

INSERT INTO CartItem VALUES 
(1,1,3),
(2,2,2),
(3,3,3),
(4,4,6),
(5,5,1);
GO

CREATE PROCEDURE GetUserInfoById
    @id INT
AS
SELECT * FROM Users INNER JOIN UserAddress ON Users.Id = UserAddress.UserId WHERE Users.Id = @id
GO

CREATE PROCEDURE GetUserInfoByEmail
    @email NVARCHAR(50)
AS
SELECT * FROM Users INNER JOIN UserAddress ON Users.Id = UserAddress.UserId WHERE Users.Email = @email
GO


CREATE PROCEDURE GetCartUserInfoById
    @id INT
AS
SELECT * FROM Users 
INNER JOIN Cart ON Users.Id = Cart.UserId 
INNER JOIN Discount ON Discount.Id = Cart.DiscountId 
INNER JOIN CartItem ON CartItem.CartId = Cart.Id
INNER JOIN Product ON Product.Id = CartItem.ProductId 
WHERE Users.Id = @id
GO

CREATE PROCEDURE GetCartUserInfoByEmail
     @email NVARCHAR(50)
AS
SELECT * FROM Users 
INNER JOIN Cart ON Users.Id = Cart.UserId 
INNER JOIN Discount ON Discount.Id = Cart.DiscountId 
INNER JOIN CartItem ON CartItem.CartId = Cart.Id
INNER JOIN Product ON Product.Id = CartItem.ProductId 
WHERE Users.Email = @email
GO