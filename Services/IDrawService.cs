using OekakiTradingSite.Models;
using System.Collections.Generic;

namespace OekakiTradingSite.Services
{
    public interface IDrawService
    {
        void AddDrawing(Drawing newDrawing);
        void DeleteDrawing(int id);
        void EditInfo(Drawing alteredDrawing);
        Drawing FindById(int id);
        List<Drawing> GetAll();
        string SaveDataUrlToFile(string dataUrl, string savePath);
        void LikeById(int id);
    }
}