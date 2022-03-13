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
        private IData data;
        public DrawService(IData data)
        {
            this.data = data;
        }
        public List<Drawing> GetAll()
        {
            return data.Drawings;
        }
        public void AddDrawing(Drawing newDrawing)
        {
            data.Drawings.Add(newDrawing);
        }
        public void EditInfo(Drawing alteredDrawing, int id)
        {
            Drawing drawing = FindById(id);
            drawing.Title = alteredDrawing.Title;
            drawing.IsSellable = alteredDrawing.IsSellable;
            drawing.Price = alteredDrawing.Price;
        }
        public void DeleteDrawing(int id)
        {
            Drawing drawing = FindById(id);
            //File.Delete(drawing.ImageDirectory);
            data.Drawings.Remove(drawing);
        }
        public Drawing FindById(int id)
        {
            return data.Drawings.FirstOrDefault(d => d.Id == id);
        }
        public string SaveDataUrlToFile(string dataUrl, string savePath)
        {
            var matchGroups = Regex.Match(dataUrl, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
            var base64Data = matchGroups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            System.IO.File.WriteAllBytes(savePath, binData);
            return savePath;
        }
    }
}
