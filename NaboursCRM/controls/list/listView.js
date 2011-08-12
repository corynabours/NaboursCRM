define(["./listTemplates"],
function (templates) {
    function View() {
        var titles = {
            NEW: "New",
            REFRESH: "Refresh",
            NO_ITEMS: "No items.",
            SELECT_ITEM_FROM_LIST: "Select an item from the list."
        };
        var view = this;
        this.content = $.tmpl(templates.main, { titles: titles });
    }

    View.prototype = {
        displayItems: function (items) {
            this.content.find("#list_items").empty();
            this.content.find("#list_items").hide();
            this.content.find("no_items").show();
        }
    };

    return View;
});
