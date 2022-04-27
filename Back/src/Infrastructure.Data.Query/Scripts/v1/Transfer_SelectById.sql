USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[Transfer_SelectById]    Script Date: 4/27/2022 5:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Transfer_SelectById]
@Id INT
AS

BEGIN
	SELECT	 [Id]
			,[IdBankAccount]
			,[ValueTransfer]
			,[TypeTransfer]
	FROM    [dbo].[Transfer]
	WHERE	@Id IS NULL OR [Id] = @Id 
END


