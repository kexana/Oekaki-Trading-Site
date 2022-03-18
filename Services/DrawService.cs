using OekakiTradingSite.Models;
using OekakiTradingSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Services class to house all functions relating to use of drawings.
/// </summary>

namespace OekakiTradingSite.Services
{
    public class DrawService : IDrawService
    {
        private DataContext dbContext;
        public DrawService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Gets all of the currently active drawings - the list of drawings present in the dbContext.
        /// </summary>
        /// <returns>List of comments.</returns>
        public List<Drawing> GetAll()
        {
            return dbContext.Drawings.ToList();
        }
        /// <summary>
        /// Adds a new Drawing to the database (dbContext) and sets its PostDate to the current time and date.
        /// Creates a string with the generated file directory and sets it as the DrawingSource property of the new Drawing.
        /// Calls the SaveDataUrlToFile() method to add the image file.
        /// </summary>
        /// <param name="newDrawing">A Drawing with set values for Title, CreatorId, OwnerId, IsSellable, Price, TotalLikes.</param>
        public void AddDrawing(Drawing newDrawing,User user)
        {
            newDrawing.Owner = user;
            newDrawing.Creator = user;
            newDrawing.CreationDate = DateTime.Now;
            string DrawingSource = "~/ImageData/" + newDrawing.Title + newDrawing.CreationDate.ToString("MM_dd_yyyy_HH_mm_ss") + ".png";
            //SaveDataUrlToFile(Source, DrawingSource);
            newDrawing.ImageDirectory = DrawingSource;
            dbContext.Drawings.Add(newDrawing);

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Edits the values for Title, IsSellable, Price in an already existing in the database Drawing.
        /// The value is passed from a new AlteredDrawing possesing the same Id, to the existing one.
        /// </summary>
        /// <param name="alteredDrawing">A Drawing with set new values and Id representing the Drawing in the database to be altered.</param>
        public void EditInfo(Drawing alteredDrawing)
        {
            Drawing drawing = FindById(alteredDrawing.Id);
            drawing.Title = alteredDrawing.Title;
            drawing.IsSellable = alteredDrawing.IsSellable;
            drawing.Price = alteredDrawing.Price;

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Finds the Drawing in the database with the provided id and deletes it from the 
        /// dbContext drawings list which in turns removes it from the database.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDrawing(int id)
        {
            Drawing drawing = FindById(id);
            //File.Delete(drawing.ImageDirectory);
            dbContext.Drawings.Remove(drawing);

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Finds the Drawing by its Id property by acessing the dbContext list of drawings and checking wether the ids match.
        /// </summary>
        /// <param name="id">The int Id property of the Drawing to be returned.</param>
        /// <returns>A single Drawing which's Id matches the provided parameter.</returns>
        public Drawing FindById(int id)
        {
            return dbContext.Drawings.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// Complex method of converting the provided dataUrl to a png image file saved at savePath using System.IO.
        /// </summary>
        /// <param name="dataUrl">Image data URL string of the image which is to be saved.</param>
        /// <param name="savePath">The file path of the resulting image file.</param>
        /// <returns>The provided fileSavePath</returns>
        public string SaveDataUrlToFile(string dataUrl, string savePath)
        {
            var matchGroups = Regex.Match(dataUrl, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
            var base64Data = matchGroups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            File.WriteAllBytes(savePath, binData);
            return savePath;
        }
        /// <summary>
        /// Adds 1 like to the TotalLikes property of a Drawing based on provide Id.
        /// </summary>
        /// <param name="id">Id property of the Drawing to be liked.</param>
        public void LikeById(int id)
        {
            Drawing drawing = FindById(id);
            drawing.TotalLikes += 1;

            dbContext.SaveChanges();
        }
    }
}
