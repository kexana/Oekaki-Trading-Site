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
                new Drawing("first",0,DateTime.Now,true,"~/ImageData/First03_10_2022_17_17_32.png",100),
                new Drawing("Second",0,DateTime.Now,true,"~/ImageData/Second03_10_2022_17_19_09.png",100),
                new Drawing("Last",0,DateTime.Now,true,"~/ImageData/Last03_10_2022_17_21_10.png",100)
            };
        }
    }
}
