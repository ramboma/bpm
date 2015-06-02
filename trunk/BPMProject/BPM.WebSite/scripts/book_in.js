var SubMit_Flag = 0;
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
            //获取图书来源信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'ly' },
                    success: function (data) {
                        $('#sl_bookmng_source').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
            //获取图书来源信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'wdlx' },
                    success: function (data) {
                        $('#sl_bookmng_type').combobox('loadData', $.Deal_Data(data));
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
                        $('#sl_bookmng_readlevel').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
        );
            return;
        },
        Btn_Submit_Click: function (ev) {
            if (SubMit_Flag == 1)
            {
                return;
            }
            var Bookmng_In_Json = { time: '', bookName: '',doctype:"",author: '', publisher: '', source: '', price: '', readLevel: '', keyWord: '', content: '',bookflag:'0', location: '', deleteFlag: '0' };
            Bookmng_In_Json.bookName = $("#tb_bookmng_name").val();
            Bookmng_In_Json.author = $("#tb_bookmng_author").val();
            Bookmng_In_Json.doctype = $("#sl_bookmng_type").combobox('getValue');
            Bookmng_In_Json.publisher = $("#tb_bookmng_publisher").val();
            Bookmng_In_Json.source = $("#sl_bookmng_source").combobox('getValue');
            Bookmng_In_Json.price = $("#tb_bookmng_price").val();
            Bookmng_In_Json.readLevel = $("#sl_bookmng_readlevel").combobox('getValue');
            Bookmng_In_Json.keyWord = $("#tb_bookmng_keyword").val();
            Bookmng_In_Json.content = $("#ta_bookmng_introduce").val();
            Bookmng_In_Json.location = $("#tb_bookmng_store").val();
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'submitlibrary', p: JSON.stringify(Bookmng_In_Json) },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var Ret_id = Ret.Result;
                        $("#div_bookmng_qrcode").empty();
                        $("#div_bookmng_qrcode").qrcode({
                            render: "table",
                            width: 200,
                            height: 200,
                            text: Ret_id.toString()
                        });
                        SubMit_Flag = 1;
                        alert("保存成功,请打印二维码!");
                    }
                });
        },
        Btn_Cancel_Click: function (ev) {
            location.reload();
            return;
        },
        Btn_bookmng_print_click: function (ev) {
            alert("请准备打印机");
            return;
        }
    });
$(document).ready(function () {
    var MyDate = new Date();
    $("#tb_bookmng_time").text(MyDate.toLocaleString());
    $("#btn_bookmng_submit").click($.Btn_Submit_Click);
    $("#btn_bookmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_bookmng_print").click($.Btn_bookmng_print_click);
    $.Init_Page();
});
