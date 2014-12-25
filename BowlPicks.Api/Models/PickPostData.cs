using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlPicks.Api.Models
{
    public class PickPostData
    {
        public string Token { get; set; }
        public List<PickModel> Picks { get; set; }
    }
}