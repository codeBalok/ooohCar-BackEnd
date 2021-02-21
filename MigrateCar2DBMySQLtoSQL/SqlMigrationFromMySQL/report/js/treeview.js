$(document).ready(function () {
    expandTreeView();
});

window.addEventListener('message', function (e) {
    var message = e.data;
    if (message.command === "tree-navigate-click" && message.path !== undefined) {
        pathTo(message.path, message.conversionMessageId);
    }
});

function expandTreeView() {
    $(".dTreeNode ul").addClass("hidden");
    $(".expander-left").click(function (e) {
        e.preventDefault();
        $(this).toggleClass("close");
        $(".tree").toggleClass("hidden");
        var isClosed = $(this).hasClass("close")
        showTree(!isClosed);
        $(this).attr(
            'aria-label',
            isClosed
                ? "Objects tree section collapsed, press Enter to expand"
                : "Objects tree section expanded, press Enter to collapse");
    });

    $(".dTreeNode a.open-close").click(function (e) {
        e.preventDefault();
        var curObj = $(this),
		openObj = $(this).parent().next();
        openObj.toggleClass("hidden");
        curObj.toggleClass("open");
        curObj.attr(
            'aria-label',
            curObj.parent().find('.node').text()
                + (curObj.hasClass("open") ? ", expanded, press Enter to collapse" : ", collapsed, press Enter to expand"));
    });

    $(".dTreeNode a.node").click(function (e) {
        e.preventDefault();
        var curObj = $(this),
		allObj = $(".dTreeNode a.node");
        allObj.removeClass("nodeSel");
        curObj.toggleClass("nodeSel");
    });
};

function pathTo(path, conversionMessageId) {
    top.tree.$(".dTreeNode .nodeSel").removeClass("nodeSel");
    top.tree.$("#" + path).addClass("nodeSel");
    top.tree.$(".holder:has(.nodeSel)").parents().each(function () {
        if ($(this).hasClass("hidden")) {
            $(this).prev().find(".open-close").addClass("open");
            $(this).removeClass("hidden");
        }
    });

    var elementTop = $("#" + path).offset().top;
    var window_h = $(window).height();
    var docTop = $(document).scrollTop();

    if (elementTop <= docTop || elementTop >= (docTop + window_h)) {
        $(document).scrollTop(elementTop);
    }

    updateScenario(path, conversionMessageId);
}
