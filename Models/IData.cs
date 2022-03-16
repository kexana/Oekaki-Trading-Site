using System.Collections.Generic;

namespace OekakiTradingSite.Models
{
    public interface IData
    {
        List<User> Users { get; set; }
    }
}