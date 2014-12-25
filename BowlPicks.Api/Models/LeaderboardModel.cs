namespace BowlPicks.Api.Models
{
    public class LeaderboardModel
    {
        public string Name { get; set; }
        public int CorrectPicks { get; set; }
        public int TotalPicks { get; set; }
        public decimal PickPercent { get; set; }
        public int Points { get; set; }
        public int MaxPoints { get; set; }
        public int Rank { get; set; }
    }
}