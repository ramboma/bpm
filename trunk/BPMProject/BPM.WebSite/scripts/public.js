
function getResult(data) {
            var str = "var _getResultObject=" + data + ";";
            eval(str);
    return _getResultObject;
}
//根据QueryString参数名称获取值
function getQueryStringByName(name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}
