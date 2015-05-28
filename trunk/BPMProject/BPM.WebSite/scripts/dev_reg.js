$.extend(
    {
        Deal_Data:function(data)
        {
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
        //获取生产厂家信息
        Init_Page: function ()
        {
            //获取设备来源信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'ly' },
                    success: function (data)
                    {
                        $('#sl_devmng_source').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data)
                    {
                        //alert(data);
                    }
                }
                );
            return;
        },
        Btn_Submit_Click: function(ev) {
            var Devmng_In_Json = { time: '', name: '', factory: '', model: '', spec: '', source: '', price: '', dept: '', owner: '', producttime: '', status: '', docname: '' };
            Devmng_In_Json.time = new Date();
            Devmng_In_Json.name = $("#tb_devmng_name").textbox("getValue");
            Devmng_In_Json.factory = $("#tb_devmng_factory").textbox("getValue");
            Devmng_In_Json.model = $("#tb_devmng_model").textbox("getValue");
            Devmng_In_Json.spec = $("#tb_devmng_spec").textbox("getValue");
            Devmng_In_Json.spec = $("#tb_devmng_spec").textbox("getValue");
            Devmng_In_Json.source = $("#sl_devmng_source").combobox("getValue");
            Devmng_In_Json.price = $("#tb_devmng_price").textbox("getValue");
            Devmng_In_Json.dept = $("#tb_devmng_dept").textbox("getValue");
            Devmng_In_Json.owner = $("#tb_devmng_owner").textbox("getValue");
            Devmng_In_Json.producttime = $("#tb_devmng_producttime").datebox("getValue");
            Devmng_In_Json.status = $("#tb_devmng_status").combobox("getValue");
            Devmng_In_Json.docname = $("#file_upload").val();
            
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'saveequiement', p: JSON.stringify(Devmng_In_Json) },
                    success: function (data) {
                    alert("保存成功！");
                    location.reload();
                }
            });
            return;
        },
        Btn_Cancel_Click: function(ev) {
            location.reload();
            return;
        },
        Btn_devmng_build_click:function(ev){
            $("#div_devmng_qrcode").empty();
            $("#div_devmng_qrcode").qrcode({
                render	: "table",
                width:200,
                height:200,
                text	: "hello world"
            });
            return;
        },
        Btn_devmng_print_click:function(ev){
           alert("请准备打印机");
            return;
        }
    });
$(document).ready(function() {
    var MyDate = new Date();
    $("#tb_devmng_reg_time").text(MyDate.toLocaleString());
    $("#btn_devmng_submit").click($.Btn_Submit_Click);
    $("#btn_devmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_devmng_print").click($.Btn_devmng_print_click);
    $.Init_Page();
});
