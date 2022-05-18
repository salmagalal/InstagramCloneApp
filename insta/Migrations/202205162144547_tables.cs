namespace insta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        Post_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(nullable: false),
                        Caption = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Like = c.Int(nullable: false),
                        IdPost = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Post_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Photo = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender_Id = c.Int(nullable: false),
                        Reciever_Id = c.Int(nullable: false),
                        Reciever_Id1 = c.Int(),
                        Sender_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reciever_Id1)
                .ForeignKey("dbo.Users", t => t.Sender_Id1)
                .Index(t => t.Reciever_Id1)
                .Index(t => t.Sender_Id1);
            
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender_Id = c.Int(nullable: false),
                        Reciever_Id = c.Int(nullable: false),
                        Reciever_Id1 = c.Int(),
                        Sender_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reciever_Id1)
                .ForeignKey("dbo.Users", t => t.Sender_Id1)
                .Index(t => t.Reciever_Id1)
                .Index(t => t.Sender_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "Sender_Id1", "dbo.Users");
            DropForeignKey("dbo.FriendRequests", "Reciever_Id1", "dbo.Users");
            DropForeignKey("dbo.Friends", "Sender_Id1", "dbo.Users");
            DropForeignKey("dbo.Friends", "Reciever_Id1", "dbo.Users");
            DropForeignKey("dbo.Reacts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reacts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.FriendRequests", new[] { "Sender_Id1" });
            DropIndex("dbo.FriendRequests", new[] { "Reciever_Id1" });
            DropIndex("dbo.Friends", new[] { "Sender_Id1" });
            DropIndex("dbo.Friends", new[] { "Reciever_Id1" });
            DropIndex("dbo.Reacts", new[] { "User_Id" });
            DropIndex("dbo.Reacts", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Friends");
            DropTable("dbo.Users");
            DropTable("dbo.Reacts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
