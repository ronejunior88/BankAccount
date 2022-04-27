USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_Transfer]    Script Date: 4/27/2022 4:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Transfer]
@IdBankAccount INT,		
@ValueTransfer Decimal,
@TypeTransfer Varchar(50)

AS

BEGIN

INSERT INTO [dbo].[Transfer]
            ([IdBankAccount],
			 [ValueTransfer],
			 [TypeTransfer]
			 )
Values(@IdBankAccount,
       @ValueTransfer,
	   @TypeTransfer
	   )
END
--==================================================================================================================
PRINT N'Script 1.1.0 finalizado!';
