function DivscrollCall(callBackFunctio) {

    $(window).scroll(function () {
      
        var wintop = $(window).scrollTop(),
            docheight = $(document).height(),
            winheight = $(window).height();
        //var scrolltrigger = 0.95;
        var scrolltrigger = 0.50;
        if ((wintop / (docheight - winheight)) >= scrolltrigger) {
            //alert("test1" +Page);
            callBackFunctio();
        }
    });
}

function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1].replace('#', '');
        }
    }
}


function GetParameterValuesByURL(URL,param) {
    var url = URL.toString().slice(URL.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1].replace('#', '');
        }
    }
}
function _AjaxWithDataAsync(action, data, Type, callBackFunctio) {
    var obj;
    //showprogress();
    jQuery.ajax({
        url: action,
        type: Type,
        dataType: 'json',
        data: data,
        async: true,
        cache: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            obj = data;
            //hideprogress();
            callBackFunctio(data);

        },
        error: function (xhr, textStatus, errorThrown) {
            hideprogress();
            if (xhr.status == 0) {
                alert('You are offline!!\n Please Check Your Network.');
            } else if (xhr.status == 404) {
                alert('Requested URL not found.');
            } else if (xhr.status == 500) {
                alert('Internel Server Error.');
            } else if (textStatus == 'parsererror') {
                alert('Error.\nParsing JSON Request failed.');
            } else if (textStatus == 'timeout') {
                alert('Request Time out.');
            } else {
                alert('Unknow Error.\n' + xhr.responseText);
            }

        }
    });
    //return obj;
}


//(function ($) {
//    $.fn.GoScroll = function (options) {
//        debugger;
//        var defaults = {
//            pageSize: 10,
//            url: "",
//            template: "",
//            appendTo: "",
//            overlay: "overlay",
//            categoryId:""
//        };
//        //alert(defaults.categoryId);
//        var currentPage = 1;
//        var options = $.extend(defaults, options);

//        var load = function () {
//            //Todo: Insert category id.. to test, I use the number 4 (category computers --> notebook) (sample data in nop)
//            $.post("/Catalog/GetProductsWithScroll/" + currentPage + "/" + options.categoryId, function (data) {
//                $.each(data, function (i, item) {
//                    appendData(item);

//                });

//                $(options.overlay).fadeOut();
//                currentPage++;
//            });
//        };

//        var appendData = function (item) {
//            $(options.appendTo).append(item);
//        };

//        return this.each(function () {
//            obj = $(this);
//            overlay = $(options.overlay);

//            $(window).scroll(function () {
//                if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                    
//                    overlay.fadeIn();
//                    load();
//                }
//            });
//        });
//    };
//})(jQuery);