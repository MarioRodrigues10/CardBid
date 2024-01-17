create table Categorias
(
    categoria varchar(20) not null
        constraint Categorias_pk
            primary key
)
go

create table GrauDegradacao
(
    GrauDegradacao int         not null
        constraint GrauDegradacao_pk
            primary key,
    Designação     varchar(20) not null
)
go

create table Utilizadores
(
    Id               int identity
        constraint Id
            primary key,
    NIF              int          not null
        constraint NIF
            unique,
    Email            varchar(45)  not null
        constraint Email
            unique,
    Nome             varchar(45)  not null,
    DatadeNascimento date         not null,
    Género           char         not null,
    Telefone         int          not null,
    Morada           varchar(100) not null
)
go

create table Conta
(
    NomeUtilizador varchar(20)   not null
        constraint Conta_pk
            primary key,
    PalavraPasse   varbinary(52) not null,
    Utilizador_Id  int
        constraint Conta_Utilizadores_Id_fk
            references Utilizadores
)
go

create table Leiloes
(
    Id               int identity
        constraint Id_Leilao
            primary key,
    DataLimite       datetime      not null,
    PrecoInicial     decimal(6, 2) not null,
    Estado           varchar(11)   not null
        constraint check_name
            check ([Estado] = 'Finalizado' OR [Estado] = 'Recusado' OR [Estado] = 'Aceite' OR [Estado] = 'Pendente'),
    GraudeDegradacao int           not null
        constraint Leiloes_GrauDegradacao_GrauDegradacao_fk
            references GrauDegradacao,
    Descricao        varchar(200)  not null,
    Vendedor_Id      int           not null
        constraint Leiloes_Utilizadores_Id_fk
            references Utilizadores,
    Categoria        varchar(20)   not null
        constraint Leiloes_Categorias_categoria_fk
            references Categorias,
    Maior_licitacao  int,
    Titulo           varchar(50)   not null
)
go

create table Faturas
(
    Fatura       varchar(1000) not null,
    Id           int identity
        constraint Faturas_pk
            primary key,
    Comprador_id int           not null
        constraint Faturas_Utilizadores_Id_fk
            references Utilizadores,
    Leilao_Id    int           not null
        constraint Faturas_Leiloes_Id_fk
            references Leiloes
)
go

create table Fotos
(
    Foto      varchar(256) not null,
    Leilao_Id int          not null
        constraint Fotos_Leiloes__fk
            references Leiloes,
    constraint Fotos_pk
        primary key (Leilao_Id, Foto)
)
go

create table Licitacoes
(
    Valor        decimal(6, 2) not null,
    Id           int identity
        constraint Licitacoes_pk
            primary key,
    Licitante_Id int           not null
        constraint Licitacoes_Utilizadores_Id_fk
            references Utilizadores,
    Leilao_Id    int
        constraint Licitacoes_Leiloes_Id_fk
            references Leiloes,
    Data         datetime      not null
)
go

alter table Leiloes
    add constraint Leiloes_Licitacoes_Id_fk
        foreign key (Maior_licitacao) references Licitacoes
go

