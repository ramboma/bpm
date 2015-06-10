var Deal_Model = 0;   //0标示没有操作，1表示修改，2表示新增
var Cur_Selected_Row = null;
$.extend(
    {
        Deal_Data: function (data) {
            var Ret = eval('(' + data + ')');
            var ctlg_json = Ret.Result;
            var Json_data = [];
            if (ctlg_json == null) return null;
            for (var i = 0; i < ctlg_json.length; i++) {
                var TempNode = { 'id': '', 'text': '' };
                TempNode.id = ctlg_json[i].catalogId;
                TempNode.text = ctlg_json[i].catalogName;
                Json_data.push(TempNode);
            }
            return Json_data;
        },
        Get_Empl_Detail: function (row) {
            $("#tb_empl_name").textbox('setValue',row.EmplName);
            $("#sl_empl_dept").combobox('setValue', row.EmplID);
            $("#sl_empl_attribute").combobox('setValue', row.Attribute);
            $("#sl_empl_rank").combobox('setValue', row.Rank);
            $("#sl_empl_sex").combobox('setValue', row.Sex);
            $("#tb_empl_birthday").datebox('setValue', row.Birthday);
            $("#tb_empl_aliasname").textbox('setValue', row.AliasName);
            $("#tb_empl_password").textbox('setValue', row.Password);
            $("#tb_empl_telno").textbox('setValue', row.TelNo);
            $("#tb_empl_memo").textbox('setValue', row.Remark);
            Deal_Model = 1;
            Cur_Selected_Row = row;
            return;
        },
        Init_Page: function () {
            //获取人员信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'sysconfig', m: 'getallemplyeeinfo', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           if (ctlg_json == null)
                           {
                               return;
                           }
                           $("#dgt_result_query").datagrid('loadData', ctlg_json);
                       },
                       error: function (data) {
                           alert(data);
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
                           if (ctlg_json == null)
                           {
                               return;
                           }
                           $("#sl_empl_dept").combobox('loadData', ctlg_json);
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
                           $("#sl_empl_sex").combobox('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            //获取职称信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'providermng', p: 'zw' },
                       success: function (data) {
                           $("#sl_empl_rank").combobox('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            //获取岗位属性信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'assetlibrary', m: 'providermng', p: 'gwsx' },
                       success: function (data) {
                           $("#sl_empl_attribute").combobox('loadData', $.Deal_Data(data));
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
             );
            return;
        },
        Btn_Cancel_Click: function () {
            location.reload(false);
            return;
        },
        Btn_Ok_Click: function () {
            var Row = {};
            Row.EmplName = $("#tb_empl_name").textbox('getValue');
            Row.DeptID = $("#sl_empl_dept").combobox('getValue');
            Row.Attribute = $("#sl_empl_attribute").combobox('getValue');
            Row.Rank=$("#sl_empl_rank").combobox('getValue');
            Row.Sex=$("#sl_empl_sex").combobox('getValue');
            Row.Birthday=$("#tb_empl_birthday").datebox('getValue');
            Row.AliasName=$("#tb_empl_aliasname").textbox('getValue');
            Row.Password=$("#tb_empl_password").textbox('getValue');
            Row.TelNo = $("#tb_empl_telno").textbox('getValue');
            Row.Remark = $("#tb_empl_memo").textbox('getValue');
            Row.KeyString = "";
            Row.AccessMask = 0;
            if (Deal_Model == 1) //修改
            {
                Row.EmplID = Cur_Selected_Row.EmplID;
                $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'sysconfig', m: 'updateemployee', p: JSON.stringify(Row) },
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
                    data: { c: 'sysconfig', m: 'addemplyeeinfo', p: JSON.stringify(Row) },
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
            $('#dlg_employee_detail').dialog('close');
            return;
        },
        Btn_Add_Click: function () {
            $("#tb_empl_name").textbox('setValue', "");
            $("#sl_empl_dept").combobox('setValue', "");
            $("#sl_empl_attribute").combobox('setValue', "");
            $("#sl_empl_rank").combobox('setValue', "");
            $("#sl_empl_sex").combobox('setValue', "");
            $("#tb_empl_birthday").datebox('setValue', "");
            $("#tb_empl_aliasname").textbox('setValue', "");
            $("#tb_empl_password").textbox('setValue', "");
            $("#tb_empl_telno").textbox('setValue', "");
            $("#tb_empl_memo").textbox('setValue', "");
            Deal_Model = 2;
            $('#dlg_employee_detail').dialog('open');
            return;
        },
        Btn_Edit_Click: function ()
        {
            var row = $('#dgt_result_query').datagrid('getSelected');
            if (row)
            {
                $('#dlg_employee_detail').dialog('open');
                $.Get_Empl_Detail(row);
            }
            return;
        },
        Btn_Delete_Click: function ()
        {
            var row = $('#dgt_result_query').datagrid('getSelected');
            if (row) {
                if (confirm("是否删除员工：" + row.EmplName + "所有信息？")) {
                    $.ajax(
                    {
                        url: '/Route/LibraryHandler.ashx',
                        type: 'POST',
                        data: { c: 'sysconfig', m: 'deleteemployee', p: row.EmplID },
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
    $("#btn_empl_delete").click($.Btn_Delete_Click);
    $("#btn_empl_ok").click($.Btn_Ok_Click);
    $("#btn_empl_close").click($.Btn_Close_Click);
    $("#btn_empl_add").click($.Btn_Add_Click);
    $("#btn_empl_edit").click($.Btn_Edit_Click);
    $('#dlg_employee_detail').dialog('close');
    $.Init_Page();
});
