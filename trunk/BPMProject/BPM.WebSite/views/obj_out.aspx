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
            <td  align="left" class="Tbl_TD_Label">二维码：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt">
                <input id="btn_objmng_scan" type="button" style=" width:70px;" value="扫描" />
            </td>
        </tr>
        <tr>
            <td  align="left" colspan="4" class="Tbl_TD_Txt"><div id="div_objmng_qrcode" class="Div_qrcode"></div></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">资产名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_name" class="easyui-combotree" data-options="url:'tree_data1.json',method:'get',required:true" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">生产厂家：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_factory" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">供应商：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_saler" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Tbl_TD_Label">包装单位：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_unit" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">型号：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_model" class="Tbl_TD_TextBox"></span>
            </td>
            <td  align="left" class="Tbl_TD_Label">规格：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_spec" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">来源：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_source" class="Tbl_TD_TextBox"></span>
            </td>
            <td  align="left" class="Tbl_TD_Label">单价：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_price" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">数量：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_amount" class="easyui-numberbox" data-options="min:0,max:1000000,required:true" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">总价：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_objmng_total" class="Tbl_TD_TextBox"></span>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">申请人：</td>
            <td  align="left" class="Tbl_TD_Txt"><input class="easyui-combobox" id="tb_objmng_apply" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">批准人：</td>
            <td  align="left" class="Tbl_TD_Txt"><input class="easyui-combobox" id="tb_objmng_approval" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
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


