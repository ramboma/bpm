var Cur_selected_Node = null;
var Addsub_Flag = 0;
$.extend(
    {
        Get_Dept_Detail: function (node) {
            $("#tb_dept_name").textbox('setValue', node.Node.Name);
            $("#tb_dept_memo").textbox('setValue', node.Node.Remark);
            Cur_selected_Node = node;
            return;
        },
        Init_Page: function () {
            //获取部门信息
            $.ajax(
                   {
                       url: '/Route/LibraryHandler.ashx',
                       type: 'POST',
                       data: { c: 'sysconfig', m: 'getalldepttree', p: '' },
                       success: function (data) {
                           var Ret = eval('(' + data + ')');
                           var ctlg_json = Ret.Result;
                           $("#tv_department_info").tree('loadData', ctlg_json);
                       },
                       error: function (data) {
                           alert(data);
                       }
                   }
                   );
            return;
        },
        Btn_Submit_Click: function (ev) {
            var Dept_Json = { ParentId: '', Name: '', Remark: ''};
            if (Addsub_Flag == 0) {
                return;
            }
            Dept_Json.ParentId = Cur_selected_Node.Node.ID;
            Dept_Json.Name = $('#tb_dept_name').val();
            Dept_Json.Remark = $('#tb_dept_memo').val();
            $.ajax(
                {
                    url: '/Route/LibraryHandler.ashx',
                    type: 'POST',
                    data: { c: 'sysconfig', m: 'adddeptinfo', p: JSON.stringify(Dept_Json) },
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
            if (Cur_selected_Node == null) {
                return;
            }
            if (Cur_selected_Node.Node.ID == '1')
            {
                alert("无法删除根目录！");
            }
            if (confirm("是否删除《" + Cur_selected_Node.text + "》项及其所有子项吗？")) {
                $.ajax(
                    {
                        url: '/Route/LibraryHandler.ashx',
                        type: 'POST',
                        data: { c: 'sysconfig', m: 'deletedeptinfo', p: Cur_selected_Node.Node.ID },
                        success: function (data) {
                            alert(data);

                        },
                        error: function (data) {
                            alert(data);
                        }
                    });

            }
            return;
        },
        Btn_Addsub_Click: function () {
            if (Cur_selected_Node != null) {
                    $("#tb_dept_name").textbox('setValue', '');
                    $("#tb_dept_memo").textbox('setValue', '');
                    Addsub_Flag = 1;
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
    $("#tv_department_info").tree({ onSelect: function (node) { $.Get_Dept_Detail(node); } });
    $.Init_Page();
});
