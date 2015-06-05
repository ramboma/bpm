<%@ Page Language="C#" AutoEventWireup="true" CodeFile="query_obj.aspx.cs" Inherits="views_query_obj"  CodePage="936"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>资产查询</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/query_obj.js"></script>
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
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_name" type="checkbox" name="CheckBox1" />资产名称：</td>

            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_name" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_factory" type="checkbox" name="CheckBox1" />生产厂家：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_factory" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_spec" type="checkbox" name="CheckBox2" />规格：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_spec" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_model" type="checkbox" name="CheckBox3" />型号：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_model" class="easyui-textbox" data-options="" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_source" type="checkbox" name="CheckBox4" />来源：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_source" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_warehouse" type="checkbox" name="CheckBox5" />库房编号：</td>
            <td  align="left" class="Tbl_Query_TD_Txt"><input id="tb_qryobj_warehouse" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_Query_TD_Label"><input id="cb_qryobj_time_interval" type="checkbox" name="CheckBox6" />时间区间：</td>
            <td  align="left" class="Tbl_Query_TD_Txt">
                <input id="tb_qryobj_time_start" class="easyui-datetimebox" style="width:275px"/>
            </td>
            <td  align="center" class="Tbl_Query_TD_Label">到</td>
            <td  align="left" class="Tbl_Query_TD_Txt">
                <input id="tb_qryobj_time_end" class="easyui-datetimebox" style="width:275px"/>
            </td>
         </tr>
        <tr>
            <td  align="left" colspan ="4" class="Tbl_TD_Value"><input id="btn_qryobj_query" type="button" style=" width:70px;" value="查询" /></td>
        </tr>
    </table>
    <table id="dgt_result_query" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
        <thead>
        <tr>
            <th data-options="field:'itemid',width:100">编号</th>
            <th data-options="field:'productid',width:250">资产名称</th>
            <th data-options="field:'listprice',width:170,align:'right'">生产厂家</th>
            <th data-options="field:'unitcost',width:120,align:'right'">型号</th>
            <th data-options="field:'attr1',width:120">规格</th>
            <th data-options="field:'status',width:50,align:'center',formatter:$.Format_Detail"></th>
        </tr>
    </thead>
    </table>
    <div id="dlg_product_detail" class="easyui-dialog" title="资产详细信息" data-options="" style="width:760px;height:300px;padding:10px">

		    <table id="dgt_product_detail" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:710px;height:300px;font-size:16px">

        <thead>
        <tr>
            <th data-options="field:'itemid',width:100">编号</th>
            <th data-options="field:'productid',width:100">出入状态</th>
            <th data-options="field:'listprice',width:200,align:'right'">时间</th>
            <th data-options="field:'unitcost',width:200,align:'right'">数量</th>
            <th data-options="field:'attr1',width:50">经办人</th>
            <th data-options="field:'status',width:50,align:'center'">来源</th>
        </tr>
    </thead>
    </table>
	</div>

</form>
</body>
</html>



