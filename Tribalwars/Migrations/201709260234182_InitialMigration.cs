namespace Tribalwars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FarmVillages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        TimesAttacked = c.Int(nullable: false),
                        DateAttacked = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FarmVillages");
        }
    }
}
