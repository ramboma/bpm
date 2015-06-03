<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doc_in.aspx.cs" Inherits="views_doc_in"  CodePage="936"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>文档入库流程</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/widget/qrcode/jquery.qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/jquery.form.min.js"></script>
    <script type="text/javascript" src="../scripts/doc_in.js"></script>
</head>
<body>
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">文档入库流程</td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Title_Label">登记日期：</td>
            <td  align="left" class="Tbl_TD_Title_Txt">
                <span id="tb_docmng_time" class="Tbl_TD_TextBox"></span></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" class="Tbl_TD_Label">文档名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_name" class="easyui-textbox" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">文档类型：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="sl_docmng_type" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">作者：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_author" class="easyui-textbox" style="width:275px;font-size:18px"/></td>
            <td  align="left" class="Tbl_TD_Label">出版社：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_publisher" class="easyui-textbox" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">关键字：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_keyword" class="easyui-textbox" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">权限范围：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="sl_docmng_readlevel" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">内容简介：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt"><input id="ta_docmng_introduce" class="easyui-textbox" data-options="multiline:true" value="" style="width:690px;height:72px"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">文件名：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt">
            <form id="frm_fileupload" action="/Route/libraryhandler.ashx" enctype="multipart/form-data"  method="post">
            <input id="file_upload" type="file" name="fileupload" style="width:400px; font-size:16px"/> 
            </form><input id="btn_docmng_upload" type="button" style=" width:70px;" value="上传" /></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px">
                <input id="btn_docmng_submit" type="button" style=" width:70px;" value="提交" />
                <input id="btn_docmng_cancel" type="button" style=" width:70px;" value="重置" />
            </td>
        </tr>
    </table>
</body>
</html>

