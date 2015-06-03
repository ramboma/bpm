var Cur_selected_Node = null;
var Addsub_Flag = 0;
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
            $("#tb_objmng_Num").textbox('setValue', node.Node.productNum);
            $("#tb_objmng_name").textbox('setValue', node.Node.productName);
            if (node.Node.factoryId != 0) {
                $("#tb_objmng_factory").combobox('setValue', node.Node.factoryId);
            }
            else
            {
                $("#tb_objmng_factory").combobox('setValue', "");
            }
            if (node.Node.dealerId != 0) {
                $("#tb_objmng_saler").combobox('setValue', node.Node.dealerId);
            }
            else
            {
                $("#tb_objmng_saler").combobox('setValue', "");
            }
            $("#tb_objmng_model").textbox('setValue', node.Node.model);
            $("#tb_objmng_spec").textbox('setValue',node.Node.standard);
            $("#tb_objmng_Unit").textbox('setValue', node.Node.quantityUnit);
            $("#tb_objmng_price").textbox('setValue', node.Node.price);
            Cur_selected_Node = node;
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
                           $("#tv_product_info").tree('loadData', ctlg_json);
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
                   );
            //获取生产厂家信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'cj' },
                    success: function (data) {
                        $('#tb_objmng_factory').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
                );
            //获取供应商信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'xs' },
                    success: function (data) {
                        $('#tb_objmng_saler').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
                );
            return;
        },
        Btn_Submit_Click: function (ev) {
            var Product_Json = { ParentId: '', ProductNum: '', ProductName: '', ProductFlag: '0', FactoryId: '', DealerId: '', Model: '', Standard: '', Price: '', QuantityUnit: '', HasDelete: '0' };
            if (Addsub_Flag == 0) {
                return;
            }
            Product_Json.ParentId = Cur_selected_Node.Node.productId;
            Product_Json.ProductName = $('#tb_objmng_name').val();
            Product_Json.ProductNum = $('#tb_objmng_Num').val();;
            Product_Json.FactoryId = $('#tb_objmng_factory').combobox('getValue');
            Product_Json.DealerId = $('#tb_objmng_saler').combobox('getValue');
            Product_Json.Model = $('#tb_objmng_model').val();
            Product_Json.Standard = $('#tb_objmng_spec').val();
            Product_Json.Price = $('#tb_objmng_price').val();
            Product_Json.QuantityUnit = $('#tb_objmng_Unit').val();
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'addproduct', p: JSON.stringify(Product_Json) },
                    success: function (data) {
                        alert("保存成功！");
                        location.reload();
                    }
                });
            return;
        },
        Btn_Cancel_Click: function (ev) {
            location.reload();
            return;
        },
        Btn_Delete_Click: function () {
            if (Cur_selected_Node == null)
            {
                return;
            }
            if (confirm("是否删除《" + Cur_selected_Node.text+ "》项及其所有子项吗？"))
            {
                $.ajax(
                    {
                        url: '/Route/LibraryHandler.ashx',
                        type: 'POST',
                        data: { c: 'assetlibrary', m: 'deleteproduct', p: JSON.stringify(Cur_selected_Node.Node) },
                        success: function (data)
                        {
                            alert(data);

                        },
                        error: function (data)
                        {
                            alert(data);
                        }
                });
                
            }
            return;
        },
        Btn_Addsub_Click: function ()
        {
            if (Cur_selected_Node != null)
            {
                if (Cur_selected_Node.id.length < 12) {
                    $("#tb_objmng_name").textbox('setValue', '');
                    $("#tb_objmng_Num").textbox('setValue', '');
                    $("#tb_objmng_model").textbox('setValue', '');
                    $("#tb_objmng_spec").textbox('setValue', '');
                    $("#tb_objmng_saler").combobox('setValue', '');
                    $("#tb_objmng_factory").combobox('setValue', '');
                    $("#tb_objmng_Unit").textbox('setValue', '');
                    $("#tb_objmng_price").textbox('setValue', '');
                    Addsub_Flag = 1;
                }
                else
                {
                    alert("已经是叶子节点，无法增加子项！");
                }
            }
            else {
                alert("请先选择项目！");
            }
            return;
        }
    });
$(document).ready(function () {
    $("#btn_objmng_submit").click($.Btn_Submit_Click);
    $("#btn_objmng_cancel").click($.Btn_Cancel_Click);
    $("#btn_objmng_delete").click($.Btn_Delete_Click);
    $("#btn_objmng_addsub").click($.Btn_Addsub_Click);
    $("#tv_product_info").tree({ onSelect: function (node) { $.Get_Product_Detail(node);} });
    $.Init_Page();
});
