USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[TransferClient_SelectById]    Script Date: 4/27/2022 5:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[TransferClient_SelectById]
@Id INT
AS

BEGIN
	SELECT	 Client.Id AS Client_Id
			,Client.IdPerson AS Person_Id
			,BankAccount.Id AS Account
			,BankAccount.Balance
			,BankAccount.TypeAccount
			,Bank.Name
			,Transfer.TypeTransfer
			,Transfer.ValueTransfer
	FROM    [dbo].[Client]
	INNER JOIN [dbo].[BankAccount] ON BankAccount.IdClient = Client.Id
	INNER JOIN [dbo].[Bank] ON Bank.Id = BankAccount.IdBank
	INNER JOIN [dbo].[Transfer] ON Transfer.IdBankAccount = BankAccount.Id
	WHERE	@Id IS NULL OR Client.Id = @Id 
END
