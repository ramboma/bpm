<%@ Page Language="C#" AutoEventWireup="true" CodeFile="query_dev.aspx.cs" Inherits="views_query_dev" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>资产查询</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/query_dev.js"></script>
</head>
<body>
<form id="form1" runat="server">
     <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">复合条件查询</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_name" type="checkbox" name="CheckBox1" />设备名称：</td>

            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_name" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_factory" type="checkbox" name="CheckBox1" />生产厂家：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_factory" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_spec" type="checkbox" name="CheckBox1" />规格：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_spec" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_model" type="checkbox" name="CheckBox1" />型号：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_model" class="easyui-textbox" data-options="" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_source" type="checkbox" name="CheckBox1" />来源：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_source" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qrydev_dept" type="checkbox" name="CheckBox1" />所属部门：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qrydev_dept" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" colspan ="4" class="Tbl_TD_Value"><input id="btn_qrydev_query" type="button" style=" width:70px;" value="查询" /></td>
        </tr>
    </table>
    <table id="dgt_result_query" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
        <thead>
        <tr>
            <th data-options="field:'itemid',width:100">设备编号</th>
            <th data-options="field:'productid',width:250">设备名称</th>
            <th data-options="field:'listprice',width:170,align:'right'">所属部门</th>
            <th data-options="field:'unitcost',width:120,align:'right'">型号</th>
            <th data-options="field:'status',width:50,align:'center',formatter:$.Docformater">文档</th>
            <th data-options="field:'attr1',width:50,align:'center',formatter:$.Detailformater"></th>
        </tr>
    </thead>
    </table>
    <div id="dlg_device_detail" class="easyui-dialog" title="设备详细信息" data-options="" style="width:760px;height:300px;padding:10px">
		    <table id="dgt_device_detail" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:710px;height:240px;font-size:16px">
        <thead>
        <tr>
            <th data-options="field:'itemid',width:100">编号</th>
            <th data-options="field:'productid',width:100">设备名称</th>
            <th data-options="field:'listprice',width:200,align:'right'">经手人</th>
            <th data-options="field:'unitcost',width:200,align:'right'">变动类型</th>
            <th data-options="field:'attr1',width:50">变动日期</th>
        </tr>
    </thead>
    </table>
	</div>
    </form>
</body>
</html>
