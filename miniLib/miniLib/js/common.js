var imgUrl = 'servlet/portal/attachment?dlType=ImageAttachment&attachmentType=PortalPicAttachment&attachmentId=';
var videoUrl = 'servlet/portal/attachment?dlType=ImageAttachment&attachmentType=PortalAttachment&attachmentId=';

function getImgUrl(id) {
    return imgUrl + encodeURIComponent(id);
}
function getVideoUrl(id) {
    return videoUrl + encodeURIComponent(id);
}
Portal = {};

Portal.ajax = function(op) {
    if (op.error == null) {
        op.error = function(xhr, textStatus, errorThrown) {
            Portal.Common.hideLoading();
            if (xhr && xhr.responseText) {
                if (xhr.responseText) {
                    alert(JSON.parse(xhr.responseText).message);
                } else
                    alert(xhr.responseText);
            }
        };
    }
    $.ajax(op);
};

Portal.Common = {};
var userinfo = {};
(function(p) {
    p.showLoading = function() {
        var dtop = $(document).scrollTop();
        $("#portalloading").css("top", dtop);
        $("#portalloading").find("table").css("height", $(document.body).height());
        $("#portalloading").show();
    };

    p.hideLoading = function() {
        $("#portalloading").hide();
    };

    String.prototype.filterHtml = function() {
        var s = this;
        s = s.replace(/\\/g, "\\\\");
		
        s = s.replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/\n/g, "<br>");
        return s;
    };
    String.prototype.filterAllHtml = function() {
        var s = this;

        s = s.replace(/&/g, "&amp;");
        s = s.replace(/"/g,"&quot;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        return s;
    };
    
    
    String.prototype.filterAllJS = function() {
        var s = this;
         s = s.replace(/\\/g, "\\\\");
        s = s.replace(/"/g, "\\\"");

        s = s.replace(/'/g, "\\\'");
      
        return s;
    };
    
    
    
    
    String.prototype.fliterLoc = function() {
        var jn = this.split("-");
        var rv = "";
        for (var i = 0; i < jn.length; i++) {
            if (i == 0) {
                rv += jn[i];
            } else if (jn[i] != null && jn[i] != "") {
                rv += "-" + jn[i];
            }
        }
        return rv;
    }
    
	p.checkuserishw=function()
	{
		return userinfo.hwemp;
	}

    String.prototype.fliterFamily = function() {
        var str = this.replace(/族$/mg, '').replace(/Family$/img, '');
        return str;

    }

    p.ArrayRemove = function(arry, ind) {
        var newArry = [];
        for (var i = 0; i < arry.length; i++) {
            if (i != ind) {
                newArry.push(arry[i]);
            }
        }
        return newArry;
    };
    var loginpath = "";
    var loginflag = false;
    p.getLoginPath = function() {
        return loginpath;
    };
    p.getLoginflag = function() {
        return loginflag;
    };

    /**
     * 加载弹出框
     * 
     * @param {}
     *            op
     * @return {}
     */
    p.dialog = function(op) {

        var diag = $("#diag");
        var title = "";
        diag.addClass("dialog");
        if (op && op.width != null) {
            diag.width(op.width);
        }
        var bwidth = $(document.body).width();
        diag.css("left", (bwidth - 750) / 2);
        diag.html("<div style=\"width:100%;height:100%\"><iframe style=\"width:90%;height:90%\"></iframe><div>");
        var innerdiv = $("<div></div>");
        innerdiv.addClass("innerdialog");
        var titlediv = $("<div></div>");
        var titlevoer = $("<div></div>");
        titlevoer.addClass("titlevoer");

        titlediv.html(title);
        var headerdiv = $("<div></div>");
        headerdiv.addClass("dialogheader");
        headerdiv.append(titlediv);
        headerdiv.append(titlevoer);

        var closeddiv = $("<div></div>");
        closeddiv.addClass("diagclosediv");
        headerdiv.append(closeddiv);
        innerdiv.append(headerdiv);
        diag.append(innerdiv);
        $("#overbody").addClass("overbody");

        var contentdiv = $("<div></div>");
        contentdiv.addClass("dcontent");
        innerdiv.append(contentdiv);
        var dtop = $(document).scrollTop();
        $("#overbody").css("height", $(document).height());
        diag.css("top", dtop + 80);
        diag.show();
        var md = 0;
        var x = 0;
        var y = 0;
        var offset = null;
        titlevoer.mousedown(function(event) {
                    offset = diag.offset();
                    md = 1;
                    x = event.clientX;
                    y = event.clientY;

                });
        $(document).mouseup(function() {
                    md = 0;
                });

        $(document).mousemove(function(event) {
                    if (md == 1) {
                        diag.css({
                                    "top" : event.clientY - y + offset.top < 80 ? 80 : event.clientY - y + offset.top,
                                    "left" : event.clientX - x + offset.left
                                });
                    }
                });

        var dia = {
            setTitle : function(t) {
                title = t;
                titlediv.html(title);
            },
            close : function() {
                diag.hide();
                $("#overbody").removeClass("overbody");
                $("#overbody").css("height", 0);
            },
            setContent : function(content) {
                contentdiv.html(content);
            },
            loadurl : function(url, callback) {
                $.ajax({
                            url : url,
                            cache : false,
                            dataType : "html",
                            success : function(html) {
                                contentdiv.html(html);
                                callback();
                            }
                        });
            }

        };
        closeddiv.click(function() {
                    dia.close();
                });
        return dia;
    };

    /**
     * 格式化日期
     * 
     * @param {}
     *            v
     * @return {}
     */
    p.fomartDate = function(v) {
        if (v != null) {
            var i = v.indexOf("T");
            v = v.substring(0, i);
        }
        return v;
    };

    /**
     * 初始化页头信息
     */
    p.initHeader = function(callback) {
    	$(".userInfo").html("");
        initLanguage();
        $.ajax({
                    url : "services/portal/portalpub/getHeaderInfo",
                    async : false,
                    cache : false,
                    dataType : "json",
                    success : function(headerinfo) {
                    	
                    	
                        if (headerinfo.user == null || headerinfo.user == "null") {
                            loginflag = false;
                            loginpath = "login_index.html?redirect=" + window.location.href;
                            var registerpath = headerinfo.registerpath + "?method=toRegister&appurl=" + window.location.href;
                             
                            $(".userInfo").append("<span class=\"loginInfoLine\"></span><a href=\"" + loginpath + "\">登录</a><span class=\"loginInfoLine\"></span><a href=\"" + registerpath + "\">注册</a>");
                        } else {
                            userinfo = headerinfo.user;
                            userinfo.telphone = headerinfo.telphone;
                            userinfo.telephoneTitle=headerinfo.telephoneTitle;
                            userinfo.resumeId = headerinfo.resumeId;
                            if(headerinfo.hwemp&&headerinfo.hwemp=="1")
	                    	{
	                    		userinfo.hwemp=true;
	                    	}
                            loginflag = true;
                            $(".userInfo").append("<span class=\"loginInfoLine\"></span><a href=\"portal_index.html\" class=\"userName\">Hi," + userinfo.userCN + "</a><span class=\"loginInfoLine\"></span><a href=\"servlet/logout\">退出</a>");
                        }
                        if (callback) {
                            callback();
                        }
                    }
                });
    };

    /**
     * 获取地址栏参数
     * 
     * @return {}
     */
    getParamers = function() {
        var query = window.location.search;
        var args = new Object();
        query = query.substring(1);
        if (query.length > 0) {
            var pairs = query.split("&");
            for (var i = 0; i < pairs.length; i++) {
                var pos = pairs[i].indexOf('=');
                if (pos == -1)
                    continue;
                var argname = pairs[i].substring(0, pos);
                var value = pairs[i].substring(pos + 1);
                value = decodeURIComponent(value);
                args[argname] = value;
            }
        }
        return args;
    };
    p.getParamers = getParamers;

})(Portal.Common);

$.fn.loadPage = function(page, clickfn) {

    var totalPages = page.totalPages;
    this.append("<label class=\"textLabel\">共<span class=\"num\">" + page.totalRows + "</span>条</label>");
    if (totalPages <= 1) {
        return;
    }
    var pagediv = $("<div class=\"pagesCon\"></div>");

    if (page.curPage == 1) {
        // pagediv.append("<a><span><img
        // src=\"images/pages/prev.png\"></span></a>");
        pagediv.append("<a class=\"on\"><span>" + 1 + "</span></a>");
    } else {
        pagediv.append($("<a><span><img src=\"images/pages/prev.png\"></span></a>").click(function() {
                    page.curPage -= 1;
                    if (page.curPage < 1) {
                        page.curPage = 1;
                    }
                    clickfn(page);
                }

        ));
        pagediv.append($("<a><span>1</span></a>").click(function() {
                    page.curPage = 1;
                    clickfn(page);
                }));
    }
    var showMinPage = page.curPage - 2;
    if (showMinPage < 2) {
        showMinPage = 2;
    }
    if (showMinPage > 2) {
        pagediv.append("...");
    }
    var showMaxPage = showMinPage + 5;
    if (showMaxPage > totalPages - 1) {
        showMaxPage = totalPages - 1;
    }
    for (var i = showMinPage; i <= showMaxPage; i++) {
        if (i == page.curPage) {
            pagediv.append("<a  class=\"on\"><span>" + i + "</span></a>");
        } else {
            (function(p) {
                pagediv.append($("<a><span>" + p + "</span></a>").click(function() {
                            page.curPage = p;
                            clickfn(page);

                        }));
            })(i);

        }
    }
    if (showMaxPage < totalPages - 1) {
        pagediv.append("...");
    }

    if (page.curPage == totalPages) {
        pagediv.append("<a class=\"on\"><span>" + totalPages + "</span></a>");
        // pagediv.append("<a><span><img
        // src=\"images/pages/next.png\"></span></a>");

    } else {

        pagediv.append($("<a><span>" + totalPages + "</span></a>").click(function() {
                    page.curPage = totalPages;
                    clickfn(page);
                }));
        pagediv.append($("<a><span><img src=\"images/pages/next.png\"></span></a>").click(function() {
                    page.curPage += 1;
                    if (page.curPage > totalPages) {
                        page.curPage = totalPages;
                    }
                    clickfn(page);
                }));
    }
    this.append(pagediv);
};
$.fn.checked = function() {
    var checked = $(this[0]).attr("checked");
    if (checked && checked == "checked") {
        return true;
    }
    return false;
};

/**
 * 加载表格
 * 
 * @param {}
 *            op
 */
$.fn.jobtable = function(op) {
    var lastclicks = null;
    var columns = op.colum;
    var elm = $(this);
    var jobtable;
    var tind = 0;
    var recorddata = [];
    var addRecord = [];
    if (op.pageSize == null) {
        op.pageSize = 10;
    }

    op.curPage = 1;
    function addRow(record, newFlag) {
        record.tindx = tind;
        var jobtr = $("<tr></tr>");

        for (var j = 0; j < columns.length; j++) {
            var value = "";
            if (record) {
                value = record[columns[j].id];
            }
            if (value == null) {
                value = "";
            }
            var dtd = $("<td class=\"" + columns[j].dataClass + "\"></td>");
            dtd.css({"word-break":"keep-all","white-space":"nowrap","overflow":"hidden","text-overflow":"ellipsis" });
            
            
            if (columns[j].exdattr) {
                dtd.attr(columns[j].exdattr);
            }
            if (columns[j].isNo) {
                value = (tind + 1);
                jobtr.append(dtd.text(value));
            } else {
            	dtd.attr("title",value);
                if (columns[j].dataType) {
                    if (columns[j].dataType == "date") {
                        value = Portal.Common.fomartDate(value);
                    }
                }
                if (columns[j].render != null) {
                    value = columns[j].render(value, record);
                    jobtr.append(dtd.append(value));
                } else if (columns[j].editrender) {

                    value = columns[j].editrender(value, record);
                    jobtr.append(dtd.append(value));
                } else {
                    jobtr.append(dtd.text(value));
                }

            }

        }
        op.addRowBack && op.addRowBack(jobtr);
        jobtable.append(jobtr);
        if (newFlag) {
            record.addFlag = true;
            recorddata.push(record);
        }
        tind++;
    }

    function loadtabledata(op, data) {

        tind = 0;
        jobtable = $("<table width=\"100%\" cellspacing=\"0\" class=\"listtable\" cellpadding=\"0\"></table>");
        jobtable.css({"table-layout": "fixed"});
        jobtable.addClass(op.tableClass);

        var jobthr = $("<tr></tr>");
        for (var i = 0; i < columns.length; i++) {
            jobthr.append($("<th class=\"" + columns[i].titleClass + "\"></th>").append($.i18nKey(columns[i].header)));
        }
        jobtable.append(jobthr);
        if (data) {
            recorddata = data;
            for (var i = 0; i < data.length; i++) {
                addRow(data[i]);
            }
            jobtable.find("tr:even").addClass(op.trevenClass);
        }
        elm.html(jobtable);
        jobtable.find('tr').each(function() {
                    $(this).click(function() {
                                if (lastclicks != null) {
                                    lastclicks.find('td').removeClass("rowclick");
                                }
                                $(this).find('td').addClass("rowclick");
                                lastclicks = $(this);

                            });
                });
    }

    function loadtable(op) {

        if (op.url) {
            var url = op.url + op.pageSize + "/" + op.curPage;
            if (op.noPage) {
                url = op.url;
            }
            $.ajax({
                        url : url,
                        cache : false,
                        dataType : "json",
                        data : op.condition,
                        success : function(rs) {
                            if (op.noPage) {
                                loadtabledata(op, rs);
                            } else {
                                var list = rs.result;
                                var page = rs.pageVO;
                                loadtabledata(op, list);
                                if (op.noshowPage == null || !op.noshowPage) {
                                    if (page != null) {
                                        var pagedivem = elm;
                                        var pagediv = op.pagediv;
                                        if (pagediv != null) {
                                            pagedivem = $("#" + pagediv);
                                            pagedivem.html("");
                                        }
                                        pagedivem.loadPage(page, function(page) {
                                                    if (page != null) {
                                                        jQuery.extend(op, page);
                                                        loadtable(op);
                                                    }

                                                });
                                    }
                                }
                            }
                            op.loadBack && op.loadBack();
                        }
                    });
        } else {
            loadtabledata(op);
        }
    }

    loadtable(op);
    var mytable = {};
    (function(op) {
        mytable.reloadtable = function(conditon) {
            op.condition = conditon;
            op.curPage = 1;
            loadtable(op);
        };
    }(op));
    mytable.addRow = function() {
        var rd = {};
        addRow(rd, true);
    };
    mytable.getRecorddata = function() {
        return recorddata;
    };
    mytable.getAddData = function() {
        return addRecord;
    };
    mytable.deleteRecord = function(i) {
        recorddata = Portal.Common.ArrayRemove(recorddata, i);
        loadtabledata(op, recorddata);
    };
    mytable.getUpdata = function() {
        var batchvo = {};
        var adddata = [];
        var updata = [];
        for (var i = 0; i < recorddata.length; i++) {
            if (recorddata[i].addFlag) {
                adddata.push(recorddata[i]);
            }
            if (recorddata[i].upflag) {
                updata.push(recorddata[i]);
            }

        }
        batchvo.items2Create = adddata;
        batchvo.items2Update = updata;
        return batchvo;
    };

    return mytable;

};
$(Portal.Common.initHeader);

(function($) {
    var currentLanguage = '';
    var language = $('<span class="langueTarget"><div class="languageShow"></div><div class="languageHide"></div></span>');
    var showLanguage = language.find('.languageShow'), hideLanguage = language.find('.languageHide');
    var lang = {
        zh_CN : $('<span val="zh_CN" class="i18n" i18nKey="language.zh_CN"></span>')
        // ,en_US : $('<span val="en_US" class="i18n"
        // i18nKey="language.en_US"></span>')
    };
    showLanguage.bind("click", function() {
                language.toggleClass("on");
            });
    hideLanguage.bind("click", function() {
                changeLanguage($(this).find('span').attr('val'));
                language.toggleClass("on");
            });
    function changeLanguage(currentLang) {
        if (currentLang === 'zh_CN') {
            showLanguage.empty().append(lang.zh_CN);
            hideLanguage.empty().append(lang.en_US);
        } else {
            showLanguage.empty().append(lang.en_US);
            hideLanguage.empty().append(lang.zh_CN);
        }
        $("title[i18nKey],label[i18nKey],.i18n").i18nKey(currentLang);
    }

    var initLanguage = function(id) {
        $.ajax({
                    url : 'servlet/language?switchTo=zh_CN',
                    type : 'get',
                    async : false,
                    dataType : 'text',
                    success : function(data) {
                        currentLanguage = data;
                        changeLanguage(data);
                    }
                });

        $(".userInfo").append(language);
    };
    window.initLanguage = initLanguage;

    $.i18nCache = $.i18nCache || {};

    $.i18nKey = function(key, data) {
        if (key && $.i18nCache[key] && $.i18nCache[key][currentLanguage]) {
            var str = $.i18nCache[key][currentLanguage];
            // 处理参数
            if (str && data) {
                str = str.replace(/\{([^}]+)\}/img, function(str, val) {
                            return data[val];
                        });
            }
            return str;
        }
        return key;
    };

    $.fn.i18nKey = function(language) {
        $.ajax({
                    url : 'servlet/language',
                    type : 'get',
                    data : {
                        switchTo : language
                    },
                    async : false,
                    dataType : 'text',
                    success : function(data) {
                        currentLanguage = data;
                        language = data;
                    }
                });
        this.each(function(elem) {
                    var target = $(this);
                    var i18nKey = target.attr('i18nKey');
                    if (i18nKey) {
                        var txt = $.i18nKey(i18nKey);
                        if (txt) {
                            target.text(txt);
                        }
                    }
                });
        typeof(i18nKeyCallback) !== 'undefined' && i18nKeyCallback();
        return this;
    };
    var pageInit = function() {
        $("title[i18nKey],label[i18nKey],.i18n").i18nKey();
    };
    $(pageInit);

    $.jobFamilyIconCache = $.jobFamilyIconCache || {};

    $.jobFamilyIcon = function(jobFamily) {
        if (jobFamily && $.jobFamilyIconCache[jobFamily]) {
            return $.jobFamilyIconCache[jobFamily];
        }
        return '';
    };

}(jQuery));

