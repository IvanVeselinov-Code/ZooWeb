using System.Diagnostics;
using ZooWeb.Service.Thread;
using ZooWeb.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ZooWeb.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IZooWebThreadService _ZooWebThreadService;

        public HomeController(IZooWebThreadService ZooWebThreadService)
        {
            _ZooWebThreadService = ZooWebThreadService;
        }

        public IActionResult Index()
        {
            this.ViewData["Threads"] = this._ZooWebThreadService.GetAll().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
