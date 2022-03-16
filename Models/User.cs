using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class User
    {
        private static int id_count = 0;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        /*public User(string username, string email, string password)
        {
            Id = ++id_count;
            Username = username;
            Email = email;
            Password = password;
        }*/
    }
}
