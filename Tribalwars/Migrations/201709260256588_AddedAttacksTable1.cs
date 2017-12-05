namespace Tribalwars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttacksTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FarmAttacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FarmId = c.Int(nullable: false),
                        AmountLc = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FarmAttacks");
        }
    }
}
