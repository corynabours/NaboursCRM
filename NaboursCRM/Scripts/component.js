define(["screen"], function (screen) {
    function Component(view, presenter) {
        this.view = view;
        this.presenter = presenter;
    }
    
    Component.prototype = {
        render: function () {
            this.renderTo();
        },
        renderTo: function (container) {
            screen.render(this.view.content, container);
            this.view.onRender && this.view.onRender.notify();
        },
        append: function () {
            this.appendTo();
        },
        appendTo: function (container) {
            screen.append(this.view.content, container);
            this.view.onRender && this.view.onRender.notify();
        },
        destroy: function () {
            this.presenter.destroy && this.presenter.destroy();
            this.view.destroy && this.view.destroy();
        }
    };

    return Component;
});