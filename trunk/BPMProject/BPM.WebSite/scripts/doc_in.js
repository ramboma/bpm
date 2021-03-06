﻿var SubMit_Flag = 0;
var Upload_FileName = "";
$.extend(
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
            //获取文档类型信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'wdlx' },
                    success: function (data) {
                        $('#sl_docmng_type').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
            //获取图书借阅权限信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'qx' },
                    success: function (data) {
                        $('#sl_docmng_readlevel').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
        );
            return;
        },
        Btn_Submit_Click: function (ev) {
            if (SubMit_Flag == 1) {
                return;
            }
            var Docmng_In_Json = { time: '', bookName: '', doctype: "", author: '', publisher: '', source: '', price: '0', readLevel: '', keyWord: '', content: '', bookflag: '1', location: '', deleteFlag: '0' };
            Docmng_In_Json.time = new Date();
            Docmng_In_Json.bookName = $("#tb_docmng_name").val();
            Docmng_In_Json.author = $("#tb_docmng_author").val();
            Docmng_In_Json.doctype = $("#sl_docmng_type").combobox('getValue');
            Docmng_In_Json.publisher = $("#tb_docmng_publisher").val();
            Docmng_In_Json.readLevel = $("#sl_docmng_readlevel").combobox('getValue');
            Docmng_In_Json.keyWord = $("#tb_docmng_keyword").val();
            Docmng_In_Json.content = $("#ta_docmng_introduce").val();
            //先提交文件然后保存数据库相关信息
            Docmng_In_Json.location = Upload_FileName;
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'savebook', p: JSON.stringify(Docmng_In_Json) },
                    success: function (data)
                    {
                        var Ret = eval('(' + data + ')');
                        var Ret_id = Ret.Result;
                        location.reload();
                    }
                });
        },
        Btn_Cancel_Click: function (ev) {
            location.reload();
            return;
        },
        Btn_Upload_Click: function (ev) {
            $("#frm_fileupload").ajaxSubmit(
            {
                success: function (data) {
                    //上传成功后，再提交其它的数据
                    var Ret_Result = eval('(' + data + ')');
                    if (Ret_Result.Code == 1) {
                        Upload_FileName = Ret_Result.Result;
                        alert("文件上传成功！");
                    }
                }
            });
            return;
        },
    });
$(document).ready(function () {
    var MyDate = new Date();
    $("#tb_docmng_time").text(MyDate.toLocaleString());
    $("#btn_docmng_submit").click($.Btn_Submit_Click);
    $("#btn_docmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_docmng_upload").click($.Btn_Upload_Click);
    $.Init_Page();
});
