CREATE TABLE [dbo].[Cars] (
    [CarId]        INT           NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
    [ModelYear]    INT           NULL,
    [DailyPrice]   DECIMAL (18)  NULL,
    [Descriptions] VARCHAR (200) NULL,
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]), 
    CONSTRAINT [PK_Cars] PRIMARY KEY ([CarId]) 
);

