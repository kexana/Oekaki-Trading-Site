using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Services
{
    public class UserService : IUserService
    {
        private DataContext data;

        public UserService(DataContext data)
        {
            this.data = data;
        }
        public List<User> GetAll()
        {
            return data.Users.ToList();
        }
        public void CreateUser(User user)
        {
            this.data.Users.Add(user);
            data.SaveChanges();
        }

        public User FindById(int id)
        {
            return data.Users.FirstOrDefault(u => u.Id == id);
        }
        public void Delete(int id)
        {
            User user;
            user = FindById(id);
            data.Users.Remove(user);
            data.SaveChanges();
        }
        public void Edit(User user)
        {
            User user_new = FindById(user.Id);
            user_new.Username = user.Username;
            user_new.Email = user.Email;
            user_new.Password = user.Password;
            data.SaveChanges();
        }
    }
}
