namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagcount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Count");
        }
    }
}
