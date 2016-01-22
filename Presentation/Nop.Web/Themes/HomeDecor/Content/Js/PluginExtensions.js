﻿/*
* Copyright 2015 Seven Spikes Ltd. All rights reserved. (http://www.nop-templates.com)
* http://www.nop-templates.com/t/licensinginfo
*/

var breakPointWidth = 980, megaMenuSkipEventBinding = !1, appSettings, errorsCounter = 0; window.onerror = function (a, b, c) { null == document.body || 10 < errorsCounter || (a = "URL: " + b + "\u00a7\u00a7MESSAGE: " + a + "\u00a7\u00a7ROW: " + c, b = document.createElement("input"), b.setAttribute("class", "javascriptErrorsElement"), b.setAttribute("type", "hidden"), b.setAttribute("value", a), document.body.appendChild(b), errorsCounter++) }; window.onload = function () { $(".block").each(function () { $.getSpikesViewPort().width <= breakPointWidth && $(this).find(".jcarousel-container-vertical").hide() }); if ($.isMobile()) $(".mega-menu-responsive .labelForNextPlusButton").on("click", function () { $(this).next(".plus-button").click() }) }; function initResponsiveTheme(a, b) { appSettings = null === b || "undefined" === typeof b ? { isEnabled: !1 } : b; void 0 != appSettings.selectors && (null == appSettings.selectors.headerLinksWrapperMobileInsertAfter && (appSettings.selectors.headerLinksWrapperMobileInsertAfter = ".header"), null == appSettings.selectors.headerLinksWrapperDesktopPrependTo && (appSettings.selectors.headerLinksWrapperDesktopPrependTo = ".header")); breakPointWidth = a.themeBreakpoint; var c = !1; "true" == $("#isRtlEnabled").val() && (c = !0); var e = $.getSpikesViewPort().width, d = function (b) { var d = $.getSpikesViewPort().width; appSettings.isEnabled && b && appSettings.doesDesktopHeaderMenuStick && $(appSettings.selectors.headerMenu).wrap('<div id="headerMenuParent"></div>'); if (b || d > breakPointWidth && e <= breakPointWidth || d <= breakPointWidth && e > breakPointWidth) { var f = ".plus-button"; appSettings.isEnabled && null != appSettings.selectors.sublistButtonOpenerSelector && (f = appSettings.selectors.sublistButtonOpenerSelector); menu_prepareTopMenu(d, f); addMobileClassIfEnabled(a.shouldAddClassForMobile, d, breakPointWidth); toggleSideBlocks(b); a.hasSideBanners && attachDetachSideBanners(d, breakPointWidth); 1 == a.doesBackgroundChange && menu_setMenuBackground(a.bgSelector, a.bgInitialColor, a.red, a.green, a.blue, a.alpha, d); 1 == a.doesPaddingChange && menu_setMenuPaddings(a.paddingSelector, a.paddingValue, 1, d, c); appSettings.isEnabled && (onWidthBreak(appSettings.selectors, appSettings.isSearchBoxDetachable, appSettings.isHeaderLinksWrapperDetachable, d, b), 1 == appSettings.doesSublistHasIndent && initSublistIndent(appSettings.selectors.headerMenu, appSettings.selectors.withSubcategories)) } e = d }; d(!0); $.addSpikesWindowEvent("resize", function () { d(!1) }); $.addSpikesWindowEvent("orientationchange", function () { d(!1) }); if (appSettings.isEnabled) { if (appSettings.hasStickyNav || appSettings.displayGoToTop || appSettings.doesDesktopHeaderMenuStick) null == appSettings.selectors.headerMenuDesktopStickElement && (appSettings.selectors.headerMenuDesktopStickElement = appSettings.selectors.headerMenu), null == appSettings.selectors.headerMenuDesktopStickParentElement && (appSettings.selectors.headerMenuDesktopStickParentElement = "#headerMenuParent"), windowScrollEvents(appSettings.doesDesktopHeaderMenuStick, appSettings.hasStickyNav, appSettings.displayGoToTop, appSettings.selectors.navWrapper, appSettings.selectors.navWrapperParent, appSettings.selectors.headerMenuDesktopStickElement, appSettings.selectors.headerMenuDesktopStickParentElement); addDetachableClickEvents(appSettings.selectors, appSettings.isSearchBoxDetachable, appSettings.isHeaderLinksWrapperDetachable); if (1 == appSettings.doesScrollAfterFiltration) $(document).on("nopAjaxFiltersFiltrationCompleteEvent", function () { $.getSpikesViewPort().width <= breakPointWidth && ($(appSettings.selectors.overlayOffCanvas).triggerHandler("click"), setTimeout(function () { $(appSettings.selectors.overlayOffCanvas).hide() }, 450)) }) } addSideBlocksClickEvents(); 0 == $(".nopAjaxFilters7Spikes .block").length && $(".responsive-nav-wrapper .filters-button").remove(); if (null == appSettings.DisableFootable || 0 == appSettings.DisableFootable) "function" == typeof $("body").footable && $(".private-messages-page .data-table ,.order-summary-content .cart, .wishlist-page .cart, .downloadable-products-page .data-table, .return-request-page .data-table, .order-details-page .data-table, .compare-products-table-mobile, .reward-points-history .data-table").footable(), 0 < $(".checkout-page").length && $(document).ajaxSuccess(function () { 0 < $(".order-summary-content .cart").length && $(".order-summary-content .cart").footable() }) } $.extend({ getAttrValFromDom: function (a, b, c) { a = $(a).attr(b); if (void 0 == a || "" == a) window.console && window.console.log("'" + b + "' was not found."), a = void 0 != c ? c : ""; return a }, getHiddenValFromDom: function (a, b) { var c = $(a).val(); if (void 0 == c || "" == c) window.console && window.console.log("The 'value' was not found."), c = void 0 != b ? b : ""; return c }, getUrlVars: function () { for (var a = [], b, c = window.location.href.slice(window.location.href.indexOf("?") + 1).split("&"), e = 0; e < c.length; e++) b = c[e].split("="), a.push(b[0]), a[b[0]] = b[1]; return a }, getUrlVar: function (a) { return $.getUrlVars()[a] }, getSpikesViewPort: function () { var a = window, b = "inner"; "innerWidth" in window || (b = "client", a = document.documentElement || document.body); return { width: a[b + "Width"], height: a[b + "Height"] } }, isMobile: function () { return isMobileDevice() }, addSpikesWindowEvent: function (a, b) { window.addEventListener ? window.addEventListener(a, b, !1) : window.attachEvent && window.attachEvent("on" + a, b) } }); function attachDetachSideBanners(a, b) { if (a < b) { var c = $(".leftside-3 .slider-wrapper, .rightside-3 .slider-wrapper, .side-2 .slider-wrapper").detach(); $(".master-wrapper-main").append('<div class="mobile-banners"></div>'); $(".mobile-banners").append(c) } else $(".mobile-banners").detach() } function menu_setMenuBackground(a, b, c, e, d, g, k) { var f = "rgba(", h; if (k > breakPointWidth) f = ""; else { try { h = b.match(/^rgba?\((\d+),\s*(\d+),\s*(\d+)(?:,\s*(0|1|0\.\d+))?\)$/), delete h[0] } catch (l) { return } f = f.concat(validateColorValue(parseInt(h[1]), c) + ","); f = f.concat(validateColorValue(parseInt(h[2]), e) + ","); f = f.concat(validateColorValue(parseInt(h[3]), d) + ","); null != h[4] && (h[4] = parseFloat(h[4]) + g, b = parseFloat(h[4]), 1 < b ? b = 1 : 0 > b && (b = 0), f = f.concat(b)); f = f.concat(")") } $(a).css("background-color", f); a = $(a).children("li").children("ul"); 0 < a.length && menu_setMenuBackground(a, f, c, e, d, g, k) } function validateColorValue(a, b) { var c = parseInt(a) + b; 0 > c ? c = 0 : 255 < c && (c = 255); return c } function toggleSideBlocks(a) { $(".block").each(function () { $.getSpikesViewPort().width > breakPointWidth ? a || ($(this).children().eq(1).show(), $(this).children().eq(0).children("a.toggleControl").removeClass("closed"), $(this).find(".jcarousel-container-vertical").show()) : ($(this).children().eq(1).hide(), $(this).children().eq(0).children("a.toggleControl").addClass("closed"), $(this).find(".jcarousel-container-vertical").hide()) }) } function addMobileClassIfEnabled(a, b, c) { a && $.isMobile() && b > c ? $(".product-grid .item-box").addClass("mobile-box") : $(".product-grid .item-box").removeClass("mobile-box") } function addSideBlocksClickEvents() { $(".block .title").not($(".nopAjaxFilters7Spikes .block .title")).off("click").on("click", function () { if ($.getSpikesViewPort().width <= breakPointWidth) { var a = $(this).siblings(); a.slideToggle("slow", function () { a.css("overflow", "") }) } }); $(".nop-jcarousel.vertical-holder .carousel-title").on("click", function () { if ($.getSpikesViewPort().width <= breakPointWidth) { var a = $(this).siblings(); a.slideToggle("slow", function () { a.css("overflow", "") }) } }) } function AntiSpam(a, b) { window.location.href = "mailto:" + a + "@" + b } function initSublistIndent(a, b) { 0 < $(".mega-menu-responsive").length ? sublistIndent(".mega-menu-responsive > li > .sublist-wrap", b, 320, 1) : sublistIndent(a + " > ul > li > .sublist-wrap", b, 320, 1) } function menu_setMenuPaddings(a, b, c, e, d) { var g = $(a).children("a, span"); e <= breakPointWidth ? d ? (g.css("padding-left", ""), g.css("padding-right", b * c)) : (g.css("padding-left", b * c), g.css("padding-right", "")) : (g.css("padding-left", ""), g.css("padding-right", "")); a = $(a).children("div").children("ul").children("li"); 0 < a.children("a").length && menu_setMenuPaddings(a, parseInt(b), ++c, e, d) } function windowScrollEvents(a, b, c, e, d, g, k) { b && stickyNav(e, d); a && stickyNav(g, k); $(window).on("scroll", function () { b && stickyNav(e, d); a && stickyNav(g, k); c && (100 < $(window).scrollTop() ? $("#goToTop").show() : $("#goToTop").hide()); hasScrolled(e, d) }); if (c) $("#goToTop").on("click", function () { $("html,body").animate({ scrollTop: 0 }, 400) }) } function stickyNav(a, b) { var c = $(b), e = $(window).scrollTop(); 0 < e && e >= c.offset().top ? (c.css("height", c.height() + "px"), $(a).addClass("stick")) : (c.css("height", ""), $(a).removeClass("stick")) } var lastScrollTop = 0; function hasScrolled(a, b) { var c = $(a), e = c.filter(".stick"); if (0 == e.length || 0 == b.length) c.removeClass("nav-up"); else { var d = $(window).scrollTop(); d <= $(b).offset().top ? c.removeClass("nav-up") : (d > lastScrollTop ? e.addClass("nav-up") : e.removeClass("nav-up"), lastScrollTop = d) } } function onWidthBreak(a, b, c, e, d) { e <= breakPointWidth ? ($(a.headerMenu).add($(a.sublist)).add($(a.overlayOffCanvas)), $(a.filtersContainer).detach().insertAfter(a.headerMenu), b && $(a.searchBox).detach().insertAfter(a.navWrapperParent), c && $(a.headerLinksWrapper).detach().insertAfter(a.headerLinksWrapperMobileInsertAfter), $(a.shoppingCartLink).off("mouseenter.flyout-cart").off("mouseleave.flyout-cart"), $(".top-menu > li > .sublist-wrap").css("display", "")) : ($(a.headerMenu).css({ height: "", top: "" }), $(a.sublist).css({ height: "", top: "" }), $(a.filtersContainer).css("height", ""), d || $(a.filtersContainer).detach().prependTo(".side-2"), c && $(a.headerLinksWrapper).detach().prependTo(a.headerLinksWrapperDesktopPrependTo), b && $(a.searchBox).detach().insertAfter(a.searchBoxBefore), $(a.shoppingCartLink).on("mouseenter.flyout-cart", function (a) { var b = $(this).children(".flyout-cart"); void 0 != b.attr("isSliding") && "false" != b.attr("isSliding") || b.attr("isSliding", "true").slideDown(100, function () { $(this).css("overflow", ""); $(this).attr("isSliding", "false") }); a.preventDefault() }).on("mouseleave.flyout-cart", function (a) { $(this).children(".flyout-cart").attr("isSliding", "true").slideUp(100, function () { $(this).css("overflow", ""); $(this).attr("isSliding", "false") }); a.preventDefault() })) } function menu_prepareTopMenu(a, b) { if (null == appSettings || "undefined" == typeof appSettings) appSettings = { isEnabled: !1 }; 0 == megaMenuSkipEventBinding && ($(".menu-title").click(function () { $(this).hasClass("close") ? $(this).removeClass("close") : $(this).addClass("close"); $(this).siblings(".top-menu, .mega-menu-responsive").slideToggle("fast", function () { $(this).css("overflow", "") }); appSettings.isEnabled && $(".header-menu, .sublist-wrap").perfectScrollbar({ swipePropagation: !1, wheelSpeed: 1, suppressScrollX: !0 }) }), $(b).on("click", function (a) { var b = $(this); a.stopPropagation(); b.hasClass("close") ? b.removeClass("close") : b.addClass("close"); var d = b.siblings(".sublist-wrap"); d.hasClass("active") ? d.removeClass("active") : appSettings.isEnabled ? b.parents().eq(2).animate({ scrollTop: 0 }, 180, function () { d.addClass("active") }) : d.addClass("active"); appSettings.isEnabled && b.parents().eq(2).perfectScrollbar("destroy") }), megaMenuSkipEventBinding = !0); a > breakPointWidth ? ($(".sublist-wrap.active").removeClass("active"), $(b + ".close").removeClass("close"), $(".top-menu li").on("mouseenter", function () { $("a", $(this)).first().addClass("hover"); $(".sublist-wrap", $(this)).first().addClass("active") }).on("mouseleave", function () { $("a", $(this)).first().removeClass("hover"); $(".sublist-wrap", $(this)).first().removeClass("active") })) : ($(".top-menu li").off("mouseenter mouseleave"), $(".sublist-wrap.active").removeClass("active"), $(b + ".close").removeClass("close")) } function sublistIndent(a, b, c, e) { var d = $(a); $.getSpikesViewPort().width <= breakPointWidth ? (d.css({ width: c - 7, "z-index": d.css("z-index") + e }), $("> .sublist > li > " + b, a).css("width", c - 57)) : (d.css({ width: "", "z-index": "" }), $("> .sublist > li > " + b, a).css("width", "")); a += "> .sublist > li > .sublist-wrap"; 0 < $(a).length && sublistIndent(a, b, c - 7, e + 1) } function addDetachableClickEvents(a, b, c) { b && $(".search-wrap > span").click(function () { $(a.searchBox).addClass("open"); $(a.overlayOffCanvas).show(0).addClass("show"); $("html, body").addClass("scrollYRemove") }); $("#header-links-opener").on("click", function () { $(a.headerLinksWrapper).addClass("open"); $(a.overlayOffCanvas).show(0).addClass("show"); $("html, body").addClass("scrollYRemove") }); $(a.menuTitle).click(function () { onMenuTitleClick(a) }); $(a.closeMenu).click(function () { $(a.headerMenu).removeClass("open"); onOverlayClick(a); appSettings.isEnabled && $(".header-menu, .sublist-wrap").perfectScrollbar("destroy") }); $(a.overlayOffCanvas).click(function () { $(a.sublist).parent().removeClass("active").animate({ scrollTop: 0 }); $(a.headerMenu).add($(a.filtersContainer)).removeClass("open"); b && $(a.searchBox).removeClass("open"); c && $(a.headerLinksWrapper).removeClass("open"); onOverlayClick(a); appSettings.isEnabled && $(".header-menu, .sublist-wrap, .nopAjaxFilters7Spikes.open").perfectScrollbar("destroy") }); $(".sublist").on("click", ".back-button", function () { $(this).parent(".sublist").parent(".sublist-wrap").removeClass("active"); appSettings.isEnabled && $(this).parents().eq(4).perfectScrollbar({ swipePropagation: !1, wheelSpeed: 2, suppressScrollX: !0 }) }); $(a.filtersOpener).click(function () { $(a.filtersContainer).toggleClass("open"); $(a.movedElements).toggleClass("move-right"); $(a.overlayOffCanvas).show(0).addClass("show"); $("html, body").addClass("scrollYRemove"); appSettings.isEnabled && $(".nopAjaxFilters7Spikes.open").perfectScrollbar({ swipePropagation: !1, wheelSpeed: 1, suppressScrollX: !0 }) }); $('<div class="close-filters"><span>close</span></div>').insertBefore(".filtersPanel"); $(".close-filters").click(function () { $(a.filtersContainer).toggleClass("open"); $(a.movedElements).toggleClass("move-right"); $(a.overlayOffCanvas).removeClass("show").delay(a.overlayEffectDelay).hide(0); $("html, body").removeClass("scrollYRemove"); appSettings.isEnabled && $(".nopAjaxFilters7Spikes.open").perfectScrollbar("destroy") }) } function onMenuTitleClick(a) { $(a.headerMenu).addClass("open"); $(a.movedElements).addClass("move-right"); $(a.overlayOffCanvas).show(0).addClass("show"); $("html, body").addClass("scrollYRemove") } function onOverlayClick(a) { $(a.movedElements).removeClass("move-right"); $(a.overlayOffCanvas).removeClass("show").delay(a.overlayEffectDelay).hide(0); $("html, body").removeClass("scrollYRemove") } function isMobileDevice() { var a = navigator.userAgent || navigator.vendor || window.opera; return /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4)) ? !0 : !1 };
