// Write your Javascript code.
var print = function (data) {
    logger.log(data);
};

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
            post: function (shoppinglist) {
                return $.ajax("/api/shoppinglist", {
                    method: "POST",
                    contentType: 'application/json; charset=UTF-8',
                    data: JSON.stringify(shoppinglist)
                });
            },
            put: function (shoppinglist) {
                return $.ajax("/api/shoppinglist", {
                    method: "PUT",
                    contentType: 'application/json; charset=UTF-8',
                    data: JSON.stringify({ id: shoppinglist.id, shoppinglist })
                });
            },
            delete: function (id) {
                return $.ajax("/api/shoppinglist/" + id, {
                    method: "DELETE"
                });
            },
            addItem: function (id, item) {
                return $.ajax(`/api/shoppinglistitem/${id}`, {
                    method: "POST",
                    contentType: 'application/json; charset=UTF-8',
                    data: JSON.stringify({ id: id, value: item })
                });
            },
            removeItem: function (itemId) {
                return $.ajax(`/api/shoppinglistitem/${id}`, {
                    method: "DELETE"
                });
            },
            updateItem: function (item) {
                return $.ajax("/api/shoppinglistitem/" + item.id, {
                    method: "PUT",
                    contentType: 'application/json; charset=UTF-8',
                    data: JSON.stringify({ id: item.id, item })
                });
            }
        }
    }
}
