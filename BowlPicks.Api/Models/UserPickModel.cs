using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Models
{
    public class UserPickModel
    {
        public UserPickModel(UserPick pick)
        {
            Confidence = pick.Confidence;
            GameName = pick.Game.GameName;
            GameId = pick.Game.GameId;
            Team1 = pick.Game.Team1;
            Team2 = pick.Game.Team2;
            Team1Spread = pick.Game.Team1Spread;
            IsGameOver = pick.Game.IsGameOver;
            DidTeam1Win = pick.Game.DidTeam1Win;
            IsTeam1Selected = pick.IsTeam1Selected;
        }

        public int Confidence { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public decimal Team1Spread { get; set; }
        public bool IsGameOver { get; set; }
        public bool DidTeam1Win { get; set; }
        public bool IsTeam1Selected { get; set; }
    }
}