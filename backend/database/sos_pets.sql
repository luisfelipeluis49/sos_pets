USE MASTER
GO

DROP DATABASE IF EXISTS SosPetsDb
GO

CREATE DATABASE SosPetsDb
GO

USE SosPetsDb
GO

CREATE TABLE [Tutor] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL,
  [Bithdate] DATE NOT NULL,
  [CPF] CHAR(11),
  [CRMV] CHAR(6),
  [ZipCode] CHAR(8),
  --[City] ,
  --[FederativeUnit],
  --[Address],
  [PhoneNumber] CHAR(11),
  [Email] VARCHAR(256)
); 
GO

CREATE TABLE [TypeOfProfessional] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Type] CHAR(11) NOT NULL
);
GO

CREATE TABLE [Professional] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL,
  [Type] INT NOT NULL,
  [CRMV] CHAR(6) NOT NULL,
  CONSTRAINT [Type_FK]
    FOREIGN KEY ([Type])
    REFERENCES [TypeOfProfessional]([Id])
);
GO

CREATE TABLE [Establishment] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL,
  [CRMV] CHAR(6) NOT NULL,
  [ZipCode] CHAR(8) NOT NULL,
  [Number] VARCHAR(10) NOT NULL,
  [AddressComplement] VARCHAR(200),
  [PhoneNumber] VARCHAR(11)
);
GO

CREATE TABLE [EstablishmentProfessionals] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Establishment] INT NOT NULL,
  [Professional] INT NOT NULL,
  CONSTRAINT [Establishment_FK_0]
    FOREIGN KEY ([Establishment])
    REFERENCES [Establishment]([Id]),
  CONSTRAINT [Professional_FK_0]
    FOREIGN KEY ([Professional])
    REFERENCES [Professional]([Id])
);
GO

CREATE TABLE [ActiveIngredient] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Medicine] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR (100) NOT NULL,
  [ActiveIngredient] INT NOT NULL,
  CONSTRAINT [ActiveIngredient_FK]
    FOREIGN KEY ([ActiveIngredient])
    REFERENCES [ActiveIngredient]([Id])
);
GO

CREATE TABLE [Surgery] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE [Vaccine] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE [ParasiteControl] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Prevention] DATE NOT NULL,
  [PreventionDetails] VARCHAR(300),
  [CheckUp] DATE NOT NULL,
  [Bath] DATE NOT NULL,
  [OnDay] BIT DEFAULT 0
);
GO

CREATE TABLE [ReproductionStage] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Stage] VARCHAR (20) NOT NULL
);
GO

CREATE TABLE [Anamnesis] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Castrated] BIT DEFAULT 0,
  [ReproductionStage] INT NOT NULL,
  [Height] DECIMAL NOT NULL,
  [Weight] DECIMAL NOT NULL,
  [Diet] VARCHAR(300),
  [ParasiteControl] INT NOT NULL,
  CONSTRAINT [ReproductionStage_FK]
    FOREIGN KEY ([ReproductionStage])
    REFERENCES [ReproductionStage]([Id]),
  CONSTRAINT [ParasiteControl_FK]
    FOREIGN KEY ([ParasiteControl])
    REFERENCES [ParasiteControl]([Id])
);
GO

CREATE TABLE [AnamnesisMedicines] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Anamnesis] INT NOT NULL,
  [Medicine] INT NOT NULL,
  [Dose] INT NOT NULL,
  [Interval] TIME NOT NULL,
  [Details] VARCHAR(300),
  CONSTRAINT [Anamnesis_FK_0]
    FOREIGN KEY ([Anamnesis])
    REFERENCES [Anamnesis]([Id]),
  CONSTRAINT [Medicine_FK_0]
    FOREIGN KEY ([Medicine])
    REFERENCES [Medicine]([Id])
);
GO

CREATE TABLE [AnamnesisSurgeries] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Anamnesis] INT NOT NULL,
  [Surgery] INT NOT NULL,
  [Details] VARCHAR(300),
  [Date] DATE DEFAULT GETDATE(),
  CONSTRAINT [Anamnesis_FK_1]
    FOREIGN KEY ([Anamnesis])
    REFERENCES [Anamnesis]([Id]),
  CONSTRAINT [Surgery_FK_0]
    FOREIGN KEY ([Surgery])
    REFERENCES [Surgery]([Id])
);
GO

CREATE TABLE [AnamnesisVaccines] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Anamnesis] INT NOT NULL,
  [Vaccine] INT NOT NULL,
  [Date] DATE DEFAULT GETDATE(),
  [Expiration] DATE DEFAULT CONVERT(varchar(10), (DATEADD(YYYY, +1, GETDATE())), 120),
  CONSTRAINT [Anamnesis_FK_2]
    FOREIGN KEY ([Anamnesis])
    REFERENCES [Anamnesis]([Id]),
  CONSTRAINT [Vaccine_FK_0]
    FOREIGN KEY ([Vaccine])
    REFERENCES [Vaccine]([Id])
);
GO


