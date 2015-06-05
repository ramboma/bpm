/**
 * @cnName 日历控件
 * @enName calendar
 * @introduce
 */
define(["avalon",
    "text!./avalon.calendar.html",
    "css!./avalon.calendar.css"], function (avalon, sourceHTML) {
        var calendarTemplate = sourceHTML,
            firstYear = 1901,
            lastYear = 2050;

        var widget = avalon.ui.calendar = function (element, data, vmodels) {
            var options = data.calendarOptions,
                parseDate = options.parseDate,
                minDate = options.minDate,
                maxDate = options.maxDate,
                monthYearChangedBoth = false,
                years = [],
                calendar,
                month,
                day,
                year

            calendarTemplate = options.template = options.getTemplate(calendarTemplate, options)
            avalon.scan(element, vmodels)
            parseDate = parseDate.bind(options)
            minDate ? firstYear = minDate.getFullYear() : 0
            maxDate ? lastYear = maxDate.getFullYear() : 0
            if (avalon.type(options.years) === "array") {
                years = options.years
            } else {
                for (var i = firstYear; i <= lastYear; i++) {
                    years.push(i)
                }
            }
            initValue()

            var vmodel = avalon.define(data.calendarId, function (vm) {
                avalon.mix(vm, options)
                vm.loaded = false
                vm.events = []
                vm.weekNames = []
                vm.cellDates = new Array()
                vm.data = []
                vm.prevMonth = -1 //控制prev class是否禁用
                vm.nextMonth = -1 //控制next class是否禁用
                vm.month = month
                vm._month = month + 1
                vm.year = year
                vm.day = day
                vm.years = years
                vm.currentDate = cleanDate(new Date())
                // 切换到当月的上一月
                vm._prev = function (prevFlag, event) {
                    if (!prevFlag) {
                        return false
                    }
                    toggleMonth("prev")
                    event.stopPropagation()
                }
                // 切换到下一月
                vm._next = function (nextFlag, event) {
                    if (!nextFlag) {
                        return false
                    }
                    toggleMonth("next")
                    event.stopPropagation()
                }
                vm._selectDate = function(index, outerIndex, rowIndex, event){
                    var dayItem = vm.data[rowIndex]["rows"][outerIndex][index],
                        year = dayItem.year,
                        month = dayItem.month,
                        day = +dayItem.day
                    var _date = new Date(year, month, day)
                    vm.onSelectDay(_date)                  
                }

                vm.$init = function (continueScan) {
                    var elementPar = element.parentNode

                    calendar = avalon.parseHTML(calendarTemplate).firstChild
                    elementPar.insertBefore(calendar, element)
                    elementPar.insertBefore(element, calendar)
                    vmodel.weekNames = calendarHeader()

                    avalon.scan(calendar, [vmodel].concat(vmodels))
                    setTimeout(function () {
                        calendarDays(vmodel.month, vmodel.year)
                    }, 10)
                    if (typeof options.onInit === "function") {
                        options.onInit.call(element, vmodel, options, vmodels)
                    }
                }

                vm.$remove = function () {
                    var elementPar = element.parentNode,
                        eleParPar = elementPar.parentNode,
                        calendarPar = calendar.parentNode

                    calendar.innerHTML = calendar.textContent = ""
                    calendarPar.removeChild(calendar)
                    eleParPar.removeChild(elementPar)
                }
            })

            vmodel.$watch("month", function (month) {
                vmodel._month = month + 1
                vmodel.currentDate = new Date(vmodel.year, vmodel.month, vmodel.day)
                calendarDays(month, vmodel.year)
                vmodel.onChangeMonthYear(vmodel.year, month, vmodel)
            })
            vmodel.$watch("loaded", function (loaded) {
                if (loaded) {
                    for (var i = 0; i < vmodel.events.length; i++) {
                        var event = vmodel.events[i];
                        if (event === undefined) continue;
                        if (i >= vmodel.cellDates.length) break;
                        var m = vmodel.cellDates[i].row 
                        var n = vmodel.cellDates[i].day
                        vmodel.data[0].rows[m][n].event = event
                    }
                }
            })

            function initValue() {
                var today = cleanDate(new Date())

                year = today.getFullYear()
                month = today.getMonth()
                day = today.getDate()
            }

            function toggleMonth(operate) {
                var month = vmodel.month,
                    year = vmodel.year,
                    firstDayOfNextMonth

                if (operate === "next") {
                    month = month + 1
                } else {
                    month = month - 1
                }
                firstDayOfNextMonth = new Date(year, month, 1)
                firstDayMonth = firstDayOfNextMonth.getMonth()
                firstDayYear = firstDayOfNextMonth.getFullYear()
                if (firstDayYear != vmodel.year) {
                    monthYearChangedBoth = true
                    vmodel.year = firstDayYear
                    vmodel.month = firstDayMonth
                } else {
                    vmodel.month = firstDayMonth
                }

            }

            function calendarHeader() {
                var weekNames = [],
                    startDay = options.startDay
                for (var j = 0, w = options.dayNames; j < 7; j++) {
                    var n = (j + startDay) % 7
                    weekNames.push(w[n])
                }
                return weekNames
            }

            function calendarDate(cellDate, vmodel, dateMonth, dateYear, days, day) {
                var weekDay = cellDate.getDay(),
                    weekend = weekDay % 7 == 0 || weekDay % 7 == 6
                days.push({ day: day, month: dateMonth, year: dateYear, weekend: weekend, event: "" })
            }

            // 根据month、year得到要显示的日期数据
            function calendarDays(month, year) {
                var startDay = vmodel.startDay,
                    firstDayOfMonth = new Date(year, month, 1),
                    cellDate = new Date(year, month, 1 - (firstDayOfMonth.getDay() - startDay + 7) % 7),
                    cellDates = new Array(),
                    rows = [],
                    data = [],
                    days = [],
                    dateYear,
                    dateMonth,
                    day

                for (var m = 0; m < 6; m++) {
                    days = []

                    for (var n = 0; n < 7; n++) {
                        dateMonth = cellDate.getMonth()
                        dateYear = cellDate.getFullYear()
                        day = cellDate.getDate()
                        if (dateYear === year && dateMonth === month) {
                            calendarDate(cellDate, vmodel, dateMonth, dateYear, days, day)
                            cellDates[day] = { row: m, day: n }
                        } else {
                            days.push({ day: "", month: false, weekend: false, event: "" })
                        }
                        cellDate = new Date(cellDate.setDate(day + 1))
                    }
                    if (m === 5 && days[0].day === "")
                        continue
                    rows.push(days)
                }
                data.push({
                    year: year,
                    month: month,
                    rows: rows
                })
                vmodel.data = data
                vmodel.cellDates = cellDates
            }

            // 检验date
            function validateDate(date) {
                if (typeof date == "string") {
                    return parseDate(date)
                } else {
                    return date;
                }
            }

            return vmodel
        }
        widget.defaults = {
            dayNames: ['日', '一', '二', '三', '四', '五', '六'], //@interface 日期名列表，从周日开始，可以配置为["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
            startDay: 1, //@config 设置每一周的第一天是哪天，0代表Sunday，1代表Monday，依次类推, 默认从周一开始
            onChangeMonthYear: avalon.noop,
            onSelectDay: avalon.noop,
            /**
             * @config {Function} 将符合日期格式要求的字符串解析为date对象并返回，不符合格式的字符串返回null,用户可以根据自己需要自行配置解析过程
             * @param str {String} 要解析的日期字符串
             * @returns {Date} Date格式的日期
             */
            parseDate: function (str) {
                if (!str) {
                    return null
                }
                if (avalon.type(str) === "date") return str
                var separator = this.separator;
                var reg = "^(\\d{4})" + separator + "(\\d{1,2})" + separator + "(\\d{1,2})[\\s\\w\\W]*$";
                reg = new RegExp(reg);
                var x = str.match(reg);
                return x ? new Date(x[1], x[2] * 1 - 1, x[3]) : null;
            },
            getTemplate: function (str, options) {
                return str;
            }
        }

        function cleanDate(date) {
            date.setHours(0);
            date.setMinutes(0);
            date.setSeconds(0);
            date.setMilliseconds(0);
            return date;
        }

        return avalon
    })


