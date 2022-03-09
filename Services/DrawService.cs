using OekakiTradingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OekakiTradingSite.Services
{
    public class DrawService : IDrawService
    {
        private IDrawingData data;
        public DrawService(IDrawingData data)
        {
            this.data = data;
        }
        public List<Drawing> GetAll()
        {
            return data.Drawings;
        }
        public Drawing AddDrawing(string title, int price, string source)
        {
            Drawing drawing = new Drawing(title, 0, DateTime.Now, true, source, price);
            data.Drawings.Add(drawing);
            return drawing;
        }
        public Drawing EditInfo(int id, string title)
        {
            Drawing drawing = FindById(id);
            drawing.Title = title;
            return drawing;
        }
        public Drawing DeleteDrawing(int id)
        {
            Drawing drawing = FindById(id);
            data.Drawings.Remove(drawing);
            return drawing;
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
