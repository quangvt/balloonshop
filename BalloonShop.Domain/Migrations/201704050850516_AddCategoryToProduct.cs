namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Products", "Category");
            AlterStoredProcedure(
                "dbo.Product_Insert",
                p => new
                    {
                        Name = p.String(),
                        Description = p.String(),
                        Price = p.Decimal(precision: 15, scale: 3),
                        CategoryId = p.Int(),
                        ImageData = p.Binary(),
                        ImageMimeType = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Products]([Name], [Description], [Price], [CategoryId], [ImageData], [ImageMimeType])
                      VALUES (@Name, @Description, @Price, @CategoryId, @ImageData, @ImageMimeType)
                      
                      DECLARE @ProductId int
                      SELECT @ProductId = [ProductId]
                      FROM [dbo].[Products]
                      WHERE @@ROWCOUNT > 0 AND [ProductId] = scope_identity()
                      
                      SELECT t0.[ProductId]
                      FROM [dbo].[Products] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ProductId] = @ProductId"
            );
            
            AlterStoredProcedure(
                "dbo.Product_Update",
                p => new
                    {
                        ProductId = p.Int(),
                        Name = p.String(),
                        Description = p.String(),
                        Price = p.Decimal(precision: 15, scale: 3),
                        CategoryId = p.Int(),
                        ImageData = p.Binary(),
                        ImageMimeType = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Products]
                      SET [Name] = @Name, [Description] = @Description, [Price] = @Price, [CategoryId] = @CategoryId, [ImageData] = @ImageData, [ImageMimeType] = @ImageMimeType
                      WHERE ([ProductId] = @ProductId)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category", c => c.String(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropColumn("dbo.Products", "CategoryId");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
