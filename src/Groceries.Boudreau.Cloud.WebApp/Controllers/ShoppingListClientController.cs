namespace Groceries.Boudreau.Cloud.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingListClientController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Groceries.Boudreau.Cloud";
            return View("../Home/Index");
        }
    }
}
