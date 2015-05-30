<%@ Page Language="C#" AutoEventWireup="true" CodeFile="obj_out.aspx.cs" Inherits="views_obj_out" codepage="936"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>出库流程</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/widget/qrcode/jquery.qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/qrcode.js"></script>
    <script type="text/javascript" src="../scripts/obj_out.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">资产出库流程</td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Title_Label">出库时间：</td>
            <td  align="left" class="Tbl_TD_Title_Txt">
                <span id="tb_objmng_out_time" class="Tbl_TD_TextBox"></span></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
        <td  align="left">
            	<table id="dg" title="Custom DataGrid Pager" style="width:700px;height:250px"
			data-options="toolbar:'#toolbar',rownumbers:true,singleSelect:true,url:'datagrid_data1.json',method:'get'">
		<thead>
			<tr>
				<th data-options="field:'itemid',width:80">Item ID</th>
				<th data-options="field:'productid',width:100">Product</th>
				<th data-options="field:'listprice',width:80,align:'right'">List Price</th>
				<th data-options="field:'unitcost',width:80,align:'right'">Unit Cost</th>
				<th data-options="field:'attr1',width:240">Attribute</th>
				<th data-options="field:'status',width:60,align:'center'">Status</th>
			</tr>
		</thead>
	</>
	
                    <div id="toolbar">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" onclick="newuser()"
            plain="true">添加</a> <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-edit"
                onclick="edituser()" plain="true">修改</a> <a href="javascript:void(0)" class="easyui-linkbutton"
                    iconcls="icon-remove" plain="true">删除</a>
    </div>

        </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px">
                <input id="btn_objmng_submit" type="button" style=" width:70px;" value="提交" />
                <input id="btn_objmng_cancel" type="button" style=" width:70px;" value="重置" /></td>
        </tr>
    </table>
</form>
</body>
</html>


