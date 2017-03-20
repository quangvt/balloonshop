namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "MemberState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "MemberState");
        }
    }
}
