<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doc_in.aspx.cs" Inherits="views_doc_in" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>文档入库流程</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/jstree/themes/default/style.min.css" />
    <script type="text/javascript" src="../scripts/widget/jstree/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../scripts/widget/jstree/jstree.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/jquery.qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/qrcode.js"></script>
    <script type="text/javascript" src="../scripts/dev_unreg.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">文档入库流程</td>
        </tr>
        <tr>
            <td  align="left" style="width:100px;height:24px">登记日期：</td>
            <td  align="left" style="width:730px;height:24px">
                <span id="tb_docmng__time" class="Tbl_TD_TextBox"></span></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" class="Tbl_TD_Label">文档名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_name" class="Tbl_TD_TextBox" type="text" maxlength="48"/>
            </td>
            <td  align="left" class="Tbl_TD_Label">文档类型：</td>
            <td  align="left" class="Tbl_TD_Txt"><select id="sl_docmng_type" class="Tbl_TD_TextBox" name="D1">
                <option value="技术资料">技术资料</option>
                <option value="数据资料">数据资料</option>
                <option value="公文资料">公文资料</option>
            </select></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">作者：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_author" class="Tbl_TD_TextBox" type="text" maxlength="24"/></td>
            <td  align="left" class="Tbl_TD_Label">出版社：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_docmng_publisher" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">密级：</td>
            <td  align="left" class="Tbl_TD_Txt"><select id="sl_docmng_seclevel" class="Tbl_TD_TextBox" name="D1">
                <option value="内文">内文</option>
                <option value="秘密">秘密</option>
                <option value="机密">机密</option>
            </select></td>
            <td  align="left" class="Tbl_TD_Label">权限范围：</td>
            <td  align="left" class="Tbl_TD_Txt"><select id="sl_docmng_readlevel" class="Tbl_TD_TextBox" name="D1">
                <option value="内文">技术员以上</option>
                <option value="组长以上">组长以上</option>
                <option value="室主任以上">室主任以上</option>
                <option value="中心领导">中心领导</option>
            </select></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">关键字：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt"><input id="tb_docmng_keyword" class="Tbl_TD_TextBox_long" type="text" maxlength="24"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">内容简介：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt"><textarea id="ta_docmng_introduce" name="S1" class="Ta_introduce"></textarea></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">文件名：</td>
            <td  align="left" colspan="3" class="Tbl_TD_Txt"><input id="file_upload" type="file" style="width:400px;"/></td>
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

