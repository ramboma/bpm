﻿/**
 * @cnName 分页组件
 * @enName pager
 * @introduce
 *  <p> 分页组件 用于各种列表与表格的下方 。</p>
 */

define(["avalon"], function (avalon) {
    var template = "<div class=\"row-fluid\"><div ms-if=\"showTitle\" class=\"span4\"><div class=\"dataTables_info\" id=\"sample_1_info\">符合条件的记录有{{totalItems}}条</div></div><div class=\"span8\"><div class=\"dataTables_paginate paging_bootstrap pagination\"><ul onselectstart=\"return false;\" unselectable=\"on\" ms-visible=\"totalPages>1\"><li class=\"prev\" ms-class=\"disabled:currentPage==1\" ms-if=\"isShowPrev()\" ms-title=\"getTitle('prev')\"><a href=\"#\" ms-click=\"jumpPage($event,'prev')\" ms-text=\"prevText\"></a></li><li ms-visible=\"firstPage!==1\" ms-title=\"getTitle('first', currentPage)\" ms-class-active=\"currentPage == 1\"><a href=\"#\" ms-click=\"jumpPage($event,'first')\" ms-hover=\"oni-state-hover\">1</a></li><li ms-if=\"showFirstOmit\"><a href=\"#\" ms-text=\"ellipseText\"></a></li><li ms-repeat=\"pages\" ms-title=\"getTitle(el, currentPage)\" ms-class-active=\"el == currentPage\"><a href=\"#\" ms-text=\"el\" ms-hover=\"oni-state-hover\" ms-click=\"jumpPage($event,el)\"></a></li><li ms-if=\"showLastOmit\"><a href=\"#\" ms-text=\"ellipseText\"></a></li><li ms-visible=\"lastPage!==totalPages\" ms-title=\"getTitle('last', currentPage, totalPages)\"><a href=\"#\" ms-hover=\"oni-state-hover\" ms-click=\"jumpPage($event,'last')\" ms-text=\"totalPages\"></a></li><li class=\"next\" ms-if=\"isShowNext()\" ms-title=\"getTitle('next')\" ms-class=\"next disabled:currentPage==totalPages\"><a href=\"#\" ms-text=\"nextText\" ms-click=\"jumpPage($event,'next')\"></a></li><li><p class=\"pull-left\">转到<input type=\"text\" ms-duplex=\"_currentPage\" data-duplex-event=\"change\" ms-keyup=\"changeCurrentPage\" class=\"mini\" style=\"width: 20px;\"></p><a class=\"btn\" ms-click=\"changeCurrentPage\" style=\"border: none; background: #ddd;\">GO</a></li></ul></div></div></div>"
    var widget = avalon.ui.pager = function (element, data, vmodels) {
        var options = data.pagerOptions
        var pageOptions = options.options
        if (Array.isArray(pageOptions)) {
            options.options = pageOptions.map(function (el) {
                var obj = {}
                switch (typeof el) {
                    case "number":
                    case "string":
                        obj.value = el
                        obj.text = el
                        return obj
                    case "object":
                        return el
                }
            })
        } else {
            options.options = []
        }
        if (vmodels.cb) {
            template = template.replace(/ms-title/g, "ms-attr-title")
        }
        //方便用户对原始模板进行修改,提高制定性
        options.template = options.getTemplate(template, options)
        options._currentPage = options.currentPage
        var vmodel = avalon.define(data.pagerId, function (vm) {
            avalon.mix(vm, options)
            vm.widgetElement = element
            vm.$skipArray = ["showPages", "widgetElement", "template", "ellipseText", "alwaysShowPrev", "alwaysShowNext"]
            //这些属性不被监控
            vm.$init = function (continueScan) {
                var pageHTML = options.template
                element.style.display = "none"
                setTimeout(function () {
                    element.innerHTML = pageHTML
                    element.style.display = "block"
                    if (continueScan) {
                        continueScan()
                    } else {
                        avalon.log("avalon请尽快升到1.3.7+")
                        avalon.scan(element, [vmodel].concat(vmodels))
                        if (typeof options.onInit === "function") {
                            options.onInit.call(element, vmodel, options, vmodels)
                        }
                    }
                }, 100)
            }
            vm.$remove = function () {
                element.innerHTML = element.textContent = ""
            }
            vm.jumpPage = function (event, page) {
                event.preventDefault()
                if (page !== vm.currentPage) {
                    switch (page) {
                        case "first":
                            vm.currentPage = 1
                            break
                        case "last":
                            vm.currentPage = vm.totalPages
                            break
                        case "next":
                            vm.currentPage++
                            if (vm.currentPage > vm.totalPages) {
                                vm.currentPage = vm.totalPages
                            }
                            break
                        case "prev":
                            vm.currentPage--
                            if (vm.currentPage < 1) {
                                vm.currentPage = 1
                            }
                            break
                        default:
                            vm.currentPage = page
                            break
                    }
                    if (this.className.indexOf("state-disabled") === -1) {
                        vm.onJump.call(element, event, vm)
                        efficientChangePages(vm.pages, getPages(vm))
                    }
                }
            }
            vm.$watch("totalItems", function () {
                efficientChangePages(vm.pages, getPages(vm))
            })
            vm.$watch("perPages", function (a) {
                vm.currentPage = 1
                efficientChangePages(vm.pages, getPages(vm))
            })
            vm.$watch("currentPage", function (a) {
                if (a === 0) a = 1;
                vmodel._currentPage = a
                efficientChangePages(vm.pages, getPages(vm))
            })
            vm.isShowPrev = function () {
                var a = vm.alwaysShowPrev;
                var b = vm.firstPage
                return a || b !== 1
            }
            vm.isShowNext = function () {
                var a = vm.alwaysShowNext
                var b = vm.lastPage
                var c = vm.totalPages
                return a || b !== c
            }

            vm.changeCurrentPage = function (e, value) {
                if (e.type === "keyup") {
                    value = this.value
                    if (e.keyCode !== 13)
                        return
                } else {
                    value = vmodel._currentPage
                }
                value = parseInt(value, 10) || 1
                if (value > vmodel.totalPages || value < 1)
                    return
                //currentPage需要转换为Number类型 fix lb1064@qq.com
                vmodel.currentPage = value
                vmodel.pages = getPages(vmodel)
                vmodel.onJump.call(element, e, vm);
            }
            vm.pages = []
            vm.getPages = getPages
        })
        vmodel.pages = getPages(vmodel)

        return vmodel
    }
    //vmodel.pages = getPages(vmodel) 会波及一些其他没有改动的元素节点,现在只做个别元素的添加删除操作
    function efficientChangePages(aaa, bbb) {
        var obj = {}
        for (var i = 0, an = aaa.length; i < an; i++) {
            var el = aaa[i]
            obj[el] = { action: "del", el: el }
        }
        for (var i = 0, bn = bbb.length; i < bn; i++) {
            var el = bbb[i]
            if (obj[el]) {
                obj[el] = { action: "retain", el: el }
            } else {
                obj[el] = { action: "add", el: el }
            }
        }
        var scripts = []
        for (var i in obj) {
            scripts.push({
                action: obj[i].action,
                el: obj[i].el
            })
        }
        scripts.sort(function (a, b) {
            return a.el - b.el
        })
        scripts.forEach(function (el, index) {
            el.index = index
        })
        //添加添加
        var reverse = []
        for (var i = 0, el; el = scripts[i++];) {
            switch (el.action) {
                case "add":
                    aaa.splice(el.index, 0, el.el)
                    break;
                case "del":
                    reverse.unshift(el)
                    break;
            }
        }
        //再删除
        for (var i = 0, el; el = reverse[i++];) {
            aaa.splice(el.index, 1)
        }

    }
    widget.defaults = {
        perPages: 15, //@config {Number} 每页包含多少条目
        showPages: 3, //@config {Number} 中间部分一共要显示多少页(如果两边出现省略号,即它们之间的页数) 
        currentPage: 1, //@config {Number} 当前选中的页面 (按照人们日常习惯,是从1开始)，它会被高亮 
        _currentPage: 1, //@config {Number}  跳转台中的输入框显示的数字，它默认与currentPage一致
        totalItems: 0, //@config {Number} 总条目数
        totalPages: 0, //@config {Number} 总页数,通过Math.ceil(vm.totalItems / vm.perPages)求得
        pages: [], //@config {Array} 要显示的页面组成的数字数组，如[1,2,3,4,5,6,7]
        nextText: "下一页 →", //@config {String} “下一页”分页按钮上显示的文字 
        prevText: "← 上一页", //@config {String} “上一页”分页按钮上显示的文字 
        ellipseText: "…", //@config {String} 省略的页数用什么文字表示 
        firstPage: 0, //@config {Number} 当前可显示的最小页码，不能小于1
        lastPage: 0, //@config {Number} 当前可显示的最大页码，不能大于totalPages
        alwaysShowNext: true, //@config {Boolean} 总是显示向后按钮
        alwaysShowPrev: true, //@config {Boolean} 总是显示向前按钮
        showFirstOmit: false,
        showLastOmit: false,
        showJumper: true, //是否显示输入跳转台
        showTitle: true, // 是否显示头部
        /*
         * @config {Function} 用于重写模板的函数 
         * @param {String} tmpl
         * @param {Object} opts
         * @returns {String}
         */
        getTemplate: function (tmpl, opts) {
            return tmpl
        },
        options: [], // @config {Array}数字数组或字符串数组或对象数组,但都转换为对象数组,每个对象都应包含text,value两个属性, 用于决定每页有多少页(看avalon.pager.ex3.html) 
        /**
         * @config {Function} 页面跳转时触发的函数,如果当前链接处于不可以点状态(oni-state-disabled),是不会触发的
         * @param {Event} e
         * @param {Number} page  当前页码
         */
        onJump: function (e, page) {
        },
        /**
         * @config {Function} 获取页码上的title的函数
         * @param {String|Number} a 当前页码的类型，如first, prev, next, last, 1, 2, 3
         * @param {Number} currentPage 当前页码
         * @param {Number} totalPages 最大页码
         * @returns {String}
         */
        getTitle: function (a, currentPage, totalPages) {
            switch (a) {
                case "first":
                    if (currentPage == 1) {
                        return "当前页"
                    }
                    return "跳转到第一页"
                case "prev":
                    return "跳转到上一页"
                case "next":
                    return "跳转到下一页"
                case "last":
                    if (currentPage == totalPages) {
                        return "当前页"
                    }
                    return "跳转到最后一页"
                default:
                    if (a === currentPage) {
                        return "当前页"
                    }
                    return "跳转到第" + a + "页"
            }
        }
    }

    function getPages(vm) {
        var c = vm.currentPage, max = Math.ceil(vm.totalItems / vm.perPages), pages = [], s = vm.showPages,
                left = c, right = c
        //一共有p页，要显示s个页面
        vm.totalPages = max
        if (max <= s) {
            for (var i = 1; i <= max; i++) {
                pages.push(i)
            }
        } else {
            pages.push(c)
            while (true) {
                if (pages.length >= s) {
                    break
                }
                if (left > 1) {//在日常生活是以1开始的
                    pages.unshift(--left)
                }
                if (pages.length >= s) {
                    break
                }
                if (right < max) {
                    pages.push(++right)
                }
            }
        }
        vm.firstPage = pages[0] || 1
        vm.lastPage = pages[pages.length - 1] || 1
        vm.showFirstOmit = vm.firstPage > 2
        vm.showLastOmit = vm.lastPage < max - 1
        return pages//[0,1,2,3,4,5,6]
    }
    return avalon
})
/**
 * @other
 * <p>pager 组件有一个重要的jumpPage方法，用于决定它的跳转方式。它有两个参数，第一个事件对象，第二个是跳转方式，见源码：</p>
 ```javascript
 vm.jumpPage = function(event, page) {
 event.preventDefault()
 if (page !== vm.currentPage) {
 switch (page) {
 case "first":
 vm.currentPage = 1
 break
 case "last":
 vm.currentPage = vm.totalPages
 break
 case "next":
 vm.currentPage++
 if (vm.currentPage > vm.totalPages) {
 vm.currentPage = vm.totalPages
 }
 break
 case "prev":
 vm.currentPage--
 if (vm.currentPage < 1) {
 vm.currentPage = 1
 }
 break
 default:
 vm.currentPage = page
 break
 }
 vm.onJump.call(element, event, vm)
 efficientChangePages(vm.pages, getPages(vm))
 }
 }
 ```
 */

/**
 *  @links
 [显示跳转台](avalon.pager.ex1.html)
 [指定回调onJump](avalon.pager.ex2.html)
 [改变每页显示的数量](avalon.pager.ex3.html)
 [指定上一页,下一页的文本](avalon.pager.ex4.html)
 [通过左右方向键或滚轮改变页码](avalon.pager.ex5.html)
 [总是显示上一页与下一页按钮](avalon.pager.ex6.html)
 * 
 */
//http://luis-almeida.github.io/jPages/defaults.html
//http://gist.corp.qunar.com/jifeng.yao/gist/demos/pager/pager.html

