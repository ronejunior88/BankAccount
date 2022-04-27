USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_BankAccount]    Script Date: 4/27/2022 4:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_BankAccount]		
@IdClient INT,
@Balance Decimal,
@TypeAccount Varchar(50)
AS

BEGIN

INSERT INTO [dbo].[BankAccount]
            ([IdBank],
			 [IdClient],
			 [Balance],
			 [TypeAccount]
			 )
Values(1,
       @IdClient,
	   @Balance,
	   @TypeAccount
	   )
END
--==================================================================================================================
PRINT N'Script 1.1.0 finalizado!';
