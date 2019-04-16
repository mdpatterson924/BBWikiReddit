namespace Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComments", "PostId");
        }
    }
}
