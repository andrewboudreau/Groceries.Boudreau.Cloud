using System;
using System.Collections.Generic;
using Groceries.Boudreau.Cloud.Domain;
using Microsoft.Extensions.Logging;

namespace Groceries.Boudreau.Cloud.Controllers
{
    public class ShoppingListService
    {
        private readonly ILogger logger;

        public ShoppingListService(ILoggerFactory loggingFactory)
        {
            logger = loggingFactory.CreateLogger<ShoppingListService>();

        }

        public int AddItems(params ShoppingItem[] items)
        {
            return 1;
        }

        internal IEnumerable<ShoppingList> GetAllLists()
        {
            logger.LogDebug("Getting all lists");
            return new List<ShoppingList>();
        }
    }
}