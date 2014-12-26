using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Models
{
    public class UserPicksContainerModel
    {
        public UserPicksContainerModel(IEnumerable<UserPick> picks)
        {
            var pickModels = new List<UserPickModel>();

            foreach (var pick in picks)
            {
                pickModels.Add(new UserPickModel(pick));

                if (pick.Game.IsGameOver)
                {
                    ++TotalPicks;

                    if ((pick.IsTeam1Selected && pick.Game.DidTeam1Win) ||
                        (!pick.IsTeam1Selected && !pick.Game.DidTeam1Win))
                    {
                        MaxPoints += pick.Confidence;
                        ++CorrectPicks;
                        
                        Points += pick.Confidence;
                    }
                }
                else
                {
                    MaxPoints += pick.Confidence;
                }
            }

            PickPercent = TotalPicks==0?0:(decimal)CorrectPicks / TotalPicks;

            //TODO Set Rank
            Rank = 1;

            var firstPick = picks.FirstOrDefault();

            if (firstPick != null)
            {
                var user = firstPick.User;

                Name = user.Username;
                UserId = user.UserId;
            }

            Picks = pickModels;
        }

        public IEnumerable<UserPickModel> Picks { get; set; }
        public string Name { get; set; }
        public int CorrectPicks { get; set; }
        public int TotalPicks { get; set; }
        public decimal PickPercent { get; set; }
        public int Points { get; set; }
        public int MaxPoints { get; set; }
        public int Rank { get; set; }
        public int UserId { get; set; }

        public LeaderboardModel GetLeaderboardModel()
        {
            return new LeaderboardModel
            {
                CorrectPicks = CorrectPicks,
                MaxPoints = MaxPoints,
                Name = Name,
                PickPercent = PickPercent,
                Points = Points,
                Rank = Rank,
                TotalPicks = TotalPicks
            };
        }
    }
}