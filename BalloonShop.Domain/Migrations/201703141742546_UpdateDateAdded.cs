namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateAdded : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Categories", "DateAdded", c => c.DateTime(nullable: false, 
            //    defaultValueSql:"GetDate()"));
            CreateIndex(
                "Departments",
                new[] { "Name" },
                name: "IX_DEPARTMENTS_NAMES");
        }

        public override void Down()
        {
            //DropColumn("dbo.Categories", "DateAdded");
            DropIndex("Departments", "IX_DEPARTMENTS_NAMES");
        }
    }
}
