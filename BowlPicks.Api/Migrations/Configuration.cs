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
                    GameName = "Orange",
                    IsGameOver = false,
                    Team1 = "Clemson",
                    Team1Spread = 4,
                    Team2 = "Oklahoma",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Cotton",
                    IsGameOver = false,
                    Team1 = "Alabama",
                    Team1Spread = -9.5m,
                    Team2 = "Michigan State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Sugar",
                    IsGameOver = false,
                    Team1 = "Oklahoma State",
                    Team1Spread = 7,
                    Team2 = "Ole Miss",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Rose",
                    IsGameOver = false,
                    Team1 = "Iowa",
                    Team1Spread = 6.5m,
                    Team2 = "Stanford",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Fiesta",
                    IsGameOver = false,
                    Team1 = "Notre Dame",
                    Team1Spread = 6.5m,
                    Team2 = "Ohio State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Peach",
                    IsGameOver = false,
                    Team1 = "Houston",
                    Team1Spread = 7,
                    Team2 = "Florida State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "TaxSlayer",
                    IsGameOver = false,
                    Team1 = "Georgia",
                    Team1Spread = -6.5m,
                    Team2 = "Penn State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Liberty",
                    IsGameOver = false,
                    Team1 = "Kansas State",
                    Team1Spread = 13,
                    Team2 = "Arkansas",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Alamo",
                    IsGameOver = false,
                    Team1 = "Oregon",
                    Team1Spread = 0,
                    Team2 = "TCU",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Cactus",
                    IsGameOver = false,
                    Team1 = "West Virginia",
                    Team1Spread = -1,
                    Team2 = "Arizona State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Outback",
                    IsGameOver = false,
                    Team1 = "Northwestern",
                    Team1Spread = 8,
                    Team2 = "Tennessee",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Citrus",
                    IsGameOver = false,
                    Team1 = "Michigan",
                    Team1Spread = -4,
                    Team2 = "Florida",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Birmingham",
                    IsGameOver = false,
                    Team1 = "Auburn",
                    Team1Spread = -2.5m,
                    Team2 = "Memphis",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Belk",
                    IsGameOver = false,
                    Team1 = "NC State",
                    Team1Spread = 5,
                    Team2 = "Mississippi State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Music City",
                    IsGameOver = false,
                    Team1 = "Texas A&M",
                    Team1Spread = 4.5m,
                    Team2 = "Louisville",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Holiday",
                    IsGameOver = false,
                    Team1 = "USC",
                    Team1Spread = -3,
                    Team2 = "Wisconsin",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Armed Forces",
                    IsGameOver = false,
                    Team1 = "California",
                    Team1Spread = -7,
                    Team2 = "Air Force",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Russell Athletic",
                    IsGameOver = false,
                    Team1 = "North Carolina",
                    Team1Spread = 1.5m,
                    Team2 = "Baylor",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Arizona",
                    IsGameOver = false,
                    Team1 = "Nevada",
                    Team1Spread = 3,
                    Team2 = "Colorado State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Texas",
                    IsGameOver = false,
                    Team1 = "LSU",
                    Team1Spread = -7,
                    Team2 = "Texas Tech",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Military",
                    IsGameOver = false,
                    Team1 = "Pitt",
                    Team1Spread = 3.5m,
                    Team2 = "Navy",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Quick Lane",
                    IsGameOver = false,
                    Team1 = "Central Michigan",
                    Team1Spread = 6,
                    Team2 = "Minnesota",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "St. Pete",
                    IsGameOver = false,
                    Team1 = "Connecticut",
                    Team1Spread = 4,
                    Team2 = "Marshall",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Sun",
                    IsGameOver = false,
                    Team1 = "Miami (Fla)",
                    Team1Spread = 3,
                    Team2 = "Washington State",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Heart of Dallas",
                    IsGameOver = false,
                    Team1 = "Washington",
                    Team1Spread = -8.5m,
                    Team2 = "Southern Miss",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Pinstripe",
                    IsGameOver = false,
                    Team1 = "Indiana",
                    Team1Spread = -2,
                    Team2 = "Duke",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Independence",
                    IsGameOver = false,
                    Team1 = "Tulsa",
                    Team1Spread = 13.5m,
                    Team2 = "Virginia Tech",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Foster Farms",
                    IsGameOver = false,
                    Team1 = "UCLA",
                    Team1Spread = -6.5m,
                    Team2 = "Nebraska",
                    Year = 2015
                });

                context.Games.Add(new Game
                {
                    DidTeam1Win = false,
                    GameName = "Hawaii",
                    IsGameOver = false,
                    Team1 = "San Diego State",
                    Team1Spread = 1.5m,
                    Team2 = "Cincinnati",
                    Year = 2015
                });

                context.SaveChanges();
            }
        }
    }
}