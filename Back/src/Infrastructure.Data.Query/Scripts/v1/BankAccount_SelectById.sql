USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_SelectById]    Script Date: 4/27/2022 5:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[BankAccount_SelectById]
@Id INT
AS

BEGIN
	SELECT	 [Id]
			,[IdBank]
			,[IdClient]
			,[Balance]
			,[TypeAccount]
	FROM    [dbo].[BankAccount]
	WHERE	@Id IS NULL OR [Id] = @Id 
END



