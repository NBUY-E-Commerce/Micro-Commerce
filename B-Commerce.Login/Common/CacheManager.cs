using B_Commerce.Login.DatabaseContext;
using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B_Commerce.Common.Repository;

namespace B_Commerce.Login.Common
{
    public class CacheManager
    {


        private IRepository<Token> _tokenRepo { get; set; }
        public CacheManager(IRepository<Token> tokenRepo)
        {
            _tokenRepo=tokenRepo;
            Users = new Dictionary<string, User>();
        }
        public static Dictionary<string, User> Users { get; set; }

        public void AddUserToCache(string token, User user)
        {
            if (!Users.ContainsKey(token)) Users.Add(token, user);
        }

        public User GetUser(string token)
        {
            if (Users.Count == 0)
            {
                List<Token> tokens = new List<Token>();
                    tokens = _tokenRepo.Get(t => t.EndDate > DateTime.Now).ToList();
                    foreach (var item in tokens)
                    {
                        AddUserToCache(item.TokenText, item.User);
                    }
                
            }

            if(Users.ContainsKey(token))
            {
                return Users[token];
            }

            return null;
        }
    }
}
