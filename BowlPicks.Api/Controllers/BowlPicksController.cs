using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac.Integration.WebApi;
using BowlPicks.Api.Entity.Model;
using BowlPicks.Api.Enum;
using BowlPicks.Api.Logic;
using BowlPicks.Api.Models;

namespace BowlPicks.Api.Controllers
{
    [AutofacControllerConfiguration]
    public class BowlPicksController : ApiController
    {
        private readonly IPicksProcessor _picksProcessor;
        private readonly IAccountProcessor _accountProcessor;
        private readonly IErrorFactory _errorFactory;
        private readonly IHashProcessor _hashProcessor;

        public BowlPicksController(IPicksProcessor picksProcessor, IAccountProcessor accountProcessor, IErrorFactory errorFactory, IHashProcessor hashProcessor)
        {
            _picksProcessor = picksProcessor;
            _accountProcessor = accountProcessor;
            _errorFactory = errorFactory;
            _hashProcessor = hashProcessor;
        }

        private UserToken GetToken(string token)
        {
            var userToken = _accountProcessor.GetToken(token);

            if (userToken == null)
            {
                _errorFactory.SetAuthErrorResponse("Invalid authentication token. Please login to set picks.");
            }

            return userToken;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public UserPicksContainerModel MyPicks(string token)
        {
            return _picksProcessor.GetMyPicks(GetToken(token));
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public UserPicksContainerModel MyPicks([FromBody]PickPostData pickData)
        {
            return _picksProcessor.SetMyPicks(GetToken(pickData.Token), pickData.Picks);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Token(string userName, string password)
        {
            var token = _accountProcessor.GetToken(userName, password);

            switch (token.TokenStatus)
            {
                    case TokenStatus.UserDoesNotExist:
                    _errorFactory.SetAuthErrorResponse("User does not exist");
                    break;
                    case TokenStatus.InvalidPassword:
                    _errorFactory.SetAuthErrorResponse("Invalid password");
                    break;
            }

            return token.Token;
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<LeaderboardModel> Leaderboard()
        {
            return _picksProcessor.GetLeaderboard();
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public UserPicksContainerModel UserPicks(int id)
        {
            return _picksProcessor.GetUserPicks(id);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<SelectPair> Users()
        {
            return _picksProcessor.GetUserPairs();
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Account([FromBody]CreateAccountModel account)
        {
            var user = new User
            {
                Email = account.Email,
                Username = account.Username
            };

            user.SetPassword(_hashProcessor, account.Password);

            return _accountProcessor.CreateAccount(user, account.Password);
        }
    }
}