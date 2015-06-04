var Submit_Flag = 0;
var Cur_Selected_Node = new Object();
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
        Get_Product_Detail: function (node) {
            var str_id = node.id.toString();
            if (str_id.length < 12) {
                $("#tb_objmng_unit").text("");
                $("#tb_objmng_model").text("");
                $("#tb_objmng_spec").text("");
                $("#tb_objmng_price").text("");
                $("#tb_objmng_factory").text("");
                $("#tb_objmng_saler").text("");
                $("#tb_objmng_amount").numberbox("setValue", 0);
                $("#tb_objmng_total").text("");
                return;
            }
            $("#tb_objmng_unit").text(node.Node.quantityUnit);
            $("#tb_objmng_model").text(node.Node.model);
            $("#tb_objmng_spec").text(node.Node.standard);
            $("#tb_objmng_price").text(node.Node.price);
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.factoryId },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_objmng_factory").text(ctlg_json.catalogName);
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
                    data: { c: 'assetlibrary', m: 'getproviderbyid', p: node.Node.dealerId },
                    success: function (data) {
                        var Ret = eval('(' + data + ')');
                        var ctlg_json = Ret.Result;
                        $("#tb_objmng_saler").text(ctlg_json.catalogName);
                        return;
                    },
                    error: function (data) {
                        alert(data);
                    }
                });
            Cur_Selected_Node = node;
            return;
        },
        Init_Page: function () {
            //获取人员信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'sysconfig', m: 'getallemployee', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           //$("#tb_objmng_name").combotree('loadData', ctlg_json);
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
                       data: { c: 'assetlibrary', m: 'providermng', p: 'zw' },
                       success: function (data) {
                           $("#tb_empl_rank").combotree('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            //获取性别信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'providermng', p: 'xb' },
                       success: function (data) {
                           $("#tb_empl_rank").combotree('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            return;
        },
        Btn_Submit_Click: function (ev) {
            var rows = $('#dgt_obj_list').datagrid("getRows");
            var Param_Json = [];
            var Param_Json_all = {};
            Param_Json_all.ApplyId = 0;
            Param_Json_all.ApproveId = 0;
            Param_Json_all.RelativeTask = 0;
            Param_Json_all.ManagerId = 0;
            Param_Json_all.data = Param_Json;
            if (Submit_Flag == 1) {
                return;
            }
            $.each(rows, function (i, val) {
                var TempNode = { 'ProductId': '', 'SaleCount': '' };
                TempNode.ProductId = val.ProductId;
                TempNode.SaleCount = val.Amount;
                Param_Json.push(TempNode);
            });
            $.ajax(
                {

                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'savefetchdetail', p: JSON.stringify(Param_Json_all) },
                    success: function (data) {
                        var Ret_Data = eval('(' + data + ')');
                        var Ret_Result_Json = Ret_Data.Result.Lists;
                        $("#Div_Out_Result").show();
                        $.each(Ret_Result_Json, function (i, val) {
                            $("#dgt_obj_OutResult").datagrid("appendRow", val);
                        });
                        Submit_Flag = 1;
                    }
                });
            return;
        },
        Btn_Cancel_Click: function () {
            location.reload(false);
            return;
        },
        Btn_Ok_Click: function () {
            var i_amount = $("#tb_objmng_amount").val();
            var objmng_Json = { ProductId: '', ProductName: '', FactoryName: '', Model: '', Spec: '', Amount: '', Total: '' };
            if (parseInt(i_amount) > 0) {
                objmng_Json.ProductId = Cur_Selected_Node.id;
                objmng_Json.ProductName = Cur_Selected_Node.text;
                objmng_Json.FactoryName = $("#tb_objmng_factory").text();
                objmng_Json.Model = $("#tb_objmng_model").text();
                objmng_Json.Spec = $("#tb_objmng_spec").text();
                objmng_Json.Amount = $("#tb_objmng_amount").val();
                objmng_Json.Total = $("#tb_objmng_total").text();
                $('#dlg_product_detail').dialog('close');
                $('#dgt_obj_list').datagrid('appendRow', objmng_Json);
            }
            return;
        },
        Btn_Close_Click: function () {
            $('#dlg_product_detail').dialog('close');
            return;
        }
    });
$(document).ready(function () {
    $("#btn_empl_submit").click($.Btn_Submit_Click);
    $("#btn_empl_cancel").click($.Btn_Cancel_Click);
    $("#btn_empl_ok").click($.Btn_Ok_Click);
    $("#btn_empl_close").click($.Btn_Close_Click);
    $("#btn_empl_add").click($.Btn_Add_Click);
    $("#btn_empl_edit").click($.Btn_Edit_Click);
    $('#dlg_employee_detail').dialog('close');
    $.Init_Page();
});
