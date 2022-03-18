using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Drawing
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public User Creator { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsSellable { get; set; }

        public int Price { get; set; }

        public string ImageDirectory { get; set; }

        public int TotalLikes { get; set; }
    }
}
