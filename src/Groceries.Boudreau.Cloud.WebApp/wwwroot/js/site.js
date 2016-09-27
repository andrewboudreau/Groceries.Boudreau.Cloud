// Write your Javascript code.
groceries = {
    api: {
        get: function (id) {
            if (id) {
                return $.get("/api/shoppinglist/" + id);

            }
            return $.get("/api/shoppinglist/");
        },
    }
}