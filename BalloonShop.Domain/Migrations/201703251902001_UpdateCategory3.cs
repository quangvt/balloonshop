namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory3 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Department_DepartmentId");
        }
    }
}
