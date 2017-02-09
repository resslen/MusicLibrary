namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "AlbumCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "AlbumCount");
        }
    }
}
