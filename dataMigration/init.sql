USE master;
GO

PRINT 'Creating cardbid database...';
IF NOT EXISTS (SELECT * FROM SYS.DATABASES WHERE name = 'cardbid')
BEGIN 
    CREATE DATABASE cardbid;
END

PRINT 'cardbid database created.';
GO

USE cardbid;
PRINT 'Switched to cardbid database...'
GO

-- Create Categorias table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categorias')
BEGIN
    CREATE TABLE Categorias (
        categoria VARCHAR(20) NOT NULL PRIMARY KEY
    );
END;

-- Create GrauDegradacao table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GrauDegradacao')
BEGIN
    CREATE TABLE GrauDegradacao (
        grauDegradacao INT NOT NULL PRIMARY KEY,
        Designacao VARCHAR(20) NOT NULL
    );
END;

-- Create Utilizadores table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Utilizadores')
BEGIN
    CREATE TABLE Utilizadores (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        NIF VARCHAR(10) NOT NULL UNIQUE,
        Email VARCHAR(45) NOT NULL UNIQUE,
        Nome VARCHAR(45) NOT NULL,
        DataDeNascimento DATE NOT NULL,
        Genero CHAR(1) NOT NULL,
        Telefone Varchar(10) NOT NULL,
        Morada VARCHAR(100) NOT NULL
    );
END;

-- Create Conta table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Conta')
BEGIN
    CREATE TABLE Conta (
        NomeUtilizador VARCHAR(20) NOT NULL PRIMARY KEY,
        PalavraPasse Varchar(52) NOT NULL,
        UtilizadorId INT REFERENCES Utilizadores(Id)
    );
END;

-- Create Leiloes table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Leiloes')
BEGIN
    CREATE TABLE Leiloes (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DataLimite DATETIME NOT NULL,
        PrecoInicial DECIMAL(6, 2) NOT NULL,
        BidFee DECIMAL(6, 2) NOT NULL,
        Estado VARCHAR(11) NOT NULL CHECK (Estado IN ('Finalizado', 'Recusado', 'Aceite', 'Pendente')),
        GrauDeDegradacao INT NOT NULL REFERENCES GrauDegradacao(GrauDegradacao),
        Descricao VARCHAR(200) NOT NULL,
        VendedorId INT NOT NULL REFERENCES Utilizadores(Id),
        Categoria VARCHAR(20) NOT NULL REFERENCES Categorias(categoria),
        MaiorLicitacao INT,
        Titulo VARCHAR(50) NOT NULL
    );
END;

-- Create Faturas table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Faturas')
BEGIN
    CREATE TABLE Faturas (
        Fatura VARCHAR(1000) NOT NULL,
        Id INT IDENTITY(1,1) PRIMARY KEY,
        CompradorId INT NOT NULL REFERENCES Utilizadores(Id),
        LeilaoId INT NOT NULL REFERENCES Leiloes(Id)
    );
END;

-- Create Fotos table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fotos')
BEGIN
    CREATE TABLE Fotos (
        Foto VARCHAR(256) NOT NULL,
        LeilaoId INT NOT NULL REFERENCES Leiloes(Id),
        PRIMARY KEY (LeilaoId, Foto)
    );
END;

-- Create Licitacoes table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Licitacoes')
BEGIN
    CREATE TABLE Licitacoes (
        Valor DECIMAL(6, 2) NOT NULL,
        Id INT IDENTITY(1,1) PRIMARY KEY,
        LicitanteId INT NOT NULL REFERENCES Utilizadores(Id),
        LeilaoId INT REFERENCES Leiloes(Id),
        Data DATETIME NOT NULL
    );
END;

-- Add foreign key constraint to Leiloes table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'Leiloes_Licitacoes_Id_fk')
BEGIN
    ALTER TABLE Leiloes
    ADD CONSTRAINT Leiloes_Licitacoes_Id_fk
    FOREIGN KEY (MaiorLicitacao) REFERENCES Licitacoes(Id);
END;

-- Seed data for Categorias
IF NOT EXISTS (SELECT 1 FROM Categorias)
BEGIN
    INSERT INTO Categorias (categoria)
    VALUES 
      ('Pokemon'),
      ('Yu-Gi-Oh!'),
      ('Magic: The Gathering'),
      ('Dragon Ball Super'),
      ('HearthStone'),
      ('One piece'),
      ('Futebol'),
      ('Basquetebol');
