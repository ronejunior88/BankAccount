USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Transfer]    Script Date: 5/4/2022 1:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Insert_Transfer]
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
SELECT SCOPE_IDENTITY()
END
--==================================================================================================================
PRINT N'Script 1.1.0 finalizado!';
