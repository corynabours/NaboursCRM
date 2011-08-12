define([
    "text!./list.htm",
    "text!./listitem.htm"
],
function (main, item) {
    return {
        main: $.template(main),
        item: $.template(item)
    };
});
