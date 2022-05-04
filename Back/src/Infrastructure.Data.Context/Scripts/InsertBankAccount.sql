USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[Insert_BankAccount]    Script Date: 5/2/2022 5:23:07 PM ******/
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
SELECT SCOPE_IDENTITY()
END
--==================================================================================================================
PRINT N'Script 1.1.0 finalizado!';
