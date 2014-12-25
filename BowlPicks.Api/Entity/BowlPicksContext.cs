using System.Data.Entity;
using BowlPicks.Api.Entity.Model;


namespace BowlPicks.Api.Entity
{
    public class BowlPicksContext : DbContext
    {
        public BowlPicksContext()
            : base("BowlPicks")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserPick> UserPicks { get; set; }
    }
}