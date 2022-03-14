using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OekakiTradingSite.Services
{
    public class DrawService : IDrawService
    {
        private DataContext dbContext;
        public DrawService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Drawing> GetAll()
        {
            return dbContext.Drawings.ToList();
        }
        public void AddDrawing(Drawing newDrawing)
        {
            dbContext.Drawings.Add(newDrawing);

            dbContext.SaveChanges();
        }
        public void EditInfo(Drawing alteredDrawing)
        {
            Drawing drawing = FindById(alteredDrawing.Id);
            drawing.Title = alteredDrawing.Title;
            drawing.IsSellable = alteredDrawing.IsSellable;
            drawing.Price = alteredDrawing.Price;

            dbContext.SaveChanges();
        }
        public void DeleteDrawing(int id)
        {
            Drawing drawing = FindById(id);
            //File.Delete(drawing.ImageDirectory);
            dbContext.Drawings.Remove(drawing);

            dbContext.SaveChanges();
        }
        public Drawing FindById(int id)
        {
            return dbContext.Drawings.FirstOrDefault(d => d.Id == id);
        }
        public string SaveDataUrlToFile(string dataUrl, string savePath)
        {
            var matchGroups = Regex.Match(dataUrl, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
            var base64Data = matchGroups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            File.WriteAllBytes(savePath, binData);
            return savePath;
        }
        public void LikeById(int id)
        {
            Drawing drawing = FindById(id);
            drawing.TotalLikes += 1;

            dbContext.SaveChanges();
        }
    }
}
