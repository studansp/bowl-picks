using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using BowlPicks.Api.Data;
using BowlPicks.Api.Entity.Model;
using BowlPicks.Api.Models;

namespace BowlPicks.Api.Logic
{
    public interface IPicksProcessor
    {
        UserPicksContainerModel GetMyPicks(UserToken token);
        UserPicksContainerModel SetMyPicks(UserToken userToken, List<PickModel> picks);
        IEnumerable<LeaderboardModel> GetLeaderboard();

        UserPicksContainerModel GetUserPicks(int id);
        List<SelectPair> GetUserPairs();
    }

    public class PicksProcessor : IPicksProcessor
    {
        private readonly IUnitOfWork _unitOfWork;

        public PicksProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserPicksContainerModel SetMyPicks(UserToken userToken, List<PickModel> picks)
        {
            using (var trx = new TransactionScope())
            {
                IEnumerable<int> incomingGames = picks.Select(p => p.GameId);

                List<UserPick> existingPicks =
                    _unitOfWork.UserPickRepository.GetAll()
                        .Where(p => p.UserId == userToken.UserId && incomingGames.Contains(p.GameId))
                        .ToList();

                for (int i = 0; i < picks.Count; i++)
                {
                    UserPick userPick = existingPicks.FirstOrDefault(p => p.GameId == picks[i].GameId);

                    if (userPick == null)
                    {
                        userPick = new UserPick
                        {
                            GameId = picks[i].GameId,
                            UserId = userToken.UserId
                        };

                        _unitOfWork.UserPickRepository.Add(userPick);
                    }

                    userPick.Confidence = picks.Count() - i;
                    userPick.IsTeam1Selected = picks[i].IsTeam1Selected;
                }

                _unitOfWork.SaveChanges();
                trx.Complete();
            }


            return GetMyPicks(userToken);
        }

        public IEnumerable<LeaderboardModel> GetLeaderboard()
        {
            IEnumerable<LeaderboardModel> picks;

            using (var trx = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions()
                {IsolationLevel = IsolationLevel.ReadCommitted}))
            {
                List<IGrouping<int, UserPick>> test1 = (from p in _unitOfWork.UserPickRepository.GetAll()
                    .Include(p => p.Game)
                    .Include(p => p.User)
                                                        group p by p.UserId
                                                            into pg
                                                            select pg).ToList();

                List<UserPicksContainerModel> allPicks = test1.Select(lb => new UserPicksContainerModel(lb)).ToList();

                picks = allPicks
                    .Select(p => p.GetLeaderboardModel())
                    .OrderByDescending(m=>m.Points)
                    .ThenByDescending(m=>m.MaxPoints);
                
                trx.Complete();
            }

            return picks;
        }

        public UserPicksContainerModel GetUserPicks(int id)
        {
            List<UserPick> picks;

            using (var trx = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                picks = _unitOfWork.UserPickRepository.GetAll().Where(p => p.UserId == id).ToList();
                trx.Complete();
            }

            return new UserPicksContainerModel(picks.OrderByDescending(p => p.Confidence));
        }

        public List<SelectPair> GetUserPairs()
        {
            List<SelectPair> userList;
            
            using (var trx = new TransactionScope())
            {
                userList = _unitOfWork.UserRepository.GetAll().Select(u => new SelectPair
                    {
                        Text = u.Username,
                        Value = u.UserId
                    }).ToList();
                trx.Complete();
            }

            return userList;
        }

        public UserPicksContainerModel GetMyPicks(UserToken userToken)
        {
            List<UserPick> picks;

            using (var trx = new TransactionScope())
            {
                User user = _unitOfWork.UserRepository.GetAll().First(u => u.UserId == userToken.UserId);

                List<Game> games = _unitOfWork.GamesRepository.GetAll().ToList();

                picks = _unitOfWork.UserPickRepository.GetAll().Where(p => p.UserId == user.UserId).ToList();

                if (games.Count != picks.Count)
                {
                    foreach (Game game in games)
                    {
                        if (picks.All(p => p.GameId != game.GameId))
                        {
                            picks.Add(new UserPick
                            {
                                Confidence = 0,
                                Game = game,
                                GameId = game.GameId,
                                IsTeam1Selected = true,
                                User = user,
                                UserId = user.UserId
                            });
                        }
                    }
                }

                trx.Complete();
            }

            return new UserPicksContainerModel(picks.OrderByDescending(p => p.Confidence));
        }
    }
}