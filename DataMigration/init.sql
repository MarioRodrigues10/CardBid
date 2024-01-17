-- init.sql

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

-- Create Cards table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cards')
BEGIN
    CREATE TABLE Cards (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Description NVARCHAR(MAX),
        ListingPrice DECIMAL(18, 2),
        DegradationLevel INT,
        FinalDate DATETIME,
        Collection NVARCHAR(MAX),
        BidFee DECIMAL(18, 2)
    );
END;
