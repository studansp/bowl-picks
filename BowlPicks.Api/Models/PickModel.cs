using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlPicks.Api.Models
{
    public class PickModel
    {
        public int GameId { get; set; }
        public bool IsTeam1Selected { get; set; }
    }
}
