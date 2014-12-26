using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BowlPicks.Api.Enum;

namespace BowlPicks.Api.Entity.Model
{
    public class UserToken
    {
        [Key]
        public int UserTokenId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [MaxLength(256)]
        [Index("IX_Token", 1, IsUnique = false)]
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        [NotMapped]
        public TokenStatus TokenStatus { get; set; }

        public static readonly UserToken UserDoesNotExist = new UserToken{ TokenStatus = TokenStatus.UserDoesNotExist};
        public static readonly UserToken InvalidPassword = new UserToken { TokenStatus = TokenStatus.InvalidPassword };
    }
}