using OekakiTradingSite.Models;
using System.Collections.Generic;

namespace OekakiTradingSite.Services
{
    public interface IDrawService
    {
        Drawing AddDrawing(string title, int price, string source);
        Drawing DeleteDrawing(int id);
        Drawing EditInfo(int id, string title);
        Drawing FindById(int id);
        List<Drawing> GetAll();
        string SaveDataUrlToFile(string dataUrl, string savePath);
    }
}