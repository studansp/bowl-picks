using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BowlPicks.Api.Entity;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<UserToken> UserTokenRepository { get; }

        IRepository<UserPick> UserPickRepository { get; }
        IRepository<Game> GamesRepository { get; }
        int SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BowlPicksContext _context;

        public UnitOfWork(IRepository<User> userRepository, IRepository<UserToken> userTokenRepository, IRepository<UserPick> userPickRepository, IRepository<Game> gamesRepository, BowlPicksContext context)
        {
            GamesRepository = gamesRepository;
            _context = context;
            UserPickRepository = userPickRepository;
            UserTokenRepository = userTokenRepository;
            UserRepository = userRepository;
        }

        public IRepository<User> UserRepository { get; private set; }
        public IRepository<UserToken> UserTokenRepository { get; private set; }
        public IRepository<UserPick> UserPickRepository { get; private set; }
        public IRepository<Game> GamesRepository { get; private set; }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}