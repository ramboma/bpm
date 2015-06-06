<%@ Page Language="C#" AutoEventWireup="true" CodeFile="config_role.aspx.cs" Inherits="views_config_role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>

    <title>人员信息管理</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/config_role.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">人员信息管理</td>
        </tr>
    </table>
    <table id="dgt_result_query" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
        <thead>
        <tr>
            <th data-options="field:'id',width:100">编号</th>
            <th data-options="field:'name',width:250">角色名称</th>
            <th data-options="field:'employeeid',width:170">员工id</th>
            <th data-options="field:'ramark',width:120">备注</th>
        </tr>
    </thead>
    </table>
   <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px"> 
                <input id="btn_role_delete" type="button" style=" width:70px;" value="删除" />
                <input id="btn_role_addsub" type="button" style=" width:70px;" value="添加" />
                <input id="btn_role_edit" type="button" style=" width:70px;" value="修改" />
                <input id="btn_role_submit" type="button" style=" width:70px;" value="保存" />
                <input id="btn_role_cancel" type="button" style=" width:70px;" value="放弃" /></td>
        </tr>
    </table>
   <div id="dlg_role_detail" class="easyui-dialog" title="角色信息" data-options="" style="width:760px;height:250px;padding:10px">
	<table cellpadding="0" cellspacing="0" class="Dlg_Tbl_Query">
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">角色名称：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_role_name" class="easyui-textbox" style="width:250px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">员工id：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="sl_empl_id" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">备注：</td>
            <td  align="left" colspan='3' class="Dlg_Tbl_TD_Txt"><input id="tb_role_remark" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
        </tr>
      </table>
    <table cellpadding="0" cellspacing="0" class="Dlg_Tbl_Query_NoLine">
        <tr>
            <td align="center">
            <input id="btn_role_ok" type="button" style=" width:70px;" value="确定" />
            <input id="btn_role_close" type="button" style=" width:70px;" value="关闭" /></td>
        </tr>
    </table>
    </div>
</form>
</body>
</html>

