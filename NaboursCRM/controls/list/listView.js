define(["./listTemplates"],
function (templates) {
    function View() {
        this.content = $.tmpl(templates.main);
    }

    View.prototype = {
        displayItems: function (items) {
            this.content.find("#list_items").empty();
            this.content.find("#list_items").hide();
            this.content.find("no_items").show();
        }
    };
    return view;
});
