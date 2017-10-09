namespace Educon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionaexplicacaodaquestao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "DesAnswer", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "DesAnswer");
        }
    }
}
