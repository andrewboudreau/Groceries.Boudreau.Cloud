﻿namespace Groceries.Boudreau.Cloud.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Groceries.Boudreau.Cloud.Domain;
    using Groceries.Boudreau.Cloud.Database;

    [Route("api/[controller]")]
    public class ShoppingListController : Controller
    {
        private readonly ShoppingListContext shoppingListContext;

        public ShoppingListController(ShoppingListContext shoppingListContext)
        {
            this.shoppingListContext = shoppingListContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ShoppingList> Get()
        {
            var lists = shoppingListContext.ShoppingLists.ToList();
            return lists;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ShoppingList Get(int id)
        {
            return shoppingListContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]ShoppingList value)
        {
            shoppingListContext.ShoppingLists.Add(value);
            await shoppingListContext.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]ShoppingList value)
        {
            var list = shoppingListContext.ShoppingLists.Single(x => x.Id == id);
            list.Name = value.Name;
            list.Items = value?.Items ?? list.Items;

            await shoppingListContext.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            shoppingListContext.Remove(new ShoppingList() { Id = id });
            await shoppingListContext.SaveChangesAsync();
        }
    }
}