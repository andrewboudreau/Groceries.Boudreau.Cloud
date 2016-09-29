namespace Groceries.Boudreau.Cloud.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Groceries.Boudreau.Cloud.Domain;
    using Groceries.Boudreau.Cloud.Database;

    [Route("api/[controller]")]
    public class ShoppingListItemController : Controller
    {
        private readonly ShoppingListContext shoppingListContext;

        public ShoppingListItemController(ShoppingListContext shoppingListContext)
        {
            this.shoppingListContext = shoppingListContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ShoppingItem> Get()
        {
            return shoppingListContext.ShoppingItems.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ShoppingItem Get(int id)
        {
            return shoppingListContext.ShoppingItems
                .FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(int id, [FromBody]ShoppingItem value)
        {
            var shoppingList = shoppingListContext.ShoppingLists
                .SingleAsync(x => x.Id == id);

            if(shoppingList == null)
            {
                return StatusCode(404, $"ShoppingList {id} not found.");
            }
            
            shoppingListContext.ShoppingItems.Add(value);
            await shoppingListContext.SaveChangesAsync();

            return Content(id.ToString());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]ShoppingItem value)
        {
            var item = shoppingListContext.ShoppingItems.Single(x => x.Id == id);
            item.Name = value.Name;
            item.Quantity = value.Quantity;
            item.IsChecked = value.IsChecked;

            await shoppingListContext.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            shoppingListContext.ShoppingItems.Remove(new ShoppingItem() { Id = id });
            await shoppingListContext.SaveChangesAsync();
        }
    }
}
