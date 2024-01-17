USE master;
GO

PRINT 'Creating cardbid database...';
CREATE DATABASE cardbid;
PRINT 'cardbid database created.';
GO

USE cardbid;
PRINT 'Switched to cardbid database...'
GO

-- Create Users table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        Email NVARCHAR(256) PRIMARY KEY,
        Password NVARCHAR(MAX),
        Name NVARCHAR(MAX),
        Birthday DATETIME,
        Sex NVARCHAR(MAX),
        Address NVARCHAR(MAX),
        PhoneNumber NVARCHAR(MAX),
        NIF INT
    );
END;

-- Create Auctions table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Auctions')
BEGIN
    CREATE TABLE Auctions (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Description NVARCHAR(MAX),
        ListingPrice DECIMAL(18, 2),
        DegradationLevel INT,
        FinalDate DATETIME,
        Collection NVARCHAR(MAX),
        BidFee DECIMAL(18, 2)
    );
END;
