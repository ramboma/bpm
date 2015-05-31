var Submit_Flag = 0;
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
        Save_Dev_Info:function(docFileName)
        {
            var Devmng_In_Json = {
                equipmentName: '', factoryName: '', salerName: '', model: '', standard: '', source: '', price: '',
                updateTime: '',productTime: '', equipmentStatus: '', departMent: '', docPath: '', hasDelete: '',keeper:'' };
            Devmng_In_Json.updateTime = new Date();
            Devmng_In_Json.equipmentName = $("#tb_devmng_name").textbox("getValue");
            Devmng_In_Json.factoryName = $("#tb_devmng_factory").textbox("getValue");
            Devmng_In_Json.salerName = $("#tb_devmng_saler").textbox("getValue");
            Devmng_In_Json.model = $("#tb_devmng_model").textbox("getValue");
            Devmng_In_Json.standard = $("#tb_devmng_spec").textbox("getValue");
            Devmng_In_Json.source = $("#sl_devmng_source").combobox("getValue");
            Devmng_In_Json.price = $("#tb_devmng_price").textbox("getValue");
            Devmng_In_Json.productTime = $("#tb_devmng_producttime").datebox("getValue");
            Devmng_In_Json.departMent = $("#tb_devmng_dept").textbox("getValue");
            Devmng_In_Json.docPath = docFileName;
            Devmng_In_Json.keeper = $("#tb_devmng_owner").textbox("getValue");
            alert(JSON.stringify(Devmng_In_Json));
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'assetlibrary', m: 'saveequiement', p: JSON.stringify(Devmng_In_Json) },
                success: function (data)
                {
                    Submit_Flag = 1;
                    $("#div_devmng_qrcode").empty();
                    $("#div_devmng_qrcode").qrcode({
                        render: "table",
                        width: 200,
                        height: 200,
                        text: "hello world"
                    });
                    alert("����ɹ���,���ӡ��ά�룡");
                }
            });
            return;
        },
        //��ȡ����������Ϣ
        Init_Page: function ()
        {
            //��ȡ�豸��Դ��Ϣ
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
        Btn_Submit_Click: function (ev) {
            if (Submit_Flag == 1)
            {
                return;
            }
            $("#frm_fileupload").ajaxSubmit(
                {
                    success: function (data)
                    {
                        //�ϴ��ɹ������ύ����������
                        var Ret_Result = eval('(' + data + ')');
                        var Ret_FileName;
                        if (Ret_Result.Code == 1)
                        {
                            Ret_FileName = Ret_Result.Result;
                            $.Save_Dev_Info(Ret_FileName);
                        }
                        else
                        {
                            alert("��ѡ���������ļ���");
                        }
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
           alert("��׼����ӡ��");
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