// jsTemplate.js
// A simple and fast javascript template engine.
// Copyright (c) 2014 HongBo Yuan
// https://github.com/hbyuan/jsTemplate
// email:hongbo_yuan@foxmail.com
(function() {
    'use strict';
    // js模板引擎
    function JsTemplate(templateId, templateContent) {
        if (!templateId) {
            throw 'argument error.';
        }
        if (!(this instanceof JsTemplate)) {
            return new JsTemplate(templateId, templateContent);
        }
        this.template = JsTemplate.templateCache[templateId];
        if (!this.template) {
            if (templateContent) {
                this.template = JsTemplate.compile(templateContent);
                JsTemplate.templateCache[templateId] = this.template;
            } else {
                throw 'template error. templateId:' + templateId;
            }
        }
    }
    // 是否启用调试
    JsTemplate.isDebug = false;
    // 逻辑语法规则
    JsTemplate.ANALYZE = /<%([\s\S]+?)%>/gm;
    // 编译后模板缓存
    JsTemplate.templateCache = {};
    // 合并属性
    JsTemplate.mix = function(target, source) {
        var key = null;
        for (key in source) {
            if (source.hasOwnProperty(key)) {
                target[key] = source[key];
            }
        }
        return target;
    };
    // 编译模板
    JsTemplate.compile = function(templateStr) {
        var match, lastIdx = 0, tmpl = templateStr, funcStr = 'var $html = "";with($data){', appendFuncStr = function(content, isHtml) {
            if (isHtml) {
                if (!/^[\s]+$/.test(content)) {
                    funcStr += ('$html+="' + content.replace(/"/mg, '\\"') + '";\n');
                }
            } else {
                content = content.replace(/&gt;/mg, '>').replace(/&lt;/mg, '<');
                if (content.indexOf('=') === 0) {
                    funcStr += ('$html+=' + content.substring(1) + ';\n');
                } else {
                    funcStr += (content.replace(/"/mg, '\\"') + '\n');
                }
            }
        };
        if (JsTemplate.isDebug) {
            funcStr += 'debugger;';
        }
        funcStr += 'var include = function(id,includeData){return JsTemplate(id).render(JsTemplate.mix($data,includeData));};';
        if (!tmpl) {
            return null;
        }
        tmpl = tmpl.replace(/[\r\n\t]/img, ' ');
        while (match = JsTemplate.ANALYZE.exec(tmpl)) {
            appendFuncStr(tmpl.substring(lastIdx === 0 ? 0 : lastIdx, match.index), true);
            appendFuncStr(match[1], false);
            lastIdx = (match.index + match[0].length);
        }
        appendFuncStr(tmpl.substring(lastIdx), true);
        appendFuncStr('} return $html;', false);
        return new Function('$data', funcStr);
    };
    // 对象方法
    JsTemplate.prototype = {
        render : function(data) {
            if (this.template) {
                return this.template.call(data, data);
            }
        }
    };
    // 导出函数
    window.JsTemplate = JsTemplate;
    // 导出函数
    if (typeof exports !== 'undefined') {
        exports.JsTemplate = JsTemplate;
    }
    if (typeof window !== 'undefined') {
        window.JsTemplate = JsTemplate;
    }
}());

(function($) {
    var bannerTmpl = '<div class="topBanner"><%for(var i=0;i<data.length;i++){var d = data[i];%><div class="bannerImg" data-idx="<%=i%>"><a href="<%=d.adUrl?d.adUrl:"#"%>"><img src="<%=getImgUrl(d.pictureAtttachId)%>" width="1008px" height="206px" /></a></div><%}%></div>';
    var bannerBtnTmpl = '<div class="topBannerButton"><ul><%for(var j=0;j<data.length;j++){%><li data-idx="<%=j%>"><span></span></li><%}%></ul></div>';
    JsTemplate('topBanner', bannerTmpl + bannerBtnTmpl);
    var showBanner = function(dom) {
        var that = $(dom);
        var type = that.attr('data-type');
        if (!type) {
            return;
        }
        var currentShowIdx = -1;
        var maxShowIdx = 0;
        var showBanner = function() {
            currentShowIdx++;
            if (currentShowIdx >= maxShowIdx) {
                currentShowIdx = 0;
            }
            $(".topBannerButton li", that).removeClass('on');
            $(".topBannerButton li[data-idx='" + currentShowIdx + "']", that).addClass('on');

            $(".bannerImg", that).fadeOut();
            $(".bannerImg[data-idx='" + currentShowIdx + "']", that).fadeIn();

        };
        var intervalVal;
        $.ajax({
                    url : 'services/rec/portal/conf/ad/list',
                    data : {
                        adTypes : type
                    },
                    success : function(data) {
                        maxShowIdx = data.length;
                        that.html(JsTemplate('topBanner').render({
                                    data : data,
                                    getImgUrl : getImgUrl
                                }));
                        showBanner();
                        intervalVal = setInterval(showBanner, 5000);
                        $(".topBannerButton li", that).on('mouseover', function() {
                                    currentShowIdx = $(this).attr('data-idx') - 1;
                                    clearInterval(intervalVal);
                                    showBanner();
                                    intervalVal = setInterval(showBanner, 5000);
                                });
                    }
                });
    };
    $.fn.topBanner = function() {
        return this.each(function() {
                    showBanner(this);
                });
    };
}(jQuery));

(function($) {

    var listOpen = false;

    // 信息公告列表
    window.searchInfo = function(searchPageVO, infoVO) {
        if (!infoVO) {
            infoVO = searchInfo.infoVO;
        } else {
            searchInfo.infoVO = infoVO;
        }

        $(".i18n").i18nKey();
        if (!searchPageVO) {
            searchPageVO = {};
            searchPageVO.curPage = 1;
            searchPageVO.pageSize = 5;
        }
        var infoType = infoVO.infoType || '';
        var infoCategory = infoVO.infoCategory || '';
        if (!infoType || infoType == '' || !infoCategory || infoCategory == '') {
            return;
        }
        $.ajax({
                    url : 'services/rec/portal/conf/release/page/' + searchPageVO.pageSize + '/' + searchPageVO.curPage + '?infoType=' + infoType + '&infoCategory=' + infoCategory + '&c=' + new Date().getTime(),
                    type : 'GET',
                    success : function(dataResult) {
                        if (dataResult) {
                            var data = {};
                            data.result = dataResult.result;
                            data.infoType = infoType;
                            data.infoCategory = infoCategory;
                            var htm = JsTemplate("listContentTmp").render({
                                        data : data
                                    });
                            $("#listContent").html(htm);
                            $("#pager").html('');
                            $("#pager").loadPage(dataResult.pageVO, searchInfo);
                            $(".i18n").i18nKey();
                            listOpen = true;
                            $("#infoListDiv").show();
                            $(".pageItem>div").hide();
                            var windowHeight = $(window).height();
                            var minHeight = 660;
                            var divHeight = 500;
                            if (windowHeight < minHeight) {
                                divHeight = divHeight - (minHeight - windowHeight);
                                $('.listZone').css({
                                            'height' : divHeight + 'px',
                                            'min-height' : divHeight + 'px',
                                            'overflow' : 'auto'
                                        });
                            } else {
                                $('.listZone').css({
                                            'height' : '440px',
                                            'min-height' : '440px',
                                            'overflow' : 'auto'
                                        });
                            }
                            $('.introduceBox1').autoCenter();
                        }
                    }
                });
    };
    // 信息公告详细页面
    window.viewInfoDetail = function(infoId) {
        if (!infoId || infoId == '') {
            return;
        }
        $.ajax({
                    url : 'services/rec/portal/conf/release/find/' + infoId + '?c=' + new Date().getTime(),
                    type : 'GET',
                    success : function(data) {
                        if (data) {
                            $("#contentDetail").html(JsTemplate("contentDetailTmp").render({
                                        data : data
                                    }));
                            $(".i18n").i18nKey();
                            $("#infoListDiv").hide();
                            $("#infoDetailDiv").show();
                            $(".pageItem>div").hide();
                            $('.introduceBox1').autoCenter();
                            var windowHeight = $(window).height();
                            var minHeight = 545;
                            var divHeight = 300;
                            if (windowHeight < minHeight) {
                                divHeight = divHeight - (minHeight - windowHeight);
                                $('.CtnHig').css({
                                            'height' : divHeight + 'px',
                                            'min-height' : divHeight + 'px'
                                        });
                            }
                        }
                    }
                });
    };

    window.closeContentList = function() {
        $("#infoListDiv").hide();
        listOpen = false;
        $(".pageItem>div").show();
    };
    window.closeContentDetail = function() {
        $("#infoDetailDiv").hide();
        if (!listOpen) {
            $(".pageItem>div").show();
        } else {
            $("#infoListDiv").show();
            $('.introduceBox1').autoCenter();
        }
    };

    var init = function() {
        if (document.getElementById('listContentTmp') != null) {
            JsTemplate('listContentTmp', document.getElementById('listContentTmp').innerHTML);
        }
        if (document.getElementById('listContentTmp') != null) {
            JsTemplate('contentDetailTmp', document.getElementById('contentDetailTmp').innerHTML);
        }
    };
    $(init);

}(jQuery));

(function($) {
    $.fn.autoCenter = function() {
    	var offset = 10;
        return this.each(function() {
                    var elem = $(this);
                    var top = ($(window).height() - elem.height()) / 2;
                    if (top < 60) {
                        top = 60;
                    }
                    elem.css({
                                "position" : "relative",
                                "top" : (top+offset) + "px"
                            }).addClass('autoCenter');
                });
    };
    var init = function() {
        $(window).resize(function() {
                    $('.autoCenter').autoCenter();
                });
    };
    $(init);
}(jQuery));
