using System.Collections.Generic;

namespace OekakiTradingSite.Models
{
    public interface IData
    {
        List<Drawing> Drawings { get; set; }
        List<Comment> Comments { get; set; }
    }
}