define(["./contactListView", "./contactListPresenter"],
function (view, presenter) {
    return {
        name: "Contact List",
        id: "contact:list",
        component: { id: "contact:list", view: view, presenter: presenter }
    }
});
