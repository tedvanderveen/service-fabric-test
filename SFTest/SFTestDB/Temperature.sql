﻿CREATE TABLE [dbo].[Temperature]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Value] INT NOT NULL,
	[Date] DateTime NOT NULL,
	[Unit] VARCHAR(5) NOT NULL
)
