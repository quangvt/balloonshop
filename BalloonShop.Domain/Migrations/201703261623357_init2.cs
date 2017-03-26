namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Category_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 30),
                        Description = p.String(maxLength: 500),
                        DateAdded = p.DateTime(),
                        DepartmentId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Categories]([Name], [Description], [DateAdded], [DepartmentId])
                      VALUES (@Name, @Description, @DateAdded, @DepartmentId)
                      
                      DECLARE @CategoryId int
                      SELECT @CategoryId = [CategoryId]
                      FROM [dbo].[Categories]
                      WHERE @@ROWCOUNT > 0 AND [CategoryId] = scope_identity()
                      
                      SELECT t0.[CategoryId]
                      FROM [dbo].[Categories] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CategoryId] = @CategoryId"
            );
            
            CreateStoredProcedure(
                "dbo.Category_Update",
                p => new
                    {
                        CategoryId = p.Int(),
                        Name = p.String(maxLength: 30),
                        Description = p.String(maxLength: 500),
                        DateAdded = p.DateTime(),
                        DepartmentId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Categories]
                      SET [Name] = @Name, [Description] = @Description, [DateAdded] = @DateAdded, [DepartmentId] = @DepartmentId
                      WHERE ([CategoryId] = @CategoryId)"
            );
            
            CreateStoredProcedure(
                "dbo.Category_Delete",
                p => new
                    {
                        CategoryId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Categories]
                      WHERE ([CategoryId] = @CategoryId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Category_Delete");
            DropStoredProcedure("dbo.Category_Update");
            DropStoredProcedure("dbo.Category_Insert");
        }
    }
}
