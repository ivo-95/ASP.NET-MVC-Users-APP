namespace WebApplication6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeTown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "HomeTown", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "HomeTown");
        }
    }
}
