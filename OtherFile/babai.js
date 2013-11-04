var babai = (function () {
    if (babai) {
        return babai;
    }

    var Regex = {
        email: /^[-_A-Za-z0-9]+@([_A-Za-z0-9]+.)+[A-Za-z0-9]{2,3}$/,
        date: /^(?:19|20)[0-9][0-9]-(?:(?:0[1-9])|(?:1[0-2]))-(?:(?:[0-2][1-9])|(?:[1-3][0-1]))$/,
        time: /^(?:(?:[0-2][0-3])|(?:[0-1][0-9])):[0-5][0-9]:[0-5][0-9]$/,
        datetime: /^(?:19|20)[0-9][0-9]-(?:(?:0[1-9])|(?:1[0-2]))-(?:(?:[0-2][1-9])|(?:[1-3][0-1])) (?:(?:[0-2][0-3])|(?:[0-1][0-9])):[0-5][0-9]:[0-5][0-9]$/,
        url: /^(http:\/\/)?(www|\w+)\.\w+\.\w+$/,
        int: /^-?\d+$/,
        phone: /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/,
        mobile: /^1[3,5,8]{1}[0-9]{1}[0-9]{8}$/,
        mobilephone: /(^1[3,5,8]{1}[0-9]{1}[0-9]{8}$)|(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)/,
        qq: /^[1-9]\d{4,9}$/
    };


    /* prototype扩展 */
    String.prototype.isEmail = function () {
        return Regex.email.test(this);
    };
    String.prototype.isDate = function () {
        return Regex.date.test(this);
    };
    String.prototype.isTime = function () {
        return Regex.time.test(this);
    };
    String.prototype.isDateTime = function () {
        return Regex.datetime.test(this);
    };
    String.prototype.isUrl = function () {
        return Regex.url.test(this);
    };
    String.prototype.isInt = function () {
        return Regex.int.test(this);
    };
    String.prototype.isPhone = function () {
        return Regex.phone.test(this);
    };
    String.prototype.isMobile = function () {
        return Regex.mobile.test(this);
    }
    String.prototype.isMobilePhone = function () {
        return Regex.mobilephone.test(this);
    };
    String.prototype.isQQ = function () {
        return Regex.qq.test(this);
    };
    String.prototype.IsIDCard = function () {
        var input = this;
        var result = { isValid: false, msg: "" };
        var Errors = new Array(
        "验证通过!",
        "身份证号码位数不对!",
        "身份证号码出生日期超出范围或含有非法字符!",
        "身份证号码校验错误!",
        "身份证地区非法!"
        );
        var area = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }

        var input, Y, JYM;
        var S, M;
        var idcard_array = new Array();
        idcard_array = input.split("");

        //地区检验 
        if (area[parseInt(input.substr(0, 2))] == null) {
            result.msg = Errors[4];
            return result;
        }
        //身份号码位数及格式检验 
        switch (input.length) {
            case 15:
                if ((parseInt(input.substr(6, 2)) + 1900) % 4 == 0 || ((parseInt(input.substr(6, 2)) + 1900) % 100 == 0 && (parseInt(input.substr(6, 2)) + 1900) % 4 == 0)) {
                    ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/; //测试出生日期的合法性 
                }
                else {
                    ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/; //测试出生日期的合法性 
                }
                if (ereg.test(input)) {
                    result.isValid = true;
                    result.msg = Errors[0];
                }
                else {
                    result.isValid = false;
                    result.msg = Errors[2];
                }
                break;
            case 18:
                if (parseInt(input.substr(6, 4)) % 4 == 0 || (parseInt(input.substr(6, 4)) % 100 == 0 && parseInt(input.substr(6, 4)) % 4 == 0)) {
                    ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //闰年出生日期的合法性正则表达式 
                }
                else {
                    ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/; //平年出生日期的合法性正则表达式 
                }
                if (ereg.test(input)) {//测试出生日期的合法性 
                    //计算校验位 
                    S = (parseInt(idcard_array[0]) + parseInt(idcard_array[10])) * 7
                + (parseInt(idcard_array[1]) + parseInt(idcard_array[11])) * 9
                + (parseInt(idcard_array[2]) + parseInt(idcard_array[12])) * 10
                + (parseInt(idcard_array[3]) + parseInt(idcard_array[13])) * 5
                + (parseInt(idcard_array[4]) + parseInt(idcard_array[14])) * 8
                + (parseInt(idcard_array[5]) + parseInt(idcard_array[15])) * 4
                + (parseInt(idcard_array[6]) + parseInt(idcard_array[16])) * 2
                + parseInt(idcard_array[7]) * 1
                + parseInt(idcard_array[8]) * 6
                + parseInt(idcard_array[9]) * 3;
                    Y = S % 11;
                    M = "F";
                    JYM = "10X98765432";
                    M = JYM.substr(Y, 1); //判断校验位 
                    if (M == idcard_array[17]) {
                        result.isValid = true;
                        result.msg = Errors[0];
                    }
                    else {
                        result.isValid = false;
                        result.msg = Errors[3];
                    }
                }
                else {
                    result.isValid = false;
                    result.msg = Errors[2];
                }
                break;
            default:
                result.isValid = false;
                result.msg = Errors[1];
        }
        return result.isValid;
    };

    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                var newObj = args;
                for (var key in newObj) {
                    if (newObj[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, newObj[key]);
                    }
                }
            }
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined && typeof (arguments[i]) != "function") {
                        var reg = new RegExp("({[" + i + "]})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }
        return result;
    };
    String.prototype.trim = function () {
        return this == null ? "" : this.toString().replace(/^[\s　]+/, "").replace(/^[\s　]+/, "").replace(/^[\s ]+/, "").replace(/^[\s ]+/, "");
    }
    Array.prototype.exists = function (element, attr) {
        for (var i = 0; i < this.length; i++) {
            if (attr) {
                if (this[i][attr] == element[attr]) return true;
            }
            else {
                if (this[i] == element) return true;
            }
        }
        return false;
    };
    Array.prototype.del = function (n) {
        if (n < 0)
            return this;
        else
            return this.slice(0, n).concat(this.slice(n + 1, this.length));
    };
    Array.prototype.delVal = function (val, attr) {
        var newArr = this;
        for (var i = 0; i < newArr.length; i++) {
            if (attr) {
                if (newArr[i][attr] == val[attr]) return newArr.del(i);
            }
            else {
                if (newArr[i] == val) return newArr.del(i);
            }
        }
        return newArr;
    };





    //babai对象
    var bb = {};





    /* 公共函数 */
    bb.isScrollEnd = function () {
        return $(document).scrollTop() >= $(document).height() - $(window).height();
    };

    bb.stopBubble = function (e) {
        if (e && e.stopPropagation) e.stopPropagation(); //w3c
        else window.event.cancelBubble = true; //IE
    }
    bb.radioValue = function (name, value) {
        var rds = $("input[name='" + name + "']");
        for (var i = 0; i < rds.length; i++) {
            if (arguments.length == 1 && rds.eq(i).attr("checked")) {
                return rds.eq(i).val();
            }
            else if (arguments.length == 2 && rds.eq(i).val() == value) {
                rds.eq(i).attr("checked", true);
                return;
            }
        }
        return null;
    };
    bb.enter = function (selector, fun) {
        $(selector).keypress(function (e) {
            if (e.keyCode == 13) {
                if (fun) fun();
                return false;
            }
        })
    };

    bb.focusColor = function (selector, color) {
        $(selector).focus(function () {
            var $this = $(this);
            $this.data("oldColor", $this.css("color"));
            $this.css("color", color);
        }).blur(function () {
            var $this = $(selector);
            $this.css("color", $this.data("oldColor"));
        })
    };
    bb.focusBGColor = function (selector, color) {
        $(selector).focus(function () {
            var $this = $(this);
            $this.data("oldgbColor", $this.css("background-color"));
            $this.css("background-color", color);
        }).blur(function () {
            var $this = $(this);
            $this.css("background-color", $this.data("oldgbColor"));
        })
    };
    bb.placeholder = function (selector, text) {
        $(selector).each(function () {
            $(this).data("color", $(this).css("color"))
            if ($(this).val() == "") {
                $(this).val(text).css("color", "#999999");
            }
        }).blur(function () {
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

    /*
    <div class="floatleft wd150 mysel">
    <span val=''>全部简历</span>[<input type='hidden' />]
    <ul class="options">
    <li val='' txt=''>已读简历</li>
    <li val='' txt=''>未读简历</li>
    </ul>
    </div>
    */
    bb.initSelect = function (selector, cb) {
        $(selector).click(function () {
            var me = $(this);
            var blw = me.css("border-left-width") || "0";
            var bbw = me.css("border-bottom-width") || "0";
            $(this).children("ul").css({ "left": 0 - parseInt(blw), "top": me.height() + parseInt(bbw) }).show();
        }).mouseleave(function () {
            $(this).children("ul").hide();
        }).hover(function () { $(this).addClass("hover"); }, function () { $(this).removeClass("hover"); });

        $(selector + " > ul li").hover(function () { $(this).addClass("hover"); }, function () { $(this).removeClass("hover"); })
        .click(function (e) {
            var me = $(this);
            var value = me.attr("val");
            if (value != undefined) {
                var ul = me.parent();
                ul.hide();
                var span = ul.siblings("span");
                var oldval = span.attr("val") || "";
                var oldhtml = span.html();
                if (value != oldval) {
                    var text = me.attr("txt") || me.html();
                    var hd = ul.siblings("input[type=hidden]");
                    if (hd.length > 0) hd.val(value);
                    span.html(text).attr("val", value);
                    var isSet = true;
                    if (cb) isSet = cb(value, text);
                    if (isSet || isSet == undefined) {
                        //无奈才想出这个还原值的方法
                    } else {
                        span.html(oldhtml).attr("val", oldval);
                        if (hd.length > 0) hd.val(oldval);
                    }
                }
            }
            babai.stopBubble(e);
        })
    };

    /* 光标操作
    * babai.caret.setRange(id, start, end):设置id的文字选区
    * babai.caret.getRange(id):得到id选区{ start: x, end: y }
    * babai.caret.setText (id, text):设置id选区文字
    * babai.caret.getText(id):得到id选区文字
    */
    bb.caret = (function () {
        var _caret = {};
        _caret.setRange = function (id, start, end) {
            var d = document, input = d.createElement("input");
            isStandard = "selectionStart" in input;
            isSupported = isStandard || (input = d.selection) && !!input.createRange();

            var o = document.getElementById(id);
            if (isStandard)
                o.setSelectionRange(start, end);
            else if (isSupported) {
                var t = o.createTextRange();
                end -= start + o.value.slice(start + 1, end).split("\n").length - 1;
                start -= o.value.slice(0, start).split("\n").length - 1;
                t.move("character", start), t.moveEnd("character", end), t.select();
            }
        };
        _caret.getRange = function (id) {
            var d = document, input = d.createElement("input");
            isStandard = "selectionStart" in input;
            isSupported = isStandard || (input = d.selection) && !!input.createRange();
            var o = document.getElementById(id);
            isTA = o.nodeName.toLowerCase() == "textarea";

            if (isStandard)
                return { start: o.selectionStart, end: o.selectionEnd };
            else if (isSupported) {
                var s = (o.focus(), d.selection.createRange()), r, start, end, value;
                if (s.parentElement() != o)
                    return { start: 0, end: 0 };
                if (isTA ? (r = s.duplicate()).moveToElementText(o) : r = o.createTextRange(), !isTA)
                    return r.setEndPoint("EndToStart", s), { start: r.text.length, end: r.text.length + s.text.length };
                for (var $ = "[###]"; (value = o.value).indexOf($) + 1; $ += $);
                r.setEndPoint("StartToEnd", s), r.text = $ + r.text, end = o.value.indexOf($);
                s.text = $, start = o.value.indexOf($);
                if (d.execCommand && d.queryCommandSupported("Undo"))
                    for (r = 3; --r; d.execCommand("Undo"));
                return o.value = value, this.setRange(id, start, end), { start: start, end: end };
            }
            return { start: 0, end: 0 };
        };
        _caret.setText = function (id, text) {
            var d = document, input = d.createElement("input");
            isStandard = "selectionStart" in input;
            isSupported = isStandard || (input = d.selection) && !!input.createRange();
            var o = document.getElementById(id);
            var o = this.getRange(id), i = document.getElementById(id), s = i.value;
            i.value = s.slice(0, o.start) + text + s.slice(o.end);
            this.setRange(id, o.start += text.length, o.start);
        };
        _caret.getText = function (id) {
            var o = this.getRange(id);

            return document.getElementById(id).value.slice(o.start, o.end);
        }
        return _caret;
    } ());
    /* 显示分页 */
    //    var pageChange = function (index) {
    //        $.get("", function () {
    //            var html = babai.pager("divid", index, 5, 1000, pageChange, { showGoTo: false, showFirst: false });
    //        })
    //    }
    //    pageChange(1);

    bb.pager = function (divPager, pageIndex, pageSize, totalCount, pageChange, opt) {

        var theOpt = {
            barSize: 5, //分页条显示的页码数   
            barTemplate: "{bar}&nbsp;&nbsp;共{totalPage}页{totalCount}条&nbsp;{goto}", //显示模板
            autoHide: true, //是否自动隐藏
            showFirst: true, //在totalPage>barSize时是自动否显示第一页链接
            showLast: true, //在totalPage>barSize时是自动否显示最后一页链接
            showGoTo: true, //是否显示GoTo
            autoHideGoTo: true //如果太少是否自动隐藏GoTo
        };

        if (opt) {
            if (opt.barSize != undefined)
                theOpt.barSize = opt.barSize;
            if (opt.barTemplate)
                theOpt.barTemplate = opt.barTemplate;
            if (opt.autoHide == false)
                theOpt.autoHide = false;
            if (opt.showFirst == false)
                theOpt.showFirst = false;
            if (opt.showLast == false)
                theOpt.showLast = false;
            if (opt.showGoTo == false)
                theOpt.showGoTo = false;
            if (opt.autoHideGoTo == false)
                theOpt.autoHideGoTo = false;
        }
        var handles = window.myPagerChanges = (function (x) { return x; } (window.myPagerChanges || {}));

        if (!myPagerChanges[divPager]) myPagerChanges[divPager] = pageChange;

        var startPage = 0;  //分页条起始页
        var endPage = 0;    //分页条终止页

        if (isNaN(pageIndex)) {
            pageIndex = 1;
        }
        pageIndex = parseInt(pageIndex);
        if (pageIndex <= 0)
            pageIndex = 1;
        if (pageIndex * pageSize > totalCount) {
            pageIndex = Math.ceil(totalCount / pageSize);
        }

        if (totalCount == 0) { //如果没数据
            document.getElementById(divPager).innerHTML = "";
            return "";
        }

        var totalPage = Math.ceil(totalCount / pageSize);
        if (theOpt.autoHide && totalCount <= pageSize) {   //自动隐藏
            document.getElementById(divPager).innerHTML = "";
            return "";
        }

        if (totalPage <= theOpt.barSize) {
            startPage = 1;
            endPage = totalPage;
            theOpt.showLast = theOpt.showFirst = false;
        }
        else {
            if (pageIndex <= Math.ceil(theOpt.barSize / 2)) { //最前几页时
                startPage = 1;
                endPage = theOpt.barSize;
                theOpt.showFirst = false;
            }
            else if (pageIndex > (totalPage - theOpt.barSize / 2)) { //最后几页时
                startPage = totalPage - theOpt.barSize + 1;
                endPage = totalPage;
                theOpt.showLast = false;
            }
            else {                                          //中间的页时
                startPage = pageIndex - Math.ceil(theOpt.barSize / 2) + 1;
                endPage = pageIndex + Math.floor(theOpt.barSize / 2);
            }
            if (totalPage <= (theOpt.barSize * 1.5)) {
                theOpt.showLast = theOpt.showFirst = false;
            }
        }

        function _getLink(index, txt) {
            if (!txt) txt = index;
            return "<a href='javascript:;' style='height:22px;line-height:22px; font-size:12px;margin: 2px 5px;border: 1px solid #6d8cad;color: #0269BA;padding: 2px 5px;text-decoration: none;' onclick='myPagerChanges[\"" + divPager + "\"](" + index + ")'>" + txt + "</a>";
        }
        function _getSpan(txt) {
            return "<span style='height:22px;line-height:22px; font-size:12px; margin: 2px 5px; border: 1px solid #cecece;color: #cecece;padding: 2px 5px;text-decoration: none;'>" + txt + "</span>";
        }


        var barHtml = "";  //分页条
        barHtml += pageIndex == 1 ? _getSpan("上一页") : _getLink(pageIndex - 1, "上一页");
        if (theOpt.showFirst) {
            barHtml += _getLink(1) + "<span>...</span>";
        }
        for (var index = startPage; index <= endPage; index++) {
            if (index == pageIndex) {
                barHtml += "<span style='color:red;font-weight:bold; margin:0 5px; '>" + index + "</span>";
            }
            else {
                barHtml += _getLink(index);
            }
        }
        if (theOpt.showLast) {
            barHtml += "<span>...</span>" + _getLink(totalPage);
        }
        barHtml += pageIndex == totalPage ? _getSpan("下一页") : _getLink(pageIndex + 1, "下一页");

        var gotoHtml = "";  //goto框及按钮
        if (theOpt.showGoTo && theOpt.barTemplate.indexOf("{goto}") > 0) {
            if ((theOpt.autoHideGoTo && totalPage > 15) || theOpt.autoHideGoTo == false) {
                var txtid = divPager + "_goIndex";
                var indexVal = "document.getElementById(\"" + txtid + "\").value";
                gotoHtml += "<input type='text' onkeyup='this.value=this.value.replace(/[^\\d]/g,\"\")'  onkeypress='if(event.keyCode==13){myPagerChanges[\"" + divPager + "\"](" + indexVal + ")}' id='" + txtid + "' value=" + pageIndex + " style='width:30px'>";
                gotoHtml += "&nbsp;<input type='button' class='page_bg' value='go' onclick='myPagerChanges[\"" + divPager + "\"](" + indexVal + ")'>";
            }
        }

        //替换模板
        var pagerHtml = theOpt.barTemplate.replace("{bar}", barHtml)
                                  .replace("{totalCount}", totalCount)
                                  .replace("{pageIndex}", pageIndex)
                                  .replace("{totalPage}", totalPage)
                                  .replace("{goto}", gotoHtml);

        document.getElementById(divPager).innerHTML = pagerHtml;
        return pagerHtml;
    };


    /*网站紧密相关*/

    bb.isLogin = function (r) {
        if (r == "nologin") {
            bb.showLoginBox();
            return false;
        }
        return true;
    };

    bb.loginGo = function (url) {
        $.get("/part/Handle/account.ashx?act=isLogin", function (r) {
            if (babai.isLogin(r)) {
                window.top.location = url;
            }
        })
    }

    //显示登陆对话框 
    bb.showLoginBox = function (cb) {
        LoginBox.show(function () {
            bb.loadHeader();
            if (cb) cb();
        });
    };
    //加载Header
    bb.loadHeader = function () {
        $.get("/part/Handle/account.ashx?act=loadheader", function (html) {
            $("#bb-header-wrap").html(html);
        });
    };

    bb.showSelectCitys = function (cb) {
        SelectCitys.show(cb);
    };
    bb.showSelectIndustrys = function (cb) {
        SelectIndustrys.show(cb);
    };
    bb.showSelectCates = function (cb) {
        SelectCates.show(cb);
    };

    //显示加好友对话框 
    bb.showAddFriend = function (sender, userid, cb) {
        var api = $.dialog(
            { id: "AddFriend",
                title: "好友请求",
                lock: true,
                max: false, min: false,
                ok: function () {
                    $.ajax({
                        url: "/Part/Handle/Contact.ashx?act=addFriend",
                        async: false,
                        data: {
                            friendid: userid,
                            groupid: $("#addfri_groupid").val(),
                            groupname: $("#addfri_groupName").val().replace(groupName_tips, "").trim(),
                            addmsg: $("#addfri_msg").val().trim()
                        },
                        success: function (r) {
                            cb(r); //r说明 1成功，2已是好友，3邀请过了
                        }
                    });
                }
            });
        $.get("/Part/Handle/Contact.ashx?act=addFriendBox", { userid: userid }, function (r) {
            if (bb.isLogin(r)) {
                api.content(r);
            } else {
                api.close();
            }
        })
    };
    //关键字补全
    bb.autocompleteKeyword = function (input, type) {
        $(input).autocomplete({
            serviceUrl: "/Part/Handle/CateData.ashx?act=autoKeyword",
            minChars: 2,
            width: "auto",
            deferRequestBy: 200,
            autoSubmit: true,
            params: { type: type }
        });
    };


    bb.tips = function (selor, opts) {
        var tipSelor = $("#" + selor);
        leftWidth = tipSelor.prev("textarea").width();
        if (opts.left) {
            tipSelor.css("left", leftWidth + opts.left + "px");
        }
        if (opts.top) {
            tipSelor.css("top", opts.top + "px");
        }
    };


    return bb;
} ());


