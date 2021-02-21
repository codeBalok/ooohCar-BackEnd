/**
 * Takes a URL parameter string and a desired parameter name and returns parameter value if present.
 * @param {any} parameterString String in the form of "?parameter1=a&parameter2=b"
 * @param {any} parameterName Name of query string parameter
 */
function getUrlParameterValue(parameterString, parameterName) {
    var tokens = parameterString.split(/[?|&]/);
    for (var i in tokens) {
        var token = tokens[i];
        if (token.length === 0) {
            continue;
        }

        var equalsIndex = token.indexOf("=");
        var key = token.substring(0, equalsIndex);
        if (key !== parameterName) {
            continue;
        }

        return token.substring(equalsIndex + 1);
    }

    return null;
};

//////////////////////////////
// Cross-frame communication functions
//////////////////////////////

/**
 * Shows/hides report header.
 * @param {any} isReportHeaderExpanded true to show, false to hide
 */
function showReportHeader(isReportHeaderExpanded){
    window.parent.postMessage({ "command": "toggleView", "section": "reportHeader", "state": isReportHeaderExpanded }, "*");
}

/**
 * Shows/hides tree view.
 * @param {any} isTreeExpanded true to show, false to hide
 */
function showTree(isTreeExpanded){
    window.parent.postMessage({ "command": "toggleView", "section": "tree", "state": isTreeExpanded }, "*");
}

/**
 * Shows/hides messages view.
 * @param {any} isMessagesExpanded true to show, false to hide
 */
function showMessages(isMessagesExpanded){
    window.parent.postMessage({ "command": "toggleView", "section": "messages", "state": isMessagesExpanded }, "*");
}

/**
 * Shows/hides statistics in code view.
 * @param {any} isStatisticsExpanded true to show, false to hide
 */
function showStatistics(isStatisticsExpanded){
    window.parent.postMessage({ "command": "toggleView", "section": "statistics", "state": isStatisticsExpanded }, "*");
}

/**
 * Highlights and scrolls to node in code view.
 * @param {any} node
 * @param {any} side Desired side to highlight and scroll ("left" or "right").
 *                      To clarify, if a user clicks code on the left (src) side, this parameter should specify "right"
 *                      since we would like to highlight and scroll to code on the right side (trg).
 */
function highlightAndScrollToNode(node, side){
    var frame = side === "left" ? window.parent.leftSide : window.parent.rightSide;
    frame.postMessage({ "command": "highlightAndScrollToVisibleNode", "node": node, "state": null }, "*");
}

/**
 * Updates center content and top navigation frames.
 * @param {any} node Node id of scenario to update to.
 * @param {any} conversionMessageId Id of converison message if available.
 */
function updateScenario(node, conversionMessageId){
    window.parent.postMessage({ "command": "scenario", "node": node, "conversionMessageId": conversionMessageId }, "*");
}

/**
 * This function gets called when a message has been clicked, now we must navigate to the object through the tree.
 * @param {any} path Id of object to navigate to in the tree
 * @param {any} conversionMessageId Id of conversion message if present.
 */
function treeNav(path, conversionMessageId){
    window.parent.postMessage({ "command": "tree-navigate", "path": path, "conversionMessageId": conversionMessageId }, "*");
}

/**
 * Triggers .click() on appropriate item in tree, which will result in navigating to desired scenario.
 * @param {any} data Json data from event in the form of {"path": path, "conversionMessageId": conversionMessageId}}.
 */
function treeNavClick(data){
    var frame = treeframe.contentWindow !== undefined ? treeframe.contentWindow : treeframe;
    frame.postMessage({ "command": "tree-navigate-click", "path": data.path, "conversionMessageId": data.conversionMessageId }, "*");
}

//////////////////////////////
