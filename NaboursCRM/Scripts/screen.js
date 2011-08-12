define(["exports"],
function (exports) {
    exports.render = function ($content, $container) {
        if ($container) {
            $container.empty().append($content);
        } else {
            $(function () {
                $("body").empty().append($content);
            });
        }
    };

    exports.append = function ($content, $container) {
        if ($container) {
            $container.append($content);
        } else {
            $(function () {
                $("body").append($content);
            });
        }
    };

    exports.ready = function (callback) {
        $(function () {
            $.ajaxSetup({
                cache: false
            });
            exports.name = "jQuery UI";
            exports.version = $.ui.version + "/" + $.fn.jquery;
            callback(window.location.search.replace(/^\?/, "")
				|| $("body").attr("data-profile"));
        });
    };
});