END

-- Seed data for GrauDegradacao
IF NOT EXISTS (SELECT 1 FROM GrauDegradacao)
BEGIN
    INSERT INTO GrauDegradacao (grauDegradacao, Designacao)
    VALUES 
      (1, 'Poor'),
      (2, 'Poor-Good'),
      (3, 'Good'),
      (4, 'Very Good'),
      (5, 'Light Played'),
      (6, 'Excellent'),
      (7, 'Excellent-Near Mint'),
      (8, 'Near Mint'),
      (9, 'Mint'),
      (10, 'Gem Mint');
END

IF NOT EXISTS (SELECT 1 FROM Utilizadores)
BEGIN
    INSERT INTO Utilizadores(NIF, Email, Nome, DataDeNascimento, Genero, Telefone, Morada)
    VALUES
        ('123456789', 'jojo@gmail.com', 'Joao Coelho', '2003-12-12', 'M', '987654321', 'Rua do Ferreiro'),
        ('132456789', 'duarte@gmail.com', 'Duarte Araújo', '2003-06-12', 'M', '978654321', 'Rua da rua'),
        ('142356789', 'jose@gmail.com', 'José Rodrigues', '2003-12-11', 'M', '978564321', 'Rua do nada');
END

IF NOT EXISTS (SELECT 1 FROM Conta)
BEGIN
    INSERT INTO Conta (NomeUtilizador, PalavraPasse, UtilizadorId)
    VALUES 
        ('admin', 'admin', null),
        ('jojo','jojo',1),
        ('duarte','duarte',2),
        ('jose','jose',3);
END

IF NOT EXISTS (SELECT 1 FROM Leiloes)
BEGIN
    INSERT INTO Leiloes (DataLimite, PrecoInicial, BidFee, Estado, GrauDeDegradacao, Descricao, VendedorId, Categoria, MaiorLicitacao, Titulo)
    VALUES
        ('2024-02-21 17:21:00.000', 150.00, 7.50, 'Aceite', 10, 'Original card of the dragon ball super deck', 1, 'Dragon Ball Super', null, 'Son Goku'),
        ('2024-02-14 17:22:00.000', 35.00, 1.75, 'Aceite', 7, 'Original card of the one piece deck', 1, 'One piece', null, 'Monkey D. Luffy'),
        ('2024-01-30 22:24:00.000', 230.00, 11.50, 'Aceite', 10, 'Official first edition Lebron James rookie season card', 2, 'Basquetebol', null, 'Lebron James'),
        ('2024-01-30 18:30:00.000', 355.00, 17.75, 'Aceite', 9, 'Almost perfect first edition Charizard VMax', 2, 'Pokemon', null, 'Charizard VMax'),
        ('2024-01-30 19:30:00.000', 450.00, 22.50, 'Aceite', 10, 'First edition Dark Magician card from the original Deck', 3, 'Yu-Gi-Oh!', null, 'Dark Magician'),
        ('2024-01-30 21:00:00.000', 2500.00, 125.00, 'Aceite', 9, 'There is only one copy of this card in the entire world. The first edition limited card from the collaboration between Magic: The Gathering and Lord of the Rings.', 3, 'Magic: The Gathering', null, 'Lord of the Rings - The One Ring');
END

IF NOT EXISTS (SELECT 1 FROM Fotos)
BEGIN
    INSERT INTO Fotos (Foto, LeilaoId)
    VALUES
        ('Images/8755de31-f032-410a-be27-c1e92a8ac854..png', 1),
        ('Images/784a6c57-23f4-44ec-8b9b-6ca49446be16..png', 2),
        ('Images/d294a892-74ea-4f17-bf47-3963717309e9..jpg', 3),
        ('Images/080e285a-a193-4d0b-8580-cc449be45394..png', 4),
        ('Images/5d73bc3d-32c0-43aa-ac62-83cd4c8e66ac..jpg', 5),
        ('Images/b345533a-1607-48de-895a-1c8c96e3f9cd..png', 6);
END