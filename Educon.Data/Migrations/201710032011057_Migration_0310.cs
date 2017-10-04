namespace Educon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_0310 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsOnline", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "QtdExperience", c => c.Long(nullable: false));
            DropColumn("dbo.User", "NumLevel");
            DropColumn("dbo.User", "NumLevelExperience");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "NumLevelExperience", c => c.Long(nullable: false));
            AddColumn("dbo.User", "NumLevel", c => c.Int(nullable: false));
            DropColumn("dbo.User", "QtdExperience");
            DropColumn("dbo.User", "IsOnline");
        }
    }
}
