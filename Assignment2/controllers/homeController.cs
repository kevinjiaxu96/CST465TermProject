using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["test"] = "I am passing data from controller to view";
            return View();
        }
    }
}