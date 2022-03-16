using OekakiTradingSite.Models;
using System.Collections.Generic;

namespace OekakiTradingSite.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        public void CreateUser(User user);
        public User FindById(int id);
        public void Delete(int id);

        public void Edit(User user);
    }

    
}