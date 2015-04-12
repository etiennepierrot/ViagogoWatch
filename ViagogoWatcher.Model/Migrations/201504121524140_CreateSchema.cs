namespace ViagogoWatcher.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventStates",
                c => new
                    {
                        EventId = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Url = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.SubscriptionStates",
                c => new
                    {
                        SubscriptionId = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        MaxPricing = c.Long(nullable: false),
                        CodeEvent = c.String(),
                        NBPlace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.UrlStates",
                c => new
                    {
                        UrlId = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        SubscriptionState_SubscriptionId = c.Long(),
                    })
                .PrimaryKey(t => t.UrlId)
                .ForeignKey("dbo.SubscriptionStates", t => t.SubscriptionState_SubscriptionId)
                .Index(t => t.SubscriptionState_SubscriptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlStates", "SubscriptionState_SubscriptionId", "dbo.SubscriptionStates");
            DropIndex("dbo.UrlStates", new[] { "SubscriptionState_SubscriptionId" });
            DropTable("dbo.UrlStates");
            DropTable("dbo.SubscriptionStates");
            DropTable("dbo.EventStates");
        }
    }
}
