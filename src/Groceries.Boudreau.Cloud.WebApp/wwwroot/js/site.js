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
