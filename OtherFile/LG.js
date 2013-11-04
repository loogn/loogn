/*common*/
var LG = (function (lg) {
    lg.focusBg = function (selector, color) {
        $(selector).focus(function () {
            $(this).data("obg", $(this).css("background-color"));
            $(this).css("background-color", color);
        }).blur(function () {
            $(this).css("background-color", $(this).data("obg"));
        })
    }

    lg.inputPrompt = function (selector, text) {
        $(selector).each(function () {
            $(this).data("color", $(this).css("color"))
            if ($(this).val() == "") {
                $(this).val(text).css("color", "#999999");

            }
        })
        .blur(function () {
            if ($(this).val() == "") {
                $(this).val(text).css("color", "#999999");
            }
        }).focus(function () {
            if ($(this).val() == text) {
                $(this).val("")
                .css("color", $(this).data("color"));
            }
        });
    };

    lg.showJSON = function (obj, div) {
        var result = "";
        var line = "\r\n";
        if (div) {
            line = "<br/>";
        }
        for (var p in obj) {
            result += p + ":" + obj[p] + "(" + typeof (obj[p]) + ")" + line;
        }
        if (div) {
            document.getElementById(div).innerHTML = result;
        }
        else {
            alert(result);
        }
    };

    lg.radioValue = function (name, value) {
        var rds = $("input[name='" + name + "']");
        for (var i = 0; i < rds.length; i++) {
            if (arguments.length == 1) {
                if (rds.eq(i).attr("checked")) {
                    return rds.eq(i).val();
                }
            }
            else if (arguments.length == 2) {
                if (rds.eq(i).val() == value) {
                    rds.eq(i).attr("checked", true);
                } else {
                    rds.eq(i).removeAttr("checked");
                }
            }
        }
        return null;
    };

    //阻止冒泡函数
    lg.stopBubble = function (e) {
        if (e && e.stopPropagation) {
            e.stopPropagation(); //w3c
        } else {
            window.event.cancelBubble = true; //IE
        }
    }

    //回车执行
    lg.enter = function (selor, fun) {
        $(selor).keypress(function (e) {
            if (e.keyCode == 13) {
                if (fun) {
                    fun();
                }
                return false;
            }
        })
    };


    //平铺对象
    lg.tiled = function (root, obj, keyPre) {
        keyPre = keyPre || "";
        for (var key in obj) {
            subv = obj[key];
            var newkey = "";
            if (typeof (subv) == "object") {
                newkey = keyPre != "" ? keyPre + "." + key : key;
                lg.tiled(root, subv, newkey);
            } else {
                newkey = keyPre != "" ? keyPre + "." + key : key;
                root[newkey] = subv;
            }
        }
    };
    //页面滚动到最底时执行
    lg.scrollOver = function () {
        return $(document).scrollTop() >= $(document).height() - $(window).height();
    };

    lg.tips = function (selor, opts) {
        var tipSelor = $("#" + selor);
        leftWidth = tipSelor.prev("textarea").width();
        if (opts.left) {
            tipSelor.css("left", leftWidth + opts.left + "px");
        }
        if (opts.top) {
            tipSelor.css("top", opts.top + "px");
        }
    };

    lg.$ = function (id) {
        return document.getElementById(id);
    }

    lg.trim = function (text) {
        return text == null ? "" : text.toString()
                .replace(/^[\s　]+/, "")
                .replace(/^[\s　]+/, "")
                .replace(/^[\s ]+/, "")
                .replace(/^[\s ]+/, "");
    }


    /*
    <li id="sel"><span id="sel_text">请选择</span><input id="sel_value" type="hidden" />
    <div id="sel_select">
    <ul class="">
    <li value="" text="请选择">全部</li>
    <li value="1">筛选合格</li>
    </ul>
    </div>
    </li>
    */
    lg.initSelect = function (jid, seljid, cb, opts) {
        var args = opts || {};
        args.left = args.left || 0;
        args.top = args.top || 0;
        $(jid).click(function () {
            var me = $(this);
            var os = me.offset();
            $(seljid).css({ "left": os.left + args.left, "top": os.top + me.outerHeight() + args.top }).show();
        }).mouseleave(function () {
            $(seljid).hide();
        })

        $(seljid + " ul li").hover(function () { $(this).addClass("hover"); }, function () { $(this).removeClass("hover"); })
        .click(function (e) {
            var me = $(this);
            var value = me.attr("val");
            if (value != undefined) {
                $(seljid).hide();
                var hd = $(jid + " input[type=hidden]");
                var oldval = hd.val();
                if (value != oldval) {
                    var text = me.attr("txt") || me.text();
                    $(jid + " span").html(text);
                    hd.val(value);
                    if (cb) {
                        cb()
                    }
                }
            }
            LG.stopBubble(e);
        })
    }



    return lg;
} (LG || {}));
