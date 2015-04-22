namespace HalloweenController_v0._0._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buttons", "Response", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buttons", "Response", c => c.String());
        }
    }
}
