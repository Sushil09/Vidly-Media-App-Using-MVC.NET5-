namespace Vidly_Most_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Stock");
        }
    }
}
