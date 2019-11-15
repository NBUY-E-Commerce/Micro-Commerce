using B_Commerce.Login.DatabaseContext;
using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Commerce.Login.Common
{
    public class CacheManager
    {
        static CacheManager()
        {
            Users = new Dictionary<string, User>();
        }
        public static Dictionary<string, User> Users { get; set; }

        public static void AddUserToCache(string token, User user)
        {
            if (!Users.ContainsKey(token)) Users.Add(token, user);
        }

        public static User GetUser(string token)
        {
            if (Users.Count == 0)
            {
                List<Token> tokens = new List<Token>();
                using (LoginDbContext db = new LoginDbContext())
                {
                    tokens = db.Tokens.Where(t => t.EndDate > DateTime.Now).ToList();
                    foreach (var item in tokens)
                    {
                        AddUserToCache(item.TokenText, item.User);
                    }
                }
            }
            return Users[token];
        }
    }
}
