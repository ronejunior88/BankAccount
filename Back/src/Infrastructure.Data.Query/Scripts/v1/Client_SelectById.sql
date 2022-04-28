USE [RevenueBankAccounts]
GO
/****** Object:  StoredProcedure [dbo].[Client_SelectById]    Script Date: 4/27/2022 5:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Client_SelectById]
@Id INT
AS

BEGIN
	SELECT	 Client.Id
			,Client.IdPerson
			,Person.Name
			,Person.LastName
			,Person.Cpf
			,Person.CNPJ
			,Person.Telephone
			,Person.Adress
	FROM    [dbo].[Client]
	INNER JOIN [dbo].[Person] ON Client.IdPerson = Person.Id
	WHERE	@Id IS NULL OR Client.Id = @Id 
END
