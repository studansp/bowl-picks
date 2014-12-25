using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BowlPicks.Api.Entity;
using BowlPicks.Api.Entity.Model;
using BowlPicks.Api.Models;
using BowlPicks.Api.Security;

namespace BowlPicks.Api.Controllers
{
    public class BowlPicksController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public UserPicksContainerModel MyPicks(string token)
        {
            using (var db = new BowlPicksContext())
            {
                var userToken = db.UserTokens.FirstOrDefault(t => t.Token == token);

                if (userToken == null)
                {
                    SetAuthError("Invalid authentication token. Please login to set picks.");
                }

                var user = db.Users.First(u => u.UserId == userToken.UserId);

                var games = db.Games.ToList();

                List<UserPick> picks = db.UserPicks.Where(p => p.UserId == user.UserId).ToList();

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

                return new UserPicksContainerModel(picks.OrderByDescending(p=>p.Confidence));
            }
        }

        [HttpPut]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public UserPicksContainerModel MyPicks([FromBody]PickPostData pickData)
        {
            var existingGames = pickData.Picks.Select(p => p.GameId);

            using (var db = new BowlPicksContext())
            {
                var userToken = db.UserTokens.FirstOrDefault(t => t.Token == pickData.Token);

                if (userToken == null)
                {
                    SetAuthError("Invalid authentication token. Please login to set picks.");
                }

                List<UserPick> existingPicks = db.UserPicks.Where(p => p.UserId == userToken.UserId && existingGames.Contains(p.GameId)).ToList();

                for (int i = 0; i < pickData.Picks.Count; i++)
                {
                    UserPick userPick = existingPicks.FirstOrDefault(p => p.GameId == pickData.Picks[i].GameId);

                    if (userPick == null)
                    {
                        userPick = new UserPick
                        {
                            GameId = pickData.Picks[i].GameId,
                            UserId = userToken.UserId
                        };

                        db.UserPicks.Add(userPick);
                    }

                    userPick.Confidence = pickData.Picks.Count()-i;
                    userPick.IsTeam1Selected = pickData.Picks[i].IsTeam1Selected;                    
                }

                db.SaveChanges();
            }

            return MyPicks(pickData.Token);
        }

        [HttpGet]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public string Token(string userName, string password)
        {
            using (var context = new BowlPicksContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == userName);

                if (user == null)
                {
                    SetAuthError("User does not exist");
                }
                else
                {
                    var pw = Hasher.HashPassword(System.Text.Encoding.UTF8.GetBytes(password), user.Salt);

                    if (pw.SequenceEqual(user.Password))
                    {
                        var userTokens = context.UserTokens.Where(t => t.UserId == user.UserId);
                        context.UserTokens.RemoveRange(userTokens);

                        var newToken = new UserToken
                        {
                            Expiration = DateTime.Now.AddDays(30),
                            Token = Guid.NewGuid().ToString().Replace("-", ""),
                            UserId = user.UserId,
                            User = user
                        };

                        context.UserTokens.Add(newToken);

                        context.SaveChanges();

                        return newToken.Token;
                    }
                }
            }

            SetAuthError("Incorrect password");

            return null;
        }

        private void SetAuthError(string error)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(error),
                ReasonPhrase = "Forbidden"
            });
        }

        [HttpGet]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public IEnumerable<LeaderboardModel> Leaderboard()
        {
            using (var db = new BowlPicksContext())
            {
                var test1 = (from p in db.UserPicks
                                            .Include(p=>p.Game)
                                            .Include(p => p.User)
                    group p by p.UserId
                    into pg select pg).ToList();

                var allPicks = test1.Select(lb => new UserPicksContainerModel(lb)).ToList();

                return allPicks.Select(p => p.GetLeaderboardModel());
            }
        }

        [HttpGet]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public UserPicksContainerModel UserPicks(int id)
        {
            using (var db = new BowlPicksContext())
            {
                var picks = db.UserPicks.Where(p => p.UserId == id).ToList();

                return new UserPicksContainerModel(picks.OrderByDescending(p => p.Confidence));
            }
        }

        [HttpGet]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public List<SelectPair> Users()
        {
            using (var db = new BowlPicksContext())
            {
                return db.Users.Select(u => new SelectPair
                {
                    Text = u.Username,
                    Value = u.UserId
                }).ToList();
            }
        }
        [HttpPost]
        [EnableCors(origins: "http://bowlpicks.gymtycoon.com", headers: "*", methods: "*")]
        public string Account([FromBody]CreateAccountModel account)
        {
            using (var db = new BowlPicksContext())
            {
                var user = new User
                {
                    Email = account.Email,
                    Username = account.Username
                };

                user.SetPassword(account.Password);

                db.Users.Add(user);

                db.SaveChanges();
            }

            return Token(account.Username, account.Password);
        }
    }
}