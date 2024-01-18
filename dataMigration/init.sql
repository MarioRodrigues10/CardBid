USE master;
GO

PRINT 'Creating cardbid database...';
CREATE DATABASE cardbid;
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
        NIF INT NOT NULL UNIQUE,
        Email VARCHAR(45) NOT NULL UNIQUE,
        Nome VARCHAR(45) NOT NULL,
        DataDeNascimento DATE NOT NULL,
        Genero VARCHAR(15) NOT NULL,
        Telefone INT NOT NULL,
        Morada VARCHAR(100) NOT NULL
    );
END;

-- Create Conta table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Conta')
BEGIN
    CREATE TABLE Conta (
        NomeUtilizador VARCHAR(20) NOT NULL PRIMARY KEY,
        PalavraPasse Varchar(52) NOT NULL,
        Utilizador_Id INT REFERENCES Utilizadores(Id)
    );
END;

-- Create Leiloes table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Leiloes')
BEGIN
    CREATE TABLE Leiloes (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DataLimite DATETIME NOT NULL,
        PrecoInicial DECIMAL(6, 2) NOT NULL,
        Estado VARCHAR(11) NOT NULL CHECK (Estado IN ('Finalizado', 'Recusado', 'Aceite', 'Pendente')),
        GrauDeDegradacao INT NOT NULL REFERENCES GrauDegradacao(GrauDegradacao),
        Descricao VARCHAR(200) NOT NULL,
        Vendedor_Id INT NOT NULL REFERENCES Utilizadores(Id),
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
        Comprador_Id INT NOT NULL REFERENCES Utilizadores(Id),
        Leilao_Id INT NOT NULL REFERENCES Leiloes(Id)
    );
END;

-- Create Fotos table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fotos')
BEGIN
    CREATE TABLE Fotos (
        Foto VARCHAR(256) NOT NULL,
        Leilao_Id INT NOT NULL REFERENCES Leiloes(Id),
        PRIMARY KEY (Leilao_Id, Foto)
    );
END;

-- Create Licitacoes table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Licitacoes')
BEGIN
    CREATE TABLE Licitacoes (
        Valor DECIMAL(6, 2) NOT NULL,
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Licitante_Id INT NOT NULL REFERENCES Utilizadores(Id),
        Leilao_Id INT REFERENCES Leiloes(Id),
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

