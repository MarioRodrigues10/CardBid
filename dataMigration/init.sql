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
      ('Pok�mon'),
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