namespace WebApplication6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UID", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "HomeTown", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "HomeTown", c => c.String());
            AlterColumn("dbo.Users", "UID", c => c.String());
        }
    }
}
