
CREATE DATABASE [FullStackTestDB] 
GO
CREATE TABLE [dbo].[ClientInformation](
	[ClientInformationID] [uniqueidentifier] NOT NULL,
	[Title] [varchar](20) NULL,
	[Name] [varchar](max) NULL,
	[MiddleName] [varchar](max) NULL,
	[Surname] [varchar](max) NULL,
	[Gender] [varchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[IDNumber] [varchar](max) NULL,
	[Cell] [varchar](max) NULL,
	[TelHome] [varchar](max) NULL,
	[TelWork] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[StreetNameAndNumber] [varchar](max) NULL,
	[Suburb] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[PostalCode] [varchar](max) NULL,
 CONSTRAINT [PK_ClientInformation] PRIMARY KEY CLUSTERED 
(
	[ClientInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddClientInformation]    Script Date: 2021/04/18 15:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddClientInformation] @Title varchar(max) = NULL
, @Name varchar(max) = NULL
, @MiddleName varchar(max) = NULL
, @Surname varchar(max) = NULL
, @Gender varchar(max) = NULL
, @DateOfBirth date = NULL
, @IDNumber varchar(max) = NULL
, @Cell varchar(max) = NULL
, @TelHome varchar(max) = NULL
, @TelWork varchar(max) = NULL
, @Email varchar(max) = NULL
, @StreetNameAndNumber varchar(max) = NULL
, @Suburb varchar(max) = NULL
, @City varchar(max) = NULL
, @PostalCode varchar(max) = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    DECLARE @ClientInformationID uniqueidentifier

    SET @ClientInformationID = NEWID()

    INSERT INTO [dbo].[ClientInformation] ([ClientInformationID]
    , [Title]
    , [Name]
    , [MiddleName]
    , [Surname]
    , [Gender]
    , [DateOfBirth]
    , [IDNumber]
    , [Cell]
    , [TelHome]
    , [TelWork]
    , [Email]
    , [StreetNameAndNumber]
    , [Suburb]
    , [City]
    , [PostalCode])
      VALUES (@ClientInformationID, @Title, @Name, @MiddleName, @Surname, @Gender, @DateOfBirth, @IDNumber, @Cell, @TelHome, @TelWork, @Email, @StreetNameAndNumber, @Suburb, @City, @PostalCode)
    SELECT
      @ClientInformationID AS ClientInformationID
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllClientInformation]    Script Date: 2021/04/18 15:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllClientInformation]
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      [ClientInformationID],
      [Title],
      [Name],
      [MiddleName],
      [Surname],
      [Gender],
      [DateOfBirth],
      [IDNumber],
      [Cell],
      [TelHome],
      [TelWork],
      [Email],
      [StreetNameAndNumber],
      [Suburb],
      [City],
      [PostalCode]
    FROM [ClientInformation]
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClientInformation]    Script Date: 2021/04/18 15:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetClientInformation]
@ClientInformationID uniqueidentifier = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      [ClientInformationID],
      [Title],
      [Name],
      [MiddleName],
      [Surname],
      [Gender],
      [DateOfBirth],
      [IDNumber],
      [Cell],
      [TelHome],
      [TelWork],
      [Email],
      [StreetNameAndNumber],
      [Suburb],
      [City],
      [PostalCode]
    FROM [ClientInformation]

	WHERE ClientInformationID = @ClientInformationID
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateClientInformation]    Script Date: 2021/04/18 15:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateClientInformation] @ClientInformationID uniqueidentifier = NULL
, @Title varchar(max) = NULL
, @Name varchar(max) = NULL
, @MiddleName varchar(max) = NULL
, @Surname varchar(max) = NULL
, @Gender varchar(max) = NULL
, @DateOfBirth date = NULL
, @IDNumber varchar(max) = NULL
, @Cell varchar(max) = NULL
, @TelHome varchar(max) = NULL
, @TelWork varchar(max) = NULL
, @Email varchar(max) = NULL
, @StreetNameAndNumber varchar(max) = NULL
, @Suburb varchar(max) = NULL
, @City varchar(max) = NULL
, @PostalCode varchar(max) = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    UPDATE [ClientInformation]
    SET [Title] = @Title,
        [Name] = @Name,
        [MiddleName] = @MiddleName,
        [Surname] = @Surname,
        [Gender] = @Gender,
        [DateOfBirth] = @DateOfBirth,
        [IDNumber] = @IDNumber,
        [Cell] = @Cell,
        [TelHome] = @TelHome,
        [TelWork] = @TelWork,
        [Email] = @Email,
        [StreetNameAndNumber] = @StreetNameAndNumber,
        [Suburb] = @Suburb,
        [City] = @City,
        [PostalCode] = @PostalCode
    WHERE [ClientInformationID] = @ClientInformationID
  COMMIT
GO
USE [master]
GO
ALTER DATABASE [FullStackTestDB] SET  READ_WRITE 
GO
