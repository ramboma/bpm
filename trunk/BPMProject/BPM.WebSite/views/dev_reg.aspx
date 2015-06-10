<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dev_reg.aspx.cs" Inherits="views_dev_reg" CodePage="936" %>

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
    <script type="text/javascript" src="../scripts/widget/jquery.form.min.js"></script>
    <script type="text/javascript" src="../scripts/dev_reg.js"></script>
</head>
<body>
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">设备入账流程</td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Title_Label">登记时间：</td>
            <td  align="left" class="Tbl_TD_Title_Txt">
                <span id="tb_devmng_reg_time" class="Tbl_TD_TextBox"></span></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" class="Tbl_TD_Label">设备名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_name" class="easyui-textbox" style="width:275px;"/>
            </td>
            <td  align="left" class="Tbl_TD_Label">出厂时间：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_producttime" class="easyui-datebox" style="width:275px;" />
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">生产厂家：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_factory" class="easyui-textbox" style="width:275px;"/>
            </td>
            <td  align="left" class="Tbl_TD_Label">供应商：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_saler" class="easyui-textbox" style="width:275px;"/>
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">型号：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_model" class="easyui-textbox" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">规格：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_spec" class="easyui-textbox" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">来源：</td>
            <td  align="left" class="Tbl_TD_Txt"><input class="easyui-combobox" id="sl_devmng_source" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/>
            </td>
            <td  align="left" class="Tbl_TD_Label">价格：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_devmng_price" class="easyui-numberbox" precision="2" data-options="min:0,max:1000000,required:true" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">保管单位：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="sl_devmng_dept" class="easyui-combobox" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">责任人：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="sl_devmng_owner" class="easyui-combobox" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">技术文档：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt">
                <form id="frm_fileupload" action="/Route/libraryhandler.ashx" enctype="multipart/form-data"  method="post">
                 <input id="file_upload" type="file" name="fileupload" style="width:400px;"/> 
                </form>
                <input id="btn_devmng_upload" type="button" style=" width:70px;" value="上传" />
            </td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">二维码：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt">
                <input id="btn_devmng_print" type="button" style=" width:70px;" value="打印" />
            </td>
        </tr>
        <tr>
            <td  align="left" colspan="4" style="width:300px;height:200px">
                <div id="div_devmng_qrcode" class="Div_qrcode"></div>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px">
                <input id="btn_devmng_submit" type="button" style=" width:70px;" value="提交" />
                <input id="btn_devmng_cancel" type="button" style=" width:70px;" value="重置" />
            </td>
        </tr>
    </table>
</body>
</html>



