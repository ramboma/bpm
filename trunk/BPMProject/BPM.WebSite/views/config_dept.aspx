<%@ Page Language="C#" AutoEventWireup="true" CodeFile="config_dept.aspx.cs" Inherits="views_config_dept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>

    <title>部门信息管理</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/config_dept.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">部门信息管理</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" colspan="4" style="width:308px;">
                <div class="Div_Tree_Container">
                <ul id="tv_department_info" class="easyui-tree" data-options="animate:true"></ul></div></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">部门名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_dept_name" class="easyui-textbox"  data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">备注：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_dept_memo" class="easyui-textbox" data-options="" style="width:275px;"/></td>
        </tr>
    </table>
   <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px"> 
                <input id="btn_dept_delete" type="button" style=" width:70px;" value="删除" />
                <input id="btn_dept_addsub" type="button" style=" width:70px;" value="添加子项" />
                <input id="btn_dept_submit" type="button" style=" width:70px;" value="提交" />
                <input id="btn_dept_cancel" type="button" style=" width:70px;" value="放弃" /></td>
        </tr>
    </table>
   
</form>
</body>
</html>