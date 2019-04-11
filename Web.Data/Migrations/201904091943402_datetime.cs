namespace Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
