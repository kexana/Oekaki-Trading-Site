using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class Drawing
    {
        private static int id = 0;
        private string title;
        private int creatorId;
        private int ownerId;
        private DateTime creationDate;
        private int totalLikes;
        private bool isSellable;
        private int price;
        private string imageDirectory;
        public Drawing(string title, int creatorId, DateTime creationDate , bool isSellable, string imageDirectory, int price ) {
            Title = title;
            CreatorId = creatorId;
            IsSellable = isSellable;
            CreationDate = creationDate;
            ImageDirectory = imageDirectory;
            Price = price;
            TotalLikes = 0;
            OwnerId = CreatorId;
            Id = ++id;
        }
        public int Id { get; }
        public string Title {
            get { return title; }
            set { title = value; }
        }
        public int CreatorId
        {
            get { return creatorId; }
            private set { creatorId = value; }
        }
        public int OwnerId
        {
            get { return ownerId; }
            private set { ownerId = value; }
        }
        public DateTime CreationDate{
            get{ return creationDate; } 
            private set { creationDate = value; }
        }
        public int TotalLikes
        {
            get { return totalLikes; }
            private set { totalLikes = value; }
        }
        public bool IsSellable
        {
            get { return isSellable; }
            private set { isSellable = value; }
        }
        public string ImageDirectory
        {
            get { return imageDirectory; }
            set { imageDirectory = value; }
        }
        public int Price
        {
            get { return price; }
            private set { price = value; }
        }
    }
}
