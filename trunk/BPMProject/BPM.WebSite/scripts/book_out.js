﻿$.extend(
    {
        Deal_Data: function (data) {
            var Ret = eval('(' + data + ')');
            var ctlg_json = Ret.Result;
            var Json_data = [];
            for (var i = 0; i < ctlg_json.length; i++) {
                var TempNode = { 'id': '', 'text': '' };
                TempNode.id = ctlg_json[i].catalogId;
                TempNode.text = ctlg_json[i].catalogName;
                Json_data.push(TempNode);
            }
            return Json_data;
        },
        Init_Page: function () {
            //获取图书信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getreturnbooks', p: '' },
                    success: function (data) {
                        alert(data);
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
            return;
        },
        Btn_Submit_Click: function (ev) {
            var Bookmng_In_Json = { Time: '', DocName: '', Author: '', Publisher: '', Source: '', Shelf: '' };

            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'submitlibrary', p: JSON.stringify(Objmng_In_Json) },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var Ret_id = Ret.Result;
                        $("#div_objmng_qrcode").empty();
                        $("#div_objmng_qrcode").qrcode({
                            render: "table",
                            width: 200,
                            height: 200,
                            text: Ret_id
                        });
                        alert("保存成功,请打印二维码!");
                    }
                });
        },
        Btn_Cancel_Click: function (ev) {
            location.reload();
            return;
        },
        Btn_bookmng_scan_click: function (ev) {
            alert("请准备打印机");
            return;
        }
    });
$(document).ready(function () {
    var MyDate = new Date();
    $("#tb_bookmng_time").text(MyDate.toLocaleString());
    $("#btn_bookmng_submit").click($.Btn_Submit_Click);
    $("#btn_bookmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_bookmng_scan").click($.Btn_bookmng_scan_click);
    $.Init_Page();
});
