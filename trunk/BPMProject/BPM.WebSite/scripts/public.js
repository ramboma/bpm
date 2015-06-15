$.extend(
    {
        Get_Request_Result: function (data) {
            var Request_Ret = {};
            var Ret = eval('(' + data + ')');
            Request_Ret.Result = Ret.Result;
            Request_Ret.Code = Ret.Code;
            Request_Ret.Message = Ret.Message;
            return Request_Ret;
        },
        toUtf8: function (str) {
            var out, i, len, c;
            out = "";
            len = str.length;
            for (i = 0; i < len; i++) {
                c = str.charCodeAt(i);
                if ((c >= 0x0001) && (c <= 0x007f)) {
                    out = out + str.charAt(i);
                } else if (c > 0x07ff) {
                    out += String.fromCharCode(0xe0 | ((c >> 12) & 0x0f));
                    out += String.fromCharCode(0x80 | ((c >> 6) & 0x3f));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3f));
                }
                else {
                    out += String.fromCharCode(0xc0 | ((c >> 6) & 0x1f));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3f));
                }
            }
            return out;
        }
    });
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
