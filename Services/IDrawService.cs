using OekakiTradingSite.Models;
using System.Collections.Generic;

namespace OekakiTradingSite.Services
{
    public interface IDrawService
    {
        void AddDrawing(Drawing newDrawing);
        void DeleteDrawing(int id);
        void EditInfo(Drawing alteredDrawing,int id);
        Drawing FindById(int id);
        List<Drawing> GetAll();
        string SaveDataUrlToFile(string dataUrl, string savePath);
    }
}