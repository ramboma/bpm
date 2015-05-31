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
            <table id="dgt_obj_list" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
                <thead>
                    <tr>
                    <th data-options="field:'ProductId',width:100">品名编码</th>
                    <th data-options="field:'ProductName',width:250">资产名称</th>
                    <th data-options="field:'FactoryName',width:150">生产厂家</th>
                    <th data-options="field:'Model',width:100">型号</th>
                    <th data-options="field:'Spec',width:100">规格</th>
                    <th data-options="field:'Amount',width:50">数量</th>
                    <th data-options="field:'Total',width:50">总价</th>
                    </tr>
                </thead>
            </table>
            </td>
        </tr>
    </table>
    <div id="toolbar">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" onclick="$.NewRow()" plain="true">添加</a> 
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-remove" onclick="$.DeleteRow()" plain="true">删除</a>
    </div>
    <div id="dlg_product_detail" class="easyui-dialog" title="资产选择" data-options="" style="width:760px;height:300px;padding:10px">
	<table cellpadding="0" cellspacing="0" class="Dlg_Tbl_Query">
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">资产名称：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_objmng_name" class="easyui-combotree" data-options="url:'tree_data1.json',method:'get',required:true" style="width:275px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">生产厂家：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_factory" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">供应商：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_saler" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">包装单位：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_unit" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">型号：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_model" class="Tbl_TD_TextBox"></span>
            </td>
            <td  align="left" class="Dlg_Tbl_TD_Label">规格：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_spec" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">单价：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_price" class="Tbl_TD_TextBox"></span>
            </td>
            <td  align="left" class="Dlg_Tbl_TD_Label">数量：</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_objmng_amount" class="easyui-numberbox" data-options="min:0,max:1000000,required:true" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">总价：</td>
            <td  align="left" colspan="3" class="Dlg_Tbl_TD_Txt"><span id="tb_objmng_total" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="center" style="width:830px;height:48px">
            <input id="btn_objmng_ok" type="button" style=" width:70px;" value="确定" />
            <input id="btn_objmng_close" type="button" style=" width:70px;" value="关闭" /></td>
        </tr>
    </table>
    </div>
    <div id="Div_Out_Result" style="display:none;height:240px">
                <table id="dgt_obj_OutResult" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
                <thead>
                    <tr>
                    <th data-options="field:'ProductInputId',width:100">批次号</th>
                    <th data-options="field:'ProductName',width:250">资产名称</th>
                    <th data-options="field:'Price',width:150">单价</th>
                    <th data-options="field:'Quantity',width:50">数量</th>
                    <th data-options="field:'Total',width:50">总价</th>
                    <th data-options="field:'StorageName',width:100">库房</th>
                    <th data-options="field:'ShelfName',width:100">货架</th>
                    </tr>
                </thead>
            </table>
    </div>
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


