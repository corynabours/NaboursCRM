define(["./listView", "./listPresenter"],
function (view, presenter) {
    return {
        name: "List",
        component: { id: "component:list", view: view, presenter: presenter }
    }
});
