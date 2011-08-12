require({
    baseUrl: "Scripts",
    paths: {
        i18n: "../lib/requirejs/i18n",
        text: "../lib/requirejs/text"
    }
}, function () {
    require(["../modules/modulelist", "../controls/controllist", "application", "screen"], function (modules, controls, application, screen) {
        screen.ready(function () {
            application.components.initialize(controls);
            application.components.initialize(modules);
            var contactList = application.components.create("contact:list");
            contactList.render();
        });
    });
});
