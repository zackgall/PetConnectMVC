namespace PetConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chirps", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Chirps", "Liked", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chirps", "Liked");
            DropColumn("dbo.Chirps", "CreateDateTime");
        }
    }
}
