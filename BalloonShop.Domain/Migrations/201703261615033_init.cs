namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 500),
                        DateAdded = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            //CreateTable(
            //    "dbo.CategoryViewInfoes",
            //    c => new
            //        {
            //            CategoryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            DateAdded = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CategoryId);
            
            //CreateTable(
            //    "dbo.Departments",
            //    c => new
            //        {
            //            DepartmentId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 30),
            //            Description = c.String(maxLength: 500),
            //        })
            //    .PrimaryKey(t => t.DepartmentId);
            
            //CreateTable(
            //    "dbo.DepartmentViewInfo",
            //    c => new
            //        {
            //            DeptId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.DeptId);
            
            //CreateTable(
            //    "dbo.Members",
            //    c => new
            //        {
            //            MemberId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false, maxLength: 20),
            //            LastName = c.String(nullable: false, maxLength: 20),
            //            MemberState = c.Int(nullable: false),
            //            Street = c.String(nullable: false, maxLength: 50),
            //            Address_City = c.String(),
            //            Address_State = c.String(),
            //            Address_Zip = c.String(),
            //        })
            //    .PrimaryKey(t => t.MemberId);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Description = c.String(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 15, scale: 3),
            //            Category = c.String(nullable: false),
            //            ImageData = c.Binary(),
            //            ImageMimeType = c.String(),
            //        })
            //    .PrimaryKey(t => t.ProductId);
            
            //CreateStoredProcedure(
            //    "dbo.Product_Insert",
            //    p => new
            //        {
            //            Name = p.String(),
            //            Description = p.String(),
            //            Price = p.Decimal(precision: 15, scale: 3),
            //            Category = p.String(),
            //            ImageData = p.Binary(),
            //            ImageMimeType = p.String(),
            //        },
            //    body:
            //        @"INSERT [dbo].[Products]([Name], [Description], [Price], [Category], [ImageData], [ImageMimeType])
            //          VALUES (@Name, @Description, @Price, @Category, @ImageData, @ImageMimeType)
                      
            //          DECLARE @ProductId int
            //          SELECT @ProductId = [ProductId]
            //          FROM [dbo].[Products]
            //          WHERE @@ROWCOUNT > 0 AND [ProductId] = scope_identity()
                      
            //          SELECT t0.[ProductId]
            //          FROM [dbo].[Products] AS t0
            //          WHERE @@ROWCOUNT > 0 AND t0.[ProductId] = @ProductId"
            //);
            
            //CreateStoredProcedure(
            //    "dbo.Product_Update",
            //    p => new
            //        {
            //            ProductId = p.Int(),
            //            Name = p.String(),
            //            Description = p.String(),
            //            Price = p.Decimal(precision: 15, scale: 3),
            //            Category = p.String(),
            //            ImageData = p.Binary(),
            //            ImageMimeType = p.String(),
            //        },
            //    body:
            //        @"UPDATE [dbo].[Products]
            //          SET [Name] = @Name, [Description] = @Description, [Price] = @Price, [Category] = @Category, [ImageData] = @ImageData, [ImageMimeType] = @ImageMimeType
            //          WHERE ([ProductId] = @ProductId)"
            //);
            
            //CreateStoredProcedure(
            //    "dbo.Product_Delete",
            //    p => new
            //        {
            //            ProductId = p.Int(),
            //        },
            //    body:
            //        @"DELETE [dbo].[Products]
            //          WHERE ([ProductId] = @ProductId)"
            //);
            
        }
        
        public override void Down()
        {
            //DropStoredProcedure("dbo.Product_Delete");
            //DropStoredProcedure("dbo.Product_Update");
            //DropStoredProcedure("dbo.Product_Insert");
            //DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            //DropIndex("dbo.Categories", new[] { "DepartmentId" });
            //DropTable("dbo.Products");
            //DropTable("dbo.Members");
            //DropTable("dbo.DepartmentViewInfo");
            //DropTable("dbo.Departments");
            //DropTable("dbo.CategoryViewInfoes");
            //DropTable("dbo.Categories");
        }
    }
}
