<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dev_change.aspx.cs" Inherits="views_dev_change" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>设备登记流程</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/widget/qrcode/jquery.qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/qrcode.js"></script>
    <script type="text/javascript" src="../scripts/dev_change.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">设备变动流程</td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Title_Label">变动日期：</td>
            <td  align="left" class="Tbl_TD_Title_Txt">
                <span id="tb_devmng_change_time" class="Tbl_TD_TextBox"></span></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left"  class="Tbl_TD_Label">二维码：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt">
                <input id="btn_devmng_scan" type="button" style=" width:70px;" value="扫描" />
            </td>
        </tr>
        <tr>
            <td  align="left" colspan="4" class="Tbl_TD_Txt">
                <div id="div_devmng_qrcode" class="Div_qrcode"></div>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">设备名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_name" class="easyui-combotree" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">生产厂家：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_factory" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">型号：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_model" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Tbl_TD_Label">规格：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_spec" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">来源：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_source" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Tbl_TD_Label">单价：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_price" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">保管单位：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_dept" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Tbl_TD_Label">责任人：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_owner" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">出厂时间：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_producttime" class="Tbl_TD_TextBox"></span></td>
            <td  align="left" class="Tbl_TD_Label">设备状态：</td>
            <td  align="left" class="Tbl_TD_Txt"><span id="tb_devmng_status" class="Tbl_TD_TextBox"></span></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">变动类型：</td>
            <td  align="left" class="Tbl_TD_Txt"><input class="easyui-combobox" id="sl_devmng_changetype" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">经办人：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_operator" class="easyui-textbox" style="width:275px;"/></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px">
                <input id="btn_devmng_submit" type="button" style=" width:70px;" value="提交" />
                <input id="btn_devmng_cancel" type="button" style=" width:70px;" value="取消" />
            </td>
        </tr>
    </table>
    <div id="devmng_ctlg_detail_container" class="Div_ctlg_detail_container">
        <div id="devmng_ctlg_detail">
        </div>
        <input id="btn_detail_select" type="button" style=" width:70px;" value="确定" />
        <input id="btn_detail_cancel" type="button" style=" width:70px;" value="取消" /></div>
</form>
</body>
</html>

