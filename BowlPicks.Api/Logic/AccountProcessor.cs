using System;
using System.Linq;
using System.Text;
using System.Transactions;
using BowlPicks.Api.Data;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Logic
{
    public interface IAccountProcessor
    {
        UserToken GetToken(string token);
        UserToken GetToken(string username, string password, bool useTransaction = true);
        string CreateAccount(User user, string password);
    }

    public class AccountProcessor : IAccountProcessor
    {
        private readonly IHashProcessor _hashProcessor;
        private readonly IUnitOfWork _unitOfWork;

        public AccountProcessor(IUnitOfWork unitOfWork, IHashProcessor hashProcessor)
        {
            _unitOfWork = unitOfWork;
            _hashProcessor = hashProcessor;
        }

        public UserToken GetToken(string token)
        {
            UserToken userToken;

            using (var trx = new TransactionScope())
            {
                userToken = _unitOfWork.UserTokenRepository.GetAll().FirstOrDefault(t => t.Token == token);
                trx.Complete();
            }

            return userToken;
        }

        public UserToken GetToken(string username, string password, bool useTransaction = true)
        {
            UserToken token;

            if (useTransaction)
            {
                using (var trx = new TransactionScope())
                {
                    token = GetTokenPrivate(username, password);
                    trx.Complete();
                }
            }
            else
            {
                token = GetTokenPrivate(username, password);
            }

            return token;
        }

        public string CreateAccount(User user, string password)
        {
            UserToken token;

            using (var trx = new TransactionScope())
            {
                _unitOfWork.UserRepository.Add(user);

                _unitOfWork.SaveChanges();

                token = GetToken(user.Username, password);

                trx.Complete();
            }

            return token.Token;
        }

        private UserToken GetTokenPrivate(string username, string password)
        {
            User user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return UserToken.UserDoesNotExist;
            }

            byte[] pw = _hashProcessor.HashPassword(Encoding.UTF8.GetBytes(password), user.Salt);

            if (pw.SequenceEqual(user.Password))
            {
                IQueryable<UserToken> userTokens =
                    _unitOfWork.UserTokenRepository.GetAll().Where(t => t.UserId == user.UserId);
                _unitOfWork.UserTokenRepository.RemoveRange(userTokens);

                var newToken = new UserToken
                {
                    Expiration = DateTime.Now.AddDays(30),
                    Token = Guid.NewGuid().ToString().Replace("-", ""),
                    UserId = user.UserId,
                    User = user
                };

                _unitOfWork.UserTokenRepository.Add(newToken);

                _unitOfWork.SaveChanges();

                return newToken;
            }

            return UserToken.InvalidPassword;
        }
    }
}