namespace Educon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        NidQuestion = c.Int(nullable: false, identity: true),
                        DesQuestion = c.String(maxLength: 512),
                        AgeGroup = c.Int(nullable: false),
                        DesAnswerOne = c.String(maxLength: 512),
                        DesAnswerTwo = c.String(maxLength: 512),
                        DesAnswerThree = c.String(maxLength: 512),
                        DesAnswerFour = c.String(maxLength: 512),
                        NumCorrectAnswer = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NidQuestion);
            
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
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        NidUser = c.Int(nullable: false, identity: true),
                        NamUser = c.String(maxLength: 32),
                        DesPassword = c.String(maxLength: 32),
                        AgeGroup = c.Int(nullable: false),
                        NamPerson = c.String(maxLength: 128),
                        DesEmail = c.String(maxLength: 256),
                        NumEnergyAnswers = c.Int(nullable: false),
                        NumWaterAnswers = c.Int(nullable: false),
                        NumEnvironmentAnswers = c.Int(nullable: false),
                        NumRecyclingAnswers = c.Int(nullable: false),
                        NumLevel = c.Int(nullable: false),
                        NumLevelExperience = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NidUser);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        NidUser = c.Int(nullable: false),
                        NidFriend = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NidUser, t.NidFriend })
                .ForeignKey("dbo.User", t => t.NidUser)
                .ForeignKey("dbo.User", t => t.NidFriend)
                .Index(t => t.NidUser)
                .Index(t => t.NidFriend);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserQuestion", "NidQuestion", "dbo.Question");
            DropForeignKey("dbo.UserQuestion", "NidUser", "dbo.User");
            DropForeignKey("dbo.UserFriends", "NidFriend", "dbo.User");
            DropForeignKey("dbo.UserFriends", "NidUser", "dbo.User");
            DropIndex("dbo.UserFriends", new[] { "NidFriend" });
            DropIndex("dbo.UserFriends", new[] { "NidUser" });
            DropIndex("dbo.UserQuestion", new[] { "NidUser" });
            DropIndex("dbo.UserQuestion", new[] { "NidQuestion" });
            DropTable("dbo.UserFriends");
            DropTable("dbo.User");
            DropTable("dbo.UserQuestion");
            DropTable("dbo.Question");
        }
    }
}
