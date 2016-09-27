namespace Groceries.Boudreau.Cloud.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Groceries.Boudreau.Cloud";
            return View();
        }
    }
}
