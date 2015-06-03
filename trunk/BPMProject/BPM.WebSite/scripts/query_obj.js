$.extend(
    {
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
    $('#dlg_product_detail').dialog('close');
    $.Init_Page();
});
