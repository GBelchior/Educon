namespace Educon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "User_NidUser", "dbo.User");
            DropIndex("dbo.User", new[] { "User_NidUser" });
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
            
            DropColumn("dbo.User", "User_NidUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "User_NidUser", c => c.Int());
            DropForeignKey("dbo.UserFriends", "NidFriend", "dbo.User");
            DropForeignKey("dbo.UserFriends", "NidUser", "dbo.User");
            DropIndex("dbo.UserFriends", new[] { "NidFriend" });
            DropIndex("dbo.UserFriends", new[] { "NidUser" });
            DropTable("dbo.UserFriends");
            CreateIndex("dbo.User", "User_NidUser");
            AddForeignKey("dbo.User", "User_NidUser", "dbo.User", "NidUser");
        }
    }
}
