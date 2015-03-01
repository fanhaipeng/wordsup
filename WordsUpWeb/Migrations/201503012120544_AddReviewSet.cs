namespace WordsUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviewSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Word_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.WordEntities", t => t.Word_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Word_Id);
            
            CreateTable(
                "dbo.WordEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordReviews", "Word_Id", "dbo.WordEntities");
            DropForeignKey("dbo.WordReviews", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WordReviews", new[] { "Word_Id" });
            DropIndex("dbo.WordReviews", new[] { "User_Id" });
            DropTable("dbo.WordEntities");
            DropTable("dbo.WordReviews");
        }
    }
}
