using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BowlPicks.Api.Entity.Model
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        [MaxLength(100)]
        public string GameName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Team1 { get; set; }

        [Required]
        [MaxLength(100)]
        public string Team2 { get; set; }
        public decimal Team1Spread { get; set; }
        public bool IsGameOver { get; set; }
        public bool DidTeam1Win { get; set; }
        public int Year { get; set; }
    }
}