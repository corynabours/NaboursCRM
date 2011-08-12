define(["application"], function (application) {
    function View() {
        this.view = this;
        var ListView = application.components.get("component:list").view;
        var listView = new ListView();
        listView.displayItems();
        this.content = listView.content;
    }

    return View;
});