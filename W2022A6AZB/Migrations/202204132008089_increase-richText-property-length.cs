namespace W2022A6AZB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increaserichTextpropertylength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Background", c => c.String());
            AlterColumn("dbo.Artists", "Portrayal", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "Portrayal", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Albums", "Background", c => c.String(maxLength: 2000));
        }
    }
}
