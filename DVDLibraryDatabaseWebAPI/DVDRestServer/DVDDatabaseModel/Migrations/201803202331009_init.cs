namespace DVDDataBaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        DVDId = c.Int(nullable: false, identity: true),
                        RealeaseYear = c.Int(nullable: false),
                        DVDTitle = c.String(),
                        DVDNotes = c.String(),
                        Rating = c.String(),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.DVDId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DVDs");
        }
    }
}
