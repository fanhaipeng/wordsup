namespace WordsUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReviewId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WordReviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WordReviews", "Word_Id", "dbo.WordEntities");
            DropIndex("dbo.WordReviews", new[] { "User_Id" });
            DropIndex("dbo.WordReviews", new[] { "Word_Id" });
            RenameColumn(table: "dbo.WordReviews", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.WordReviews", name: "Word_Id", newName: "WordId");
            DropPrimaryKey("dbo.WordReviews");
            AlterColumn("dbo.WordReviews", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WordReviews", "WordId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.WordReviews", new[] { "UserId", "WordId" });
            CreateIndex("dbo.WordReviews", "UserId");
            CreateIndex("dbo.WordReviews", "WordId");
            AddForeignKey("dbo.WordReviews", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WordReviews", "WordId", "dbo.WordEntities", "Id", cascadeDelete: true);
            DropColumn("dbo.WordReviews", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WordReviews", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.WordReviews", "WordId", "dbo.WordEntities");
            DropForeignKey("dbo.WordReviews", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WordReviews", new[] { "WordId" });
            DropIndex("dbo.WordReviews", new[] { "UserId" });
            DropPrimaryKey("dbo.WordReviews");
            AlterColumn("dbo.WordReviews", "WordId", c => c.Int());
            AlterColumn("dbo.WordReviews", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.WordReviews", "Id");
            RenameColumn(table: "dbo.WordReviews", name: "WordId", newName: "Word_Id");
            RenameColumn(table: "dbo.WordReviews", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.WordReviews", "Word_Id");
            CreateIndex("dbo.WordReviews", "User_Id");
            AddForeignKey("dbo.WordReviews", "Word_Id", "dbo.WordEntities", "Id");
            AddForeignKey("dbo.WordReviews", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
