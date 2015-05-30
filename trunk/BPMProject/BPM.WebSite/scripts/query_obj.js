$.extend(
    {
        rowformater:function(value,row,index)
        {
            return '<a href="javascript:void(0)" onclick="$.Open(\'' + row.itemid + '\')">详情</a> ';
        },
        Open:function(id)
        {
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: id },
                    success: function (data) {
                        $('#tb_qryobj_factory').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
            $('#dlg').dialog('open');
            
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
        Init_Page: function () {
            //获取生产厂家信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'cj' },
                    success: function (data) {
                        $("#tb_qryobj_factory").combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
                );
            //获取来源信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'ly' },
                    success: function (data) {
                        $('#tb_qryobj_source').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
                );
            //获取库房信息
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'providermng', p: 'kf' },
                    success: function (data) {
                        $('#tb_qryobj_warehouse').combobox('loadData', $.Deal_Data(data));
                    },
                    error: function (data) {
                        //alert(data);
                    }
                }
                );
            return;
        },
        Btn_Query_Click: function (ev) {
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: '', p: JSON.stringify(Objmng_In_Json) },
                    success: function (data) {
                        alert("保存成功！");
                        location.reload();
                    }
                });
            return;
        }
    });
$(document).ready(function () {
    $("#btn_qryobj_query").click($.Btn_Query_Click);
    var dd = {
        "total": 20, "rows": [
        { "productid": "FI-SW-01", "productname": "Koi", "unitcost": 10.00, "status": "P", "listprice": 36.50, "attr1": "Large", "itemid": "EST-1" },
        { "productid": "K9-DL-01", "productname": "Dalmation", "unitcost": 12.00, "status": "P", "listprice": 18.50, "attr1": "Spotted Adult Female", "itemid": "EST-10" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 38.50, "attr1": "Venomless", "itemid": "EST-11" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 26.50, "attr1": "Rattleless", "itemid": "EST-12" },
        { "productid": "RP-LI-02", "productname": "Iguana", "unitcost": 12.00, "status": "P", "listprice": 35.50, "attr1": "Green Adult", "itemid": "EST-13" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 158.50, "attr1": "Tailless", "itemid": "EST-14" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 83.50, "attr1": "With tail", "itemid": "EST-15" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 23.50, "attr1": "Adult Female", "itemid": "EST-16" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 89.50, "attr1": "Adult Male", "itemid": "EST-17" },
        { "productid": "AV-CB-01", "productname": "Amazon Parrot", "unitcost": 92.00, "status": "P", "listprice": 63.50, "attr1": "Adult Male", "itemid": "EST-18" },
        { "productid": "FI-SW-01", "productname": "Koi", "unitcost": 10.00, "status": "P", "listprice": 36.50, "attr1": "Large", "itemid": "EST-1" },
        { "productid": "K9-DL-01", "productname": "Dalmation", "unitcost": 12.00, "status": "P", "listprice": 18.50, "attr1": "Spotted Adult Female", "itemid": "EST-10" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 38.50, "attr1": "Venomless", "itemid": "EST-11" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 26.50, "attr1": "Rattleless", "itemid": "EST-12" },
        { "productid": "RP-LI-02", "productname": "Iguana", "unitcost": 12.00, "status": "P", "listprice": 35.50, "attr1": "Green Adult", "itemid": "EST-13" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 158.50, "attr1": "Tailless", "itemid": "EST-14" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 83.50, "attr1": "With tail", "itemid": "EST-15" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 23.50, "attr1": "Adult Female", "itemid": "EST-16" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 89.50, "attr1": "Adult Male", "itemid": "EST-17" },
        { "productid": "AV-CB-01", "productname": "Amazon Parrot", "unitcost": 92.00, "status": "P", "listprice": 63.50, "attr1": "Adult Male", "itemid": "EST-18" }
        ]
    };
    $("#dgt_result_query").datagrid('loadData', dd);
    //$("#dlg_product_detail").datagrid('loadData', dd);
    $.Init_Page();
});
