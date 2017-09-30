namespace Educon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novas_Modificacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserQuestion",
                c => new
                    {
                        NidQuestion = c.Int(nullable: false),
                        NidUser = c.Int(nullable: false),
                        QtdAnswers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NidQuestion, t.NidUser })
                .ForeignKey("dbo.User", t => t.NidUser)
                .ForeignKey("dbo.Question", t => t.NidQuestion)
                .Index(t => t.NidQuestion)
                .Index(t => t.NidUser);
            
            AddColumn("dbo.User", "NumEnergyAnswers", c => c.Int(nullable: false));
            AddColumn("dbo.User", "NumWaterAnswers", c => c.Int(nullable: false));
            AddColumn("dbo.User", "NumEnvironmentAnswers", c => c.Int(nullable: false));
            AddColumn("dbo.User", "NumRecyclingAnswers", c => c.Int(nullable: false));
            AddColumn("dbo.User", "NumLevel", c => c.Int(nullable: false));
            AddColumn("dbo.User", "NumLevelExperience", c => c.Long(nullable: false));
            AddColumn("dbo.User", "User_NidUser", c => c.Int());
            CreateIndex("dbo.User", "User_NidUser");
            AddForeignKey("dbo.User", "User_NidUser", "dbo.User", "NidUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserQuestion", "NidQuestion", "dbo.Question");
            DropForeignKey("dbo.UserQuestion", "NidUser", "dbo.User");
            DropForeignKey("dbo.User", "User_NidUser", "dbo.User");
            DropIndex("dbo.User", new[] { "User_NidUser" });
            DropIndex("dbo.UserQuestion", new[] { "NidUser" });
            DropIndex("dbo.UserQuestion", new[] { "NidQuestion" });
            DropColumn("dbo.User", "User_NidUser");
            DropColumn("dbo.User", "NumLevelExperience");
            DropColumn("dbo.User", "NumLevel");
            DropColumn("dbo.User", "NumRecyclingAnswers");
            DropColumn("dbo.User", "NumEnvironmentAnswers");
            DropColumn("dbo.User", "NumWaterAnswers");
            DropColumn("dbo.User", "NumEnergyAnswers");
            DropTable("dbo.UserQuestion");
        }
    }
}
