var logger = {};
logger.log = function (msg) {
    console.log(msg);
    $("#TestOutput").append("<p>" + msg);
}


var deleteAllLists = function () {
    var ids;
    var deleteCalls = [];
    var d = jQuery.Deferred();

    groceries.api.shoppinglist.get()
       .done(lists => {
           ids = lists.map(x => x.id);
           if (ids.length > 0) {
               logger.log(`Deleting ${ids.length} lists: ${ids.join(", ")}`);
               ids.map(id => deleteCalls.push(groceries.api.shoppinglist.delete(id).done(y => logger.log(`deleted ${id}`))));
               $.when.apply($, deleteCalls).done(x => { logger.log("all delete calls done"); d.resolve(); });
           } else {
               logger.log("No lists found when deleting all lists")
           }
       })
    .fail(x => d.reject());
    logger.log("about to return d");
    return d;
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
    var d = $.Deferred();

    groceries.api.shoppinglist.get()
        .done(function (lists) {
            ids = lists.map(x => x.id);
            if (ids.length > 0) {
                logger.log(`Found ${ids.length} lists: Using List Id ${ids[0]}`);
                groceries.api.shoppinglist.get(ids[0])
                    .done(list => {
                        if (typeof(list) === "undefined" || list === null) {
                            logger.log("list was null on single item query");
                        }
                        logger.log(`Found list ${list.name}`);
                        d.resolve();
                    })
                    .fail(x => d.reject());
            } else {
                logger.log("No lists found when trying to read a single list.");
            }
        })
        .fail(x => d.reject());

    return d;
}

var createNewList = function () {
    var list = new groceries.models.ShoppingList();
    list.items.push(new groceries.models.ShoppingItem());
    list.items[0].name = "item1234";
    list.name = "list1234";

    return groceries.api.shoppinglist.post(list).done(x => logger.log("New list created."));
}

logger.log("Testing Started");

deleteAllLists()
    .done(x => logger.log("delete all done"))
    .done(x =>
        readSingleList()
            .done(x => logger.log("reading single list done"))
            .done(x => createNewList()
                .done(x => logger.log("created list"))));

var createFive = function () {
    createNewList();
    createNewList();
    createNewList();
    createNewList();
    createNewList();
}

//readAllLists()
//    .then(readSingleList)
//    .then(deleteAllLists)
//    .then(createNewList)
//    .then(createNewList)
//    .then(readAllLists)
//    .then(readSingleList)
//    .then(deleteAllLists);