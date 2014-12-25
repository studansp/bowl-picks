using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using BowlPicks.Api.Security;

namespace BowlPicks.Api.Entity.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        [Required]
        [Index("IX_Username", 1, IsUnique = true)]
        public string Username { get; set; }

        [MaxLength(256)]
        [Required]
        public byte[] Password { get; set; }

        [MaxLength(256)]
        [Required]
        public byte[] Salt { get; set; }

        [Required]
        [MaxLength(256)]
        [Index("IX_Email", 1, IsUnique = true)]
        public string Email { get; set; }

        public void SetPassword(string password)
        {

            Salt = Hasher.GenerateSaltValue();
            Password = Hasher.HashPassword(System.Text.Encoding.UTF8.GetBytes(password), Salt);
        }
    }
}