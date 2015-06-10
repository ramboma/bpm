var Deal_Model = 0;   //0标示没有操作，1表示修改，2表示新增
var Cur_Selected_Row = null;
$.extend(
    {
        Deal_Data: function (data) {
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
        Get_Role_Detail: function (row) {
            $("#tb_role_name").textbox('setValue', row.RoleName);
            $("#sl_role_emplid").combobox('setValue', row.EmplID);
            $("#tb_role_remark").textbox('setValue', row.Remark);
            Deal_Model = 1;
            Cur_Selected_Row = row;
            return;
        },
        Init_Page: function () {
            //获取角色信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'sysconfig', m: 'getallroleinfo', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           $("#dgt_result_query").datagrid('loadData', ctlg_json);
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
                           $("#sl_role_emplid").combobox('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            return;
        },
        Btn_Ok_Click: function () {
            var Row = {};
            Row.RoleName = $("#tb_role_name").textbox('getValue');
            Row.EmplID = $("#sl_role_emplid").combobox('getValue');
            Row.Remark = $("#tb_role_remark").textbox('getValue');
            Row.AccessMask = 0;
            if (Deal_Model == 1) //修改
            {
                Row.RoleID = Cur_Selected_Row.RoleID;
                $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'sysconfig', m: 'updateroleinfo', p: JSON.stringify(Row) },
                    success: function (data) {
                        var Ret_Data = eval('(' + data + ')');
                        var Ret_Result_Json = Ret_Data.Result.Lists;
                        location.reload();
                    }
                });
            }
            else if (Deal_Model == 2) //新增
            {
                $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'sysconfig', m: 'addroleinfo', p: JSON.stringify(Row) },
                    success: function (data) {
                        var Ret_Data = eval('(' + data + ')');
                        var Ret_Result_Json = Ret_Data.Result.Lists;
                        location.reload();
                    }
                });
            }
            return;
        },
        Btn_Close_Click: function () {
            $('#dlg_role_detail').dialog('close');
            return;
        },
        Btn_Add_Click: function () {
            $("#tb_role_name").textbox('setValue', "");
            $("#sl_role_emplid").combobox('setValue', "");
            $("#tb_role_remark").textbox('setValue', "");
            Deal_Model = 2;
            $('#dlg_role_detail').dialog('open');
            return;
        },
        Btn_Edit_Click: function () {
            var row = $('#dgt_result_query').datagrid('getSelected');
            if (row) {
                $('#dlg_role_detail').dialog('open');
                $.Get_Role_Detail(row);
            }
            return;
        },
        Btn_Del_Click: function () {
            var row = $('#dgt_result_query').datagrid('getSelected');
            if (row) {
                if (confirm("是否删除角色：" + row.RoleName + "的信息？")) {
                    $.ajax(
                    {
                        url: '/Route/LibraryHandler.ashx',
                        type: 'POST',
                        data: { c: 'sysconfig', m: 'deleteroleinfo', p: row.RoleID },
                        success: function (data) {
                            var Ret_Data = eval('(' + data + ')');
                            var Ret_Result_Json = Ret_Data.Result.Lists;
                            location.reload();
                        }
                    });
                }
            }
            return;
        }
    });
$(document).ready(function () {
    $("#btn_role_ok").click($.Btn_Ok_Click);
    $("#btn_role_close").click($.Btn_Close_Click);
    $("#btn_role_add").click($.Btn_Add_Click);
    $("#btn_role_edit").click($.Btn_Edit_Click);
    $("#btn_role_delete").click($.Btn_Del_Click);
    $('#dlg_role_detail').dialog('close');
    $.Init_Page();
});
