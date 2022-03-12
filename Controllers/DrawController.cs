using Microsoft.AspNetCore.Mvc;
using OekakiTradingSite.Models;
using OekakiTradingSite.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class DrawController : Controller
    {
        private IDrawService drawService;
        public DrawController(IDrawService drawService)
        {
            this.drawService = drawService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Drawing> drawings = drawService.GetAll();

            return View(drawings);
        }
        [HttpGet]
        public IActionResult Draw()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DrawSetup()
        {

            return View();
        }
        [HttpGet]
        public IActionResult DrawPublish()
        {

            return View();
        }
        [HttpPost]
        public IActionResult DrawPublish(String Title, int Price, string Source)
        {
            Drawing drawing = drawService.AddDrawing(Title, Price, Source);
            string DrawingSource = "~/ImageData/" + drawing.Title + drawing.CreationDate.ToString("MM_dd_yyyy_HH_mm_ss") + ".png";
            //drawService.SaveDataUrlToFile(Source, DrawingSource);
            drawing.ImageDirectory = DrawingSource;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Drawing drawing = drawService.FindById(id);
            return View(drawing);
        }
        [HttpPost]
        public IActionResult AlterInfo(int id, string newTitle)
        {
            drawService.EditInfo(id, newTitle);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            drawService.DeleteDrawing(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
