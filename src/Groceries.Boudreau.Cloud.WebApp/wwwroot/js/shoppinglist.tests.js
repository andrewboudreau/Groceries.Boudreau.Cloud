var logger = {};
logger.log = function (msg) {
    console.log(msg);
    $("#TestOutput").append("<p>" + msg);
}


var deleteAllLists = function () {
    return groceries.api.shoppinglist.get()
       .done(lists => {
           ids = lists.map(x => x.id);
           if (ids.length > 0) {
               logger.log(`Deleting ${ids.length} lists: ${ids.join(", ")}`);
               ids.map(id => groceries.api.shoppinglist.delete(id).done(y => logger.log(`deleted ${id}`)));
           } else {
               logger.log("No lists found when deleting all lists")
           }
       });
}

var readAllLists = function () {
    var ids;

    return groceries.api.shoppinglist.get()
        .done(lists => {
            ids = lists.map(x => x.id);
            if (ids.length > 0) {
                logger.log(`Reading ${ids.length} lists: ${ids.join(", ")}`);
            } else {
                logger.log("No lists found when reading all lists");
            }
        });
}

var readSingleList = function () {
    var ids = [];

    return groceries.api.shoppinglist.get()
        .done(function (lists) {
            ids = lists.map(x => x.id);
            if (ids.length > 0) {
                logger.log(`Found ${ids.length} lists: Using List Id ${ids[0]}`);
                groceries.api.shoppinglist.get(ids[0])
                    .done(list => {
                        logger.log(`Found list ${list.name}`);
                    });
            } else {
                logger.log("No lists found when trying to read a single list.");
            }
        });
}

var createNewList = function () {
    var list = new groceries.models.ShoppingList();
    list.items.push(new groceries.models.ShoppingItem());
    list.items[0].name = "item1234";
    list.name = "list1234";

    return groceries.api.shoppinglist.post(list).done(x => logger.log("New list created."));
}

logger.log("Testing Started");

readAllLists()
    .then(readSingleList)
    .then(deleteAllLists)
    .then(createNewList)
    .then(createNewList)
    .then(readAllLists)
    .then(readSingleList)
    .then(deleteAllLists);