namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreProcedureMySQL : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Categories", "DateAdded", c => c.DateTime(nullable: false, precision: 0));
            //AlterColumn("dbo.CategoryViewInfoes", "Name", c => c.String(unicode: false));
            //AlterColumn("dbo.CategoryViewInfoes", "DateAdded", c => c.DateTime(nullable: false, precision: 0));
            //AlterColumn("dbo.DepartmentViewInfo", "Name", c => c.String(unicode: false));
            //AlterColumn("dbo.Members", "Address_City", c => c.String(unicode: false));
            //AlterColumn("dbo.Members", "Address_State", c => c.String(unicode: false));
            //AlterColumn("dbo.Members", "Address_Zip", c => c.String(unicode: false));
            //AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, unicode: false));
            //AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, unicode: false));
            //AlterColumn("dbo.Products", "Category", c => c.String(nullable: false, unicode: false));
            //AlterColumn("dbo.Products", "ImageMimeType", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Products", "ImageMimeType", c => c.String());
            //AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
            //AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            //AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            //AlterColumn("dbo.Members", "Address_Zip", c => c.String());
            //AlterColumn("dbo.Members", "Address_State", c => c.String());
            //AlterColumn("dbo.Members", "Address_City", c => c.String());
            //AlterColumn("dbo.DepartmentViewInfo", "Name", c => c.String());
            //AlterColumn("dbo.CategoryViewInfoes", "DateAdded", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.CategoryViewInfoes", "Name", c => c.String());
            //AlterColumn("dbo.Categories", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
