using System.Collections.Generic;

namespace OekakiTradingSite.Models
{
    public interface IDrawingData
    {
        List<Drawing> Drawings { get; set; }
    }
}