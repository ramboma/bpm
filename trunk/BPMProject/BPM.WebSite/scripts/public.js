function getResult(data) {
            var str = "var _getResultObject=" + data + ";";
            eval(str);
    return _getResultObject;
}
