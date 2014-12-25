using System.Data.Entity.Migrations;
using System.Linq;
using BowlPicks.Api.Entity;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BowlPicksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BowlPicksContext context)
        {
            if (!context.Games.Any())
            {
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Heart of Dallas Bowl",
                    IsGameOver = false,
                    Team1 = "Illinois",
                    Team1Spread = 6,
                    Team2 = " La. Tech",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Quick Lane Bowl",
                    IsGameOver = false,
                    Team1 = "Rutgers",
                    Team1Spread = 3,
                    Team2 = "North Carolina",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "St. Petersburg Bowl",
                    IsGameOver = false,
                    Team1 = "NC State",
                    Team1Spread = 2,
                    Team2 = "UCF",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Military Bowl",
                    IsGameOver = false,
                    Team1 = "Virginia Tech",
                    Team1Spread = 3,
                    Team2 = "Cincinnati",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Sun Bowl",
                    IsGameOver = false,
                    Team1 = "Duke",
                    Team1Spread = 7.5m,
                    Team2 = "Arizona State",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Independence Bowl",
                    IsGameOver = false,
                    Team1 = "Miami (Fla.)",
                    Team1Spread = -3.5m,
                    Team2 = "South Carolina",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Pinstripe Bowl",
                    IsGameOver = false,
                    Team1 = "Boston College",
                    Team1Spread = -2.5m,
                    Team2 = "Penn State",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Holiday Bowl",
                    IsGameOver = false,
                    Team1 = "Nebraska",
                    Team1Spread = 7,
                    Team2 = "USC",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Liberty Bowl",
                    IsGameOver = false,
                    Team1 = "West Virginia",
                    Team1Spread = -3.5m,
                    Team2 = "Texas A&M",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Russell Athletic Bowl",
                    IsGameOver = false,
                    Team1 = "Clemson",
                    Team1Spread = 3,
                    Team2 = "Oklahoma",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Texas Bowl",
                    IsGameOver = false,
                    Team1 = "Texas ",
                    Team1Spread = 6,
                    Team2 = "Arkansas",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Music City Bowl",
                    IsGameOver = false,
                    Team1 = "Notre Dame",
                    Team1Spread = 7,
                    Team2 = "LSU",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Belk Bowl",
                    IsGameOver = false,
                    Team1 = "Louisville",
                    Team1Spread = 6.5m,
                    Team2 = "Georgia",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Foster Farms Bowl",
                    IsGameOver = false,
                    Team1 = "Maryland ",
                    Team1Spread = 14,
                    Team2 = "Stanford",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Peach Bowl",
                    IsGameOver = false,
                    Team1 = "Ole Miss ",
                    Team1Spread = 3,
                    Team2 = "TCU",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Fiesta Bowl",
                    IsGameOver = false,
                    Team1 = "Boise State ",
                    Team1Spread = 3,
                    Team2 = "Arizona",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Orange Bowl",
                    IsGameOver = false,
                    Team1 = "Miss. State",
                    Team1Spread = -7.0m,
                    Team2 = "Ga. Tech",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Outback Bowl",
                    IsGameOver = false,
                    Team1 = "Wisconsin",
                    Team1Spread = 6.5m,
                    Team2 = "Auburn",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Cotton Bowl",
                    IsGameOver = false,
                    Team1 = "Michigan St. ",
                    Team1Spread = 2.5m,
                    Team2 = "Baylor",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Citrus Bowl",
                    IsGameOver = false,
                    Team1 = "Minnesota",
                    Team1Spread = 5,
                    Team2 = "Missouri",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Rose Bowl",
                    IsGameOver = false,
                    Team1 = "Oregon",
                    Team1Spread = -9,
                    Team2 = " Florida State",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Sugar Bowl",
                    IsGameOver = false,
                    Team1 = "Alabama",
                    Team1Spread = -9,
                    Team2 = "Ohio State",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Armed Forces Bowl",
                    IsGameOver = false,
                    Team1 = "Pittsburgh",
                    Team1Spread = -3,
                    Team2 = "Houston",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Gator Bowl",
                    IsGameOver = false,
                    Team1 = "Iowa",
                    Team1Spread = 3.5m,
                    Team2 = "Tennessee",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Alamo Bowl",
                    IsGameOver = false,
                    Team1 = "Kansas State ",
                    Team1Spread = 1.5m,
                    Team2 = "UCLA",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Cactus Bowl",
                    IsGameOver = false,
                    Team1 = "Okla. State",
                    Team1Spread = 5.5m,
                    Team2 = "Washington",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Birmingham Bowl",
                    IsGameOver = false,
                    Team1 = "Florida ",
                    Team1Spread = -6.5m,
                    Team2 = "East Carolina",
                    Year = 2014
                });
                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "GoDaddy Bowl",
                    IsGameOver = false,
                    Team1 = "Toledo",
                    Team1Spread = -4,
                    Team2 = "Arkansas State",
                    Year = 2014
                });

                context.SaveChanges();
            }
        }
    }
}