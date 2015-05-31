var Cur_Selected_Node = new Object();
$.extend(
    {
        Count_Total_Price: function () {
            var Amount = $("#tb_objmng_amount").val();
            var Total_Price =Math.round(100*parseInt(Amount) * parseFloat($("#tb_objmng_price").text()))/100;
            $("#tb_objmng_total").text(Total_Price.toString());
            return;
        },
        Format_Detail: function (value, row, index) {
            return '<a href="javascript:void(0)" onclick="$.Open(\'' + row.itemid + '\')">详情</a> ';
        },
        Open: function (id) {
            var starttime = $('#tb_qryobj_time_start').datetimebox('getValue');
            var endtime = $('#tb_qryobj_time_end').datetimebox('getValue');
            /*
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: { id: "", startime: "", endtime: "" } },
                    success: function (data) {
                        $('#tb_qryobj_factory').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
                */
            $('#dlg_product_detail').dialog('open');
            return;
        },
        NewRow:function()
        {
            $('#dlg_product_detail').dialog('open');
            return;
        },
        DeleteRow:function()
        {
            var row = $('#dgt_obj_list').datagrid('getSelected');
            if (row) {
                var rowIndex = $('#dgt_obj_list').datagrid('getRowIndex', row);
                $('#dgt_obj_list').datagrid('deleteRow', rowIndex);
            }
            return;
        },
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
            if (str_id.length < 12)
            {
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
            //获取资产品名信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'getallpingmingtree', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           $("#tb_objmng_name").combotree('loadData', ctlg_json);
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
            var Param_Json_all={};
            Param_Json_all.ApplyId=0;
            Param_Json_all.ApproveId=0;
            Param_Json_all.RelativeTask=0;
            Param_Json_all.ManagerId=0;
            Param_Json_all.data = Param_Json;
            $.each(rows, function (i, val)
            {
                var TempNode = { 'ProductId': '', 'SaleCount': ''};
                TempNode.ProductId = val.ProductId;
                TempNode.SaleCount = val.Amount;
                Param_Json.push(TempNode);
            });
            $.ajax(
                {
                    
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'savefetchdetail', p: JSON.stringify(Param_Json_all) },
                    success: function (data)
                    {
                        var Ret_Data = eval('(' + data + ')');
                        var Ret_Result_Json = Ret_Data.Result.Lists;
                        $("#Div_Out_Result").show();
                        $.each(Ret_Result_Json, function (i, val) {
                            $("#dgt_obj_OutResult").datagrid("appendRow", val);
                        });
                        
                    }
                });
            return;
        },
        Btn_Cancel_Click: function ()
        {
            location.reload(false);
            return;
        },
        Btn_Ok_Click: function () {
            var i_amount = $("#tb_objmng_amount").val();
            var objmng_Json = { ProductId: '',ProductName:'',FactoryName:'',Model:'',Spec:'',Amount:'', Total:''};
            if (parseInt(i_amount) > 0)
            {
                objmng_Json.ProductId = Cur_Selected_Node.id;
                objmng_Json.ProductName = Cur_Selected_Node.text;
                objmng_Json.FactoryName=$("#tb_objmng_factory").text();
                objmng_Json.Model = $("#tb_objmng_model").text();
                objmng_Json.Spec = $("#tb_objmng_spec").text();
                objmng_Json.Amount = $("#tb_objmng_amount").val();
                objmng_Json.Total = $("#tb_objmng_total").text();
                $('#dlg_product_detail').dialog('close');
                $('#dgt_obj_list').datagrid('appendRow',  objmng_Json);
            }
            return;
        },
        Btn_Close_Click: function () {
            $('#dlg_product_detail').dialog('close');
            return;
        }
    });
$(document).ready(function () {
    $("#btn_objmng_submit").click($.Btn_Submit_Click);
    $("#btn_objmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_objmng_ok").click($.Btn_Ok_Click);
    $("#btn_objmng_close").click($.Btn_Close_Click);
    $("input", $("#tb_objmng_amount").next("span")).blur(function () { $.Count_Total_Price() });
    $("#tb_objmng_name").combotree({ onSelect: function (node) { $.Get_Product_Detail(node) } });
    $('#dlg_product_detail').dialog('close');
    $.Init_Page();
});
