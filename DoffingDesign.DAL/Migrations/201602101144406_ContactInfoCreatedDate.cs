namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInfoCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfo", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfo", "CreatedDateTime");
        }
    }
}
