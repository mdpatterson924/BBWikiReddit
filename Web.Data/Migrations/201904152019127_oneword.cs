namespace Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneword : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadId = c.Int(nullable: false, identity: true),
                        EditorId = c.Guid(nullable: false),
                        Text = c.String(),
                        PostCommentId = c.Int(nullable: false),
                        CreadtedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ThreadId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Threads");
        }
    }
}
