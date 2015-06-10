var Submit_Flag = 0;
var Upload_FileName = "";
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
        Deal_Empl_Data: function (data) {
            var Ret = eval('(' + data + ')');
            var ctlg_json = Ret.Result;
            var Json_data = [];
            for (var i = 0; i < ctlg_json.length; i++) {
                var TempNode = { 'id': '', 'text': '' };
                TempNode.id = ctlg_json[i].EmplID;
                TempNode.text = ctlg_json[i].EmplName;
                Json_data.push(TempNode);
            }
            return Json_data;
        },
        Save_Dev_Info:function(docFileName)
        {
            var Devmng_In_Json = {
                equipmentName: '', factoryName: '', salerName: '', model: '', standard: '', source: '', price: '',
                updateTime: '',productTime: '', equipmentStatus: '', departMent: '', docPath: '', hasDelete: '0',keeper:'' };
            Devmng_In_Json.updateTime = new Date();
            Devmng_In_Json.equipmentName = $("#tb_devmng_name").textbox("getValue");
            Devmng_In_Json.factoryName = $("#tb_devmng_factory").textbox("getValue");
            Devmng_In_Json.salerName = $("#tb_devmng_saler").textbox("getValue");
            Devmng_In_Json.model = $("#tb_devmng_model").textbox("getValue");
            Devmng_In_Json.standard = $("#tb_devmng_spec").textbox("getValue");
            Devmng_In_Json.source = $("#sl_devmng_source").combobox("getValue");
            Devmng_In_Json.price = $("#tb_devmng_price").textbox("getValue");
            Devmng_In_Json.productTime = $("#tb_devmng_producttime").datebox("getValue");
            Devmng_In_Json.departMent = $("#sl_devmng_dept").combobox("getValue");
            Devmng_In_Json.docPath = docFileName;
            Devmng_In_Json.keeper = $("#sl_devmng_owner").combobox("getValue");
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'assetlibrary', m: 'saveequipment', p: JSON.stringify(Devmng_In_Json) },
                success: function (data)
                {
                    var Ret_Result = eval('(' + data + ')');
                    Submit_Flag = 1;
                    $("#div_devmng_qrcode").empty();
                    $("#div_devmng_qrcode").qrcode({
                        render: "table",
                        width: 200,
                        height: 200,
                        text: Ret_Result.Result.toString()
                    });
                    alert("保存成功！,请打印二维码！");
                }
            });
            return;
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
                //获取部门信息
                $.ajax(
                       {
                           url: '/Route/LibraryHandler.ashx',
                           type: 'POST',
                           data: { c: 'sysconfig', m: 'getalldeptlist', p: '' },
                           success: function (data) {
                               var Ret = eval('(' + data + ')');
                               var ctlg_json = Ret.Result;
                               if (ctlg_json == null) {
                                   return;
                               }
                               $("#sl_devmng_dept").combobox('loadData', ctlg_json);
                           },
                           error: function (data) {
                               alert(data);
                           }
                       }
                 );
                //获取人员信息
                $.ajax(
                       {
                           url: '/Route/LibraryHandler.ashx',
                           type: 'POST',
                           data: { c: 'sysconfig', m: 'getallemplyeeinfo', p: '' },
                           success: function (data) {
                               $("#sl_devmng_owner").combobox('loadData', $.Deal_Empl_Data(data));
                           },
                           error: function (data) {
                               alert(data);
                           }
                       }
                 );
            return;
        },
        Btn_Submit_Click: function (ev) {
            if (Submit_Flag == 1)
            {
                return;
            }
            $.Save_Dev_Info(Upload_FileName);
            return;
        },
        Btn_Cancel_Click: function(ev) {
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
    $("#btn_devmng_upload").click($.Btn_Upload_Click);
    $("#btn_devmng_print").click($.Btn_devmng_print_click);
    $.Init_Page();
});
