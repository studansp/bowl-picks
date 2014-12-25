using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BowlPicks.Api.Models;

namespace BowlPicks.Api.Entity.Model
{
    public class UserPick
    {
        [Key]
        public int UserPickId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        public int Confidence { get; set; }

        public bool IsTeam1Selected { get; set; }
    }
}