using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Drawing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsSellable { get; set; }
        public int Price { get; set; }
        public string ImageDirectory { get; set; }
        public int TotalLikes { get; set; }
    }
}
