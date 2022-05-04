USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_InsertPerson]    Script Date: 4/27/2022 4:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Person]
@Name Varchar(50),		
@LastName varchar(100),
@Cpf varchar(20),
@CNPJ Varchar(20),
@Telephone varchar(30),
@Adress varchar(150)

AS

BEGIN

INSERT INTO [dbo].[Person]
            ([Name],
			 [LastName],
			 [Cpf],
			 [CNPJ],
			 [Telephone],
			 [Adress])
Values(@Name,
       @LastName,
	   @Cpf,
	   @CNPJ,
	   @Telephone,
	   @Adress)

DECLARE @INSERTED_IDENTITY BIGINT = (SELECT SCOPE_IDENTITY())

INSERT INTO [dbo].[Client]
            ([IdPerson])
Values(@INSERTED_IDENTITY)

END
--==================================================================================================================
PRINT N'Script 1.1.0 finalizado!';
