USE CoffeeShop

CREATE Customers(
CustomersId INT IDENTITY(1,1)
Name VARCHAR(50),
Address VARCHAR(50),
Contact VARCHAR(50),
)

CREATE Orders(
Id INT IDENTITY(1,1)
ItemsName VARCHAR(50),
Quantity VARCHAR(50),
TotalPrice int
)


Select * From Customers 
Select * From Orders 