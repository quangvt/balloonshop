namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplexProperty : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.CategoryViewInfo", newName: "CategoryViewInfoes");
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Street = c.String(nullable: false, maxLength: 50),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
            //RenameTable(name: "dbo.CategoryViewInfoes", newName: "CategoryViewInfo");
        }
    }
}
