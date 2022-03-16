using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Data : IData
    {
        public List<User> Users { get; set; }

        public Data()
        {
            this.Users = new List<User>()
            {
               /* new User("ASD","andi1967bg@gmail.com", "tomislav_donchev123"),
                new User("ASD", "gayguy1967bg@gmail.com", "tomislav_donchev123"),
                new User("ASD", "slav1967bg@gmail.com", "tomislav_donchev123"),
                new User("ASD", "tomi1967bg@gmail.com", "tomislav_donchev123"),
               */
            };
        }
    }
}
