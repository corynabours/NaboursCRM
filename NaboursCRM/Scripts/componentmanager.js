define(["exports", "component"], function (exports, Component) {
    var componentList = {};
    exports.initialize = function (modules) {
        for (var i = 0, l = modules.length; i < l; ++i) {
            var module = modules[i]
            componentList[module.component.id] = module.component;
        }
    };
    exports.create = function (id) {
        var module = componentList[id];
        var view = new module.view();
        var presenter = new module.presenter(view);
        var instance = new Component(view, presenter);
        return instance;
    };
    exports.get = function (id) {
        return componentList[id];
    };
});