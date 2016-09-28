// Write your Javascript code.
groceries = {
    models: {
        ShoppingList: function () {
            return {
                id: 0,
                name: "",
                items: []
            }
        },
        ShoppingItem: function () {
            return {
                id: 0,
                name: "",
                quantity: 1,
                isChecked: false
            }
        }
    },
    api: {
        shoppinglist: {
            get: function (id) {
                if (id) {
                    return $.get("/api/shoppinglist/" + id);
                }
                return $.get("/api/shoppinglist/");
            },
            post: function (shoppinglist, done, fail) {
                return $.ajax("/api/shoppinglist", {
                    method: "POST",
                    contentType: 'application/json; charset=UTF-8',
                    dataType: "json",
                    data: JSON.stringify(shoppinglist)
                });
            },
            put: function (shoppinglist, done, fail) {
                return $.ajax("/api/shoppinglist", {
                    method: "PUT",
                    contentType: 'application/json; charset=UTF-8',
                    dataType: "json",
                    data: JSON.stringify({ id: shoppinglist.id, shoppinglist })
                });
            },
            delete: function (id) {
                return $.ajax("/api/shoppinglist/" + id, {
                    method: "DELETE"
                });
            }
        }
    }
}

var list = new groceries.models.ShoppingList();
list.items.push(new groceries.models.ShoppingItem());
list.items[0].name = "item1234";
list.name = "list1234";

var done = function () {

    groceries.api.shoppinglist.get().done(function () { console.log(arguments[0]); });
}

groceries.api.shoppinglist.post(list).done(done);


