using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class DrawingData : IDrawingData
    {
        public List<Drawing> Drawings { get; set; }
        public DrawingData()
        {
            this.Drawings = new List<Drawing>() {
                new Drawing("first",0,DateTime.Now,true,"b/",100),
                new Drawing("Second",0,DateTime.Now,true,"b/",100),
                new Drawing("Last",0,DateTime.Now,true,"b/",100)
            };
        }
    }
}
