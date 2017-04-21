namespace PetConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFriendAssoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Species", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFriends", "UserId", "dbo.Users");
            DropIndex("dbo.UserFriends", new[] { "UserId" });
            DropColumn("dbo.Users", "Species");
            DropTable("dbo.UserFriends");
        }
    }
}
