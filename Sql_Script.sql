CREATE DATABASE propertydb;
GO
USE propertydb;
GO
CREATE TABLE Property (
     Id int,
    [Address] varchar(1000),
    YearBuilt int,
    ListPrice decimal(9,2),
    MonthlyRent decimal(9,2),
	GrossYield decimal(9,2)
);
