var Submit_Flag = 0;
var Cur_Selected_Node = null;
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
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getequiementlist', p: '' },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_devmng_name").combotree('loadData', ctlg_json);
                        return;
                    }
                });
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'assetlibrary', m: 'providermng', p: 'zt' },
                success: function (data) {
                $("#sl_devmng_changetype").combobox('loadData', $.Deal_Data(data));
                return;
                }
            });
            return;
        },
        Get_Device_Detail: function (node)
        {
            /*根据节点信息写入标签*/
            $("#tb_devmng_factory").text(node.Node.FactoryName);
            $("#tb_devmng_model").text(node.Node.Model);
            $("#tb_devmng_spec").text(node.Node.Standard);
            //获取来源的类别号
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.Source },
                success: function (data) {
                var Ret = eval('(' + data + ')');
                var ctlg_json = Ret.Result;
                $("#tb_devmng_source").text(ctlg_json.catalogName);
                return;
            },
            error: function (data) {
                alert(data);
            }
            });
            $("#tb_devmng_price").text(node.Node.Price);
            $("#tb_devmng_producttime").text(node.Node.ProductTime);
            /*获取部门的名称和保管人的名称*/
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'sysconfig', m: 'getemplinfobyid', p: node.Node.KeepEmpl},
                success: function (data) {
                    var Ret = eval('(' + data + ')');
                    var ctlg_json = Ret.Result;
                    if (ctlg_json == null)
                    {
                        return;
                    }
                    $("#tb_devmng_owner").text(ctlg_json.EmplName);
                    return;
                },
                error: function (data) {
                    alert(data);
                }
            });
            $.ajax(
            {
                url: '/Route/LibraryHandler.ashx',
                type: 'POST',
                data: { c: 'sysconfig', m: 'getdeptinfobyid', p: node.Node.KeepDept},
                success: function (data) {
                var Ret = eval('(' + data + ')');
                var ctlg_json = Ret.Result;
                if (ctlg_json==null)
                {
                    return;
                }
                $("#tb_devmng_dept").text(ctlg_json.DeptName);
                return;
                },
                error: function (data) {
                alert(data);
                }
            });
            $("#tb_devmng_producttime").text(node.Node.ProductTime);
            Cur_Selected_Node = node;
            return;
        },
        Btn_Submit_Click: function (ev)
        {
            var DevMng_Json = {time:"",equipmentId:'',recordType:'',applyId:'0',approveId:'0',relativeTask:'0',managerId:'0'};
            if ((Cur_Selected_Node != null) && ($("#sl_devmng_changetype").combobox('getValue') != '')) {
                DevMng_Json.time = new Date();
                DevMng_Json.equipmentId = Cur_Selected_Node.Node.id;
                DevMng_Json.recordType = $("#sl_devmng_changetype").combobox('getValue');

                $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'saveequipmentlog', p: JSON.stringify(DevMng_Json) },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           if (Ret.Code == 1) {
                               alert("保存成功!");
                               location.reload();
                           }
                       }
                   });
                return;
            }
        },
        Btn_Cancel_Click: function(ev) {
            location.reload();
            return;
        },
        Btn_devmng_scan_click:function(ev){
            $("#div_devmng_qrcode").empty();
            $("#div_devmng_qrcode").qrcode({
                render	: "table",
                width:200,
                height:200,
                text	: "hello world"
            });
            return;
        }
    });
$(document).ready(function() {
    var MyDate = new Date();
    $("#tb_devmng_change_time").text(MyDate.toLocaleString());
    $("#btn_devmng_submit").click($.Btn_Submit_Click);
    $("#btn_devmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_devmng_scan").click($.Btn_devmng_scan_click);
    $("#tb_devmng_name").combotree({ onSelect: function (node) { $.Get_Device_Detail(node) } });
    $.Init_Page();
});
