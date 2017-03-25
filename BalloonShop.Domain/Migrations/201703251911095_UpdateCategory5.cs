namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory5 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Categories", new[] { "DepartmentId" });
            //DropIndex("dbo.Categories", new[] { "Department_DepartmentId" });
            //DropColumn("dbo.Categories", "DepartmentId");
            //RenameColumn(table: "dbo.Categories", name: "Department_DepartmentId", newName: "DepartmentId");
            //AlterColumn("dbo.Categories", "DepartmentId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Categories", "DepartmentId");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Categories", new[] { "DepartmentId" });
            //AlterColumn("dbo.Categories", "DepartmentId", c => c.Int());
            //RenameColumn(table: "dbo.Categories", name: "DepartmentId", newName: "Department_DepartmentId");
            //AddColumn("dbo.Categories", "DepartmentId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Categories", "Department_DepartmentId");
            //CreateIndex("dbo.Categories", "DepartmentId");
        }
    }
}
