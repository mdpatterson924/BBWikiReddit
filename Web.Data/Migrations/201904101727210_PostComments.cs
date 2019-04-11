namespace Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        EditorId = c.Guid(nullable: false),
                        CommentCatagory = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostComments");
        }
    }
}
