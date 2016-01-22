$(document).ready(function () {

    var isRtlEnabled = false;
    if ($("#isRtlEnabled").val() == "true") isRtlEnabled = true;

    var previousWidth = $.getSpikesViewPort().width;
    var checkBreakpointChange = function (isInitialLoad) {

        var viewport = $.getSpikesViewPort().width;

        if (isInitialLoad || (viewport > breakPointWidth && previousWidth <= breakPointWidth) || (viewport <= breakPointWidth && previousWidth > breakPointWidth)) {

            menu_prepareTopMenu(viewport, '.plus-button');

            menu_setMenuBackground(".mega-menu-responsive", "rgba(235,235,235,1)", 7, 7, 7, 1, viewport);

            menu_setMenuPaddings(".mega-menu-responsive > li", 15, 1, viewport, isRtlEnabled);

        }

        previousWidth = viewport;
    };

    checkBreakpointChange(true);

    $.addSpikesWindowEvent("resize", function () { checkBreakpointChange(false); });
    $.addSpikesWindowEvent("orientationchange", function () { checkBreakpointChange(false); });

})