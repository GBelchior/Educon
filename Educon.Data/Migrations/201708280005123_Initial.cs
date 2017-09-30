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
                "dbo.User",
                c => new
                    {
                        NidUser = c.Int(nullable: false, identity: true),
                        NamUser = c.String(maxLength: 64),
                        DesPassword = c.String(maxLength: 32),
                        AgeGroup = c.Int(nullable: false),
                        NamPerson = c.String(maxLength: 128),
                        DesEmail = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.NidUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Question");
        }
    }
}
