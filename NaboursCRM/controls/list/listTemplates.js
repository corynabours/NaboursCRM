define([
    "text!./list.htm",
    "text!./listitem.html"
],
function (main, item) {
    return {
        main: $.template(main),
        item: $.template(item)
    };
});
