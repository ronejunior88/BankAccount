USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_UpdateBalanceByTransfer]    Script Date: 4/27/2022 5:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[BankAccount_UpdateBalanceByTransfer]
@Id INT,
@Balance DECIMAL
AS

BEGIN
	UPDATE	[dbo].[BankAccount]
	SET
			[Balance] = @Balance
	WHERE	@Id IS NULL OR [Id] = @Id 
END
