USE [DbProduct]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 27-08-2023 12:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[SKU] [nvarchar](50) NULL,
	[HSNNumber] [nvarchar](50) NULL,
	[BrandName] [nvarchar](200) NULL,
	[UOM] [nvarchar](100) NULL,
	[Weight] [nvarchar](100) NULL,
	[CGST] [decimal](18, 2) NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[BuyingPrice] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK__Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ProductCurd]    Script Date: 27-08-2023 12:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[ProductCurd]
(  
   @Id int = NULL,  
   @Name NVARCHAR(200) = NULL,  
   @HSNNumber NVARCHAR(50) = NULL,  
   @BrandName NVARCHAR(200) = NULL,  
   @UOM NVARCHAR(100) = NULL, 
   @Weight NVARCHAR(100) = NULL,
   @CGST decimal(18,2) = NULL,
   @SGST decimal(18,2) = NULL,
   @IGST decimal(18,2) = NULL,
   @MRP decimal(18,2) = NULL,
   @BuyingPrice decimal(18,2) = NULL,
   @SellingPrice decimal(18,2) = NULL,
   @Quantity int = NULL,
   @Image NVARCHAR(max) = NULL,
   @ActionType nvarchar(20) = ''  
)  
AS  
BEGIN  
	IF @ActionType = 'Insert'  
	BEGIN  
	    DECLARE @guid uniqueidentifier = NEWID();

		INSERT INTO [dbo].[Product]
           ([Name],[SKU],[HSNNumber],[BrandName],[UOM],[Weight],[CGST],[SGST],[IGST],[MRP],[BuyingPrice],[SellingPrice],[Quantity]
           ,[Image],[IsActive],[IsDelete],[DateAdded],[DateModified])
     VALUES
           (@Name,@guid,@HSNNumber,@BrandName,@UOM,@Weight,@CGST,@SGST,@IGST,@MRP,@BuyingPrice,@SellingPrice,@Quantity,@Image,1,0,GETDATE(),GETDATE()) 
	END  
	IF @ActionType = 'Select'  
	BEGIN  
		Select * from Product where IsActive=1 and IsDelete=0  
	END  
	IF @ActionType = 'Update'  
	BEGIN  
		UPDATE Product SET  
			Name = @Name, 
			HSNNumber = @HSNNumber, 
			BrandName = @BrandName,  
			UOM = @UOM, 
			CGST = @CGST,		
			SGST = @SGST,
			IGST = @IGST,
			MRP = @MRP,
			BuyingPrice = @BuyingPrice,
			SellingPrice = @SellingPrice,
			Quantity = @Quantity,
			Image = @Image
		WHERE Id = @Id  
	END  
	IF @ActionType = 'Delete'  
	BEGIN  
		Update Product set IsActive=0, IsDelete=1 where Id = @Id
	END  
	IF @ActionType = 'SelectById'  
	BEGIN  
		Select * from Product where Id=@Id and IsActive=1 and IsDelete=0
	END 
END
GO
