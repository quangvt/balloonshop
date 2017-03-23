namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UseStoreProcedure : DbMigration
    {
        // Only for SQL Server
        //   Other database must comment it
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Product_Insert",
                p => new
                {
                    Name = p.String(),
                    Description = p.String(),
                    Price = p.Decimal(precision: 15, scale: 3),
                    Category = p.String(),
                    ImageData = p.Binary(),
                    ImageMimeType = p.String(),
                },
                body:
                    @"INSERT [dbo].[Products]([Name], [Description], [Price], [Category], [ImageData], [ImageMimeType])
                      VALUES (@Name, @Description, @Price, @Category, @ImageData, @ImageMimeType)
                      
                      DECLARE @ProductId int
                      SELECT @ProductId = [ProductId]
                      FROM [dbo].[Products]
                      WHERE @@ROWCOUNT > 0 AND [ProductId] = scope_identity()
                      
                      SELECT t0.[ProductId]
                      FROM [dbo].[Products] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ProductId] = @ProductId"
            );

            CreateStoredProcedure(
                "dbo.Product_Update",
                p => new
                {
                    ProductId = p.Int(),
                    Name = p.String(),
                    Description = p.String(),
                    Price = p.Decimal(precision: 15, scale: 3),
                    Category = p.String(),
                    ImageData = p.Binary(),
                    ImageMimeType = p.String(),
                },
                body:
                    @"UPDATE [dbo].[Products]
                      SET [Name] = @Name, [Description] = @Description, [Price] = @Price, [Category] = @Category, [ImageData] = @ImageData, [ImageMimeType] = @ImageMimeType
                      WHERE ([ProductId] = @ProductId)"
            );

            CreateStoredProcedure(
                "dbo.Product_Delete",
                p => new
                {
                    ProductId = p.Int(),
                },
                body:
                    @"DELETE [dbo].[Products]
                      WHERE ([ProductId] = @ProductId)"
            );

        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Product_Delete");
            DropStoredProcedure("dbo.Product_Update");
            DropStoredProcedure("dbo.Product_Insert");
        }
    }
}
