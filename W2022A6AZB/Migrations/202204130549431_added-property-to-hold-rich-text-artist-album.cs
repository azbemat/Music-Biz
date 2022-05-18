namespace W2022A6AZB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpropertytoholdrichtextartistalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Background", c => c.String(maxLength: 2000));
            AddColumn("dbo.Artists", "Portrayal", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Portrayal");
            DropColumn("dbo.Albums", "Background");
        }
    }
}
