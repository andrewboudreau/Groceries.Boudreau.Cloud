using System;
using System.Collections.Generic;
using Groceries.Boudreau.Cloud.Domain;
using Microsoft.Extensions.Logging;
using Groceries.Boudreau.Cloud.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Groceries.Boudreau.Cloud.Controllers
{
    public class ShoppingListService
    {
        private readonly ILogger logger;

        private readonly ShoppingListContext shoppingListContext;

        public ShoppingListService(ShoppingListContext shoppingListContext, ILoggerFactory loggingFactory)
        {
            this.shoppingListContext = shoppingListContext;
            this.logger = loggingFactory.CreateLogger<ShoppingListService>();
        }

        public int AddItems(params ShoppingItem[] items)
        {
            return 1;
        }

        public async Task<ICollection<ShoppingList>> ShoppingListsViewModel()
        {
            logger.LogDebug("Getting all shopping lists");

            var lists = await shoppingListContext.ShoppingLists.ToListAsync();
            return lists;
        }
    }
}