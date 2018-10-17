using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Assignment2.Models;

namespace Assignment2.Controllers
{

    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["test"] = "I am passing data from controller to view";
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(Person p)
        {
            ViewBag.Name = p.Name;
            ViewBag.PhoneNumber = p.PhoneNumber;
            ViewBag.Email = p.Email;
            ViewBag.Message = p.Message;
            return View("review");
        }
    }
}