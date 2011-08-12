define(
function () {
    function Presenter(view) {
        var presenter = this;
        this.view = view;

        function clear() {
            view.clearDetails();
            view.enableItemButtons(false);
        }

        this.refresh = function () {
            view.displayItems([]);
        };

        this.refresh();
    }

    return Presenter;
});
