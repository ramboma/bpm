$.extend(
    {
        Format_Detail: function (value, row, index) {
            return '<a href="javascript:void(0)" onclick="$.Open(\'' + row.productId + '\')">详情</a> ';
        },
        Open: function (id) {
            var Objmng_json={};
            if (document.getElementById("cb_qryobj_time_interval").checked) {
                Objmng_json.StartTime = $("#tb_qryobj_time_start").datetimebox("getValue");
                Objmng_json.EndTime = $("#tb_qryobj_time_end").datetimebox("getValue");
            };
            Objmng_json.productId=id;
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'searchproductdetail', p: JSON.stringify(Objmng_json) },
                    success: function (data) {
                        var Ret = eval("(" + data + ")");
                        var Result = Ret.Result;
                        $('#dgt_product_detail').datagrid('loadData', Result);
                    },
                    error: function (data) {
                        //alert(data);
                    }
                });
            $('#dlg_product_detail').dialog('open');
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
            var Objmng_Json = {};
            if (document.getElementById("cb_qryobj_name").checked)
            {
                Objmng_Json.productName = $("#tb_qryobj_name").val();
            };
            if (document.getElementById("cb_qryobj_factory").checked) {
                Objmng_Json.factoryName = $("#tb_qryobj_factory").combobox('getText');
            };
            if (document.getElementById("cb_qryobj_spec").checked) {
                Objmng_Json.standard = $("#tb_qryobj_spec").val();
            };
            if (document.getElementById("cb_qryobj_model").checked) {
                Objmng_Json.model = $("#tb_qryobj_model").val();
            };
            if (document.getElementById("cb_qryobj_source").checked) {
                Objmng_Json.Source = $("#tb_qryobj_source").combobox('getValue');
            };
            if (document.getElementById("cb_qryobj_warehouse").checked) {
                Objmng_Json.StorageNum = $("#tb_qryobj_warehouse").combobox('getValue');
            };
            if (document.getElementById("cb_qryobj_time_interval").checked) {
                Objmng_Json.StartTime = $("#tb_qryobj_time_start").datetimebox("getValue");
                Objmng_Json.EndTime = $("#tb_qryobj_time_end").datetimebox("getValue");
            };
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'assetlibrary', m: 'searchproduct', p: JSON.stringify(Objmng_Json) },
                    success: function (data) {
                        var Ret = eval("(" + data + ")");
                        var Result = Ret.Result;
                        $("#dgt_result_query").datagrid('loadData', Result);
                    }
                });
            return;
        }
    });
$(document).ready(function () {
    $("#btn_qryobj_query").click($.Btn_Query_Click);
    $('#dlg_product_detail').dialog('close');
    $("#cb_qryobj_name").attr("checked", 'true');
    $.Init_Page();
});
