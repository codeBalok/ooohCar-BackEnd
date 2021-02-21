// Script to run on mainindex.html

window.addEventListener('message', function(e) {
    var message = e.data;
    if (message.command === "toggleView") {
        // Handles situation when user clicks on arrow to hide or show a frame
        if (message.section === undefined || message.state === undefined) {
            return;
        }

        if (message.section === "messages") {
            var collapseSize = "*,10";
            var defaultSize = "*,30%";
            var main_content = top.document.getElementById("maincontent");
            main_content.rows = "";
            /*
                When a user resizes a frame, then attempts to minimize/maximize frame,
                size behavior is unexpected.  Setting a timeout before resizing works around this issue.
            */
            setTimeout(
                function () {
                    main_content.rows = message.state ? collapseSize : defaultSize;
                },
                50);
        } else if (message.section === "tree") {
            var collapseSize = "9,*,0";
            var defaultSize = "20%,*,0";
            if (parent.centercontent.cols != undefined) {
                parent.centercontent.cols = "";
                /*
                    When a user resizes a frame, then attempts to minimize/maximize frame,
                    size behavior is unexpected.  Setting a timeout before resizing works around this issue.
                */
                setTimeout(
                    function () {
                        parent.centercontent.cols = message.state ? defaultSize : collapseSize;
                    },
                    50);
            }
        } else if (message.section === "reportHeader") {
            var collapseSize = "9,*";
            var defaultSize = "52,*";
            if (message.state) {
                parent.main.rows = defaultSize;
                $(".image-block img").css("top", "25%");
            } else {
                parent.main.rows = collapseSize;
                $(".image-block img").css("top", "75%");
            }
        }
    } else if (message.command === "scenario") {
        // Updates center content frame
        var conversionMessageIdParameter = message.node === null ? "" : "?conversionMessageId=" + message.conversionMessageId;
        document.getElementById("scenario").src = message.node + "/main.html" + conversionMessageIdParameter;
        // Update path to reflect scenario
        document.getElementById("nav").src = message.node + "/path.html";
    } else if (message.command === "tree-navigate") {
        // User has clicked on an object in the messages box and now we must click on appropriate object in the tree
        // The reason we can't use "nav" is because the selected tree object wouldn't reflect the scenario currently being shown
        // Depending on web browser, contentWindow may be undefined
        treeNavClick(message);
    }
});
