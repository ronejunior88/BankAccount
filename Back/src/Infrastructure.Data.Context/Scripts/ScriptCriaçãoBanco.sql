USE [RevenueBankAccounts]
GO
/****** Object:  CreateData  Script Date: 4/27/2022 2:51:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

GO

IF object_id('Bank') is null
BEGIN
     CREATE TABLE Bank( 
		Id INT IDENTITY(1,1) NOT NULL,
		Name varchar(50) NOT NULL,
		CONSTRAINT PK_Bank PRIMARY KEY  (Id)
	 )
END 

GO

IF object_id('Person') is null
BEGIN
     CREATE TABLE Person( 
		Id INT IDENTITY(1,1) NOT NULL,
		Name varchar(50) NOT NULL,
		LastName varchar(100) NOT NULL,
		Cpf varchar(20),
		CNPJ Varchar(20),
		Telephone varchar(30),
		Adress varchar(150),
		CONSTRAINT PK_Person PRIMARY KEY (Id)
	 )
END

GO

IF object_id('Client') is null
BEGIN
     CREATE TABLE Client(
	    Id INT IDENTITY(1,1) NOT NULL,
		IdPerson INT NOT NULL,
		CONSTRAINT PK_Client PRIMARY KEY (Id),
		CONSTRAINT FK_Client_Person FOREIGN KEY (IdPerson)
        REFERENCES Person (Id) ON DELETE CASCADE ON UPDATE CASCADE
)
END

GO

IF object_id('BankAccount') is null
BEGIN
     CREATE TABLE BankAccount( 
		Id INT IDENTITY(1,1) NOT NULL,
		IdBank INT NOT NULL,
		IdClient INT NOT NULL,
		Balance DECIMAL NOT NULL,
		TypeAccount VARCHAR(50) NOT NULL,
		CONSTRAINT PK_BankAccount PRIMARY KEY (Id),
		CONSTRAINT FK_BankAccount_Bank FOREIGN KEY (IdBank)
        REFERENCES Bank (Id) ON DELETE CASCADE ON UPDATE CASCADE,
		CONSTRAINT FK_BankAccount_Client FOREIGN KEY (IdClient)
        REFERENCES Client (Id) ON DELETE CASCADE ON UPDATE CASCADE
)
END

GO

IF object_id('Transfer') is null
BEGIN
     CREATE TABLE Transfer( 
		Id INT IDENTITY(1,1) NOT NULL,
		IdBankAccount INT NOT NULL,
		ValueTransfer DECIMAL NOT NULL,
		TypeTransfer VARCHAR(50) NOT NULL,
		Date DATE NOT NULL,
		CONSTRAINT PK_Transfer PRIMARY KEY (Id),
		CONSTRAINT FK_Transfer_BankAccount FOREIGN KEY (IdBankAccount)
        REFERENCES BankAccount (Id) ON DELETE CASCADE ON UPDATE CASCADE
)
END

