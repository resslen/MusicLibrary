namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "Year");
        }
    }
}
