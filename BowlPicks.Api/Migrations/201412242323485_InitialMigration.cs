namespace BowlPicks.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(nullable: false, maxLength: 100),
                        Team1 = c.String(nullable: false, maxLength: 100),
                        Team2 = c.String(nullable: false, maxLength: 100),
                        Team1Spread = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsGameOver = c.Boolean(nullable: false),
                        DidTeam1Win = c.Boolean(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.UserPicks",
                c => new
                    {
                        UserPickId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Confidence = c.Int(nullable: false),
                        IsTeam1Selected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserPickId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.Binary(nullable: false, maxLength: 256),
                        Salt = c.Binary(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserTokens",
                c => new
                    {
                        UserTokenId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Token = c.String(maxLength: 256),
                        Expiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserTokenId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Token);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPicks", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPicks", "GameId", "dbo.Games");
            DropIndex("dbo.UserTokens", new[] { "Token" });
            DropIndex("dbo.UserTokens", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.UserPicks", new[] { "GameId" });
            DropIndex("dbo.UserPicks", new[] { "UserId" });
            DropTable("dbo.UserTokens");
            DropTable("dbo.Users");
            DropTable("dbo.UserPicks");
            DropTable("dbo.Games");
        }
    }
}
