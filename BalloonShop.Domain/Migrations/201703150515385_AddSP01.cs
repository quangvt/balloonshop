namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSP01 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CategoryViewInfo",
            //    c => new
            //        {
            //            CategoryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            DateAdded = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.CategoryViewInfo");
        }
    }
}
