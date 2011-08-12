define(["./listView", "./listPresenter"],
function (view, presenter) {
    return {
        name: "List",
        id: "component:list",
        component: { id: "component:list", view: view, presenter: presenter }
    }
});
