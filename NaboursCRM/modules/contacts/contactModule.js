define(["./contactListView", "./contactListPresenter"],
function (view, presenter) {
    return {
        name: "Contact List",
        component: { id: "contact:list", view: view, presenter: presenter }
    }
});