CREATE TABLE [Specie] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Specie] VARCHAR (20) NOT NULL
);
GO

CREATE TABLE [Breed] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Breed] VARCHAR (20) NOT NULL
);
GO

CREATE TABLE [Pet] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR (50) NOT NULL,
  [Tutor] INT NOT NULL,
  [Bithdate] DATE NOT NULL,
  [Specie] INT NOT NULL,
  [Breed] INT NOT NULL,
  [Gender] char(1),
  [Anamnesis] INT NOT NULL,
  CONSTRAINT [Tutor_FK_0]
    FOREIGN KEY ([Tutor])
    REFERENCES [Tutor]([Id]),
  CONSTRAINT [Specie_FK]
    FOREIGN KEY ([Specie])
    REFERENCES [Specie]([Id]),
  CONSTRAINT [Breed_FK]
    FOREIGN KEY ([Breed])
    REFERENCES [Breed]([Id]),
  CONSTRAINT [Anamnesis_FK_3]
    FOREIGN KEY ([Anamnesis])
    REFERENCES [Anamnesis]([Id])
);
GO

CREATE TABLE [Agenda] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Tutor] INT NOT NULL,
  CONSTRAINT [Tutor_FK_1]
    FOREIGN KEY ([Tutor])
    REFERENCES [Tutor]([Id])
);
GO

CREATE TABLE [Appointment] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Date] DATETIME2 NOT NULL,
  [Agenda] INT NOT NULL,
  [Pet] INT NOT NULL,
  [Establishment] INT NOT NULL,
  [Professional] INT NOT NULL,
  CONSTRAINT [Agenda_FK]
    FOREIGN KEY ([Agenda])
    REFERENCES [Agenda]([Id]),
  CONSTRAINT [Pet_FK]
    FOREIGN KEY ([Pet])
    REFERENCES [Pet]([Id]),
  CONSTRAINT [Establishment_FK_1]
    FOREIGN KEY ([Establishment])
    REFERENCES [Establishment]([Id]),
  CONSTRAINT [Professional_FK_1]
    FOREIGN KEY ([Professional])
    REFERENCES [Professional]([Id])
);
GO

CREATE TABLE [AppointmentMedicines] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Appointment] INT NOT NULL,
  [Medicine] INT NOT NULL,
  [Dose] INT NOT NULL,
  [Interval] TIME NOT NULL,
  [Details] VARCHAR(300),
  CONSTRAINT [Appointment_FK_0]
    FOREIGN KEY ([Appointment])
    REFERENCES [Appointment]([Id]),
  CONSTRAINT [Medicine_FK_1]
    FOREIGN KEY ([Medicine])
    REFERENCES [Medicine]([Id])
);
GO

CREATE TABLE [AppointmentSurgeries] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Appointment] INT NOT NULL,
  [Surgery] INT NOT NULL,
  [Details] VARCHAR(300),
  CONSTRAINT [Appointment_FK_1]
    FOREIGN KEY ([Appointment])
    REFERENCES [Appointment]([Id]),
  CONSTRAINT [Surgery_FK_1]
    FOREIGN KEY ([Surgery])
    REFERENCES [Surgery]([Id])
);
GO

CREATE TABLE [AppointmentVaccines] (
  [Id] INT PRIMARY KEY IDENTITY,
  [Appointment] INT NOT NULL,
  [Vaccine] INT NOT NULL,
  [Expiration] DATE DEFAULT CONVERT(varchar(10), (DATEADD(YYYY, +1, GETDATE())), 120),
  CONSTRAINT [Appointment_FK_2]
    FOREIGN KEY ([Appointment])
    REFERENCES [Appointment]([Id]),
  CONSTRAINT [Vaccine_FK_1]
    FOREIGN KEY ([Vaccine])
    REFERENCES [Vaccine]([Id])
);
GO


--INSERTS TODO


/*----------------------------------Roubei do Paulo------------------------------------*/
CREATE FUNCTION Funcencrypt(@encryptade VARCHAR(30)) 
returns VARCHAR(max) 
  BEGIN
  DECLARE @encryptaded VARBINARY(100)

  SET @encryptaded = CONVERT(VARBINARY(100), @encryptade, 0)
  SET @encryptaded = Hashbytes('md4', @encryptaded)

  RETURN CONVERT(VARCHAR(max), @encryptaded, 1)
END 
GO

