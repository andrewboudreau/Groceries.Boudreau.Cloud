namespace Groceries.Boudreau.Cloud.Controllers
{
    using Groceries.Boudreau.Cloud.Database;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ShoppingListClientController : Controller
    {
        private readonly ShoppingListContext shoppingListContext;

        public ShoppingListClientController(ShoppingListContext shoppingListContext)
        {
            this.shoppingListContext = shoppingListContext;
        }

        public IActionResult Index()
        {
            var model = shoppingListContext.ShoppingLists
                .Include(x => x.Items)
                .ToListAsync();

            return View(model);
        }
    }
}
