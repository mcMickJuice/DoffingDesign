namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        ContactInfoId = c.Int(nullable: false, identity: true),
                        ContactType = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ContactInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInfo");
        }
    }
}
