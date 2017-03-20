namespace BalloonShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeptView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentViewInfo",
                c => new
                    {
                        DeptId = c.Int(identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);            
       }
        
        public override void Down()
        {
            DropTable("dbo.DepartmentViewInfo");
        }
    }
}
