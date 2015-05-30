<%@ Page Language="C#" AutoEventWireup="true" CodeFile="producttree.aspx.cs" Inherits="views_producttree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>

    <title>�ʲ��������</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/producttree.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">�ʲ�Ʒ����ά��</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="left" colspan="4" style="width:308px;">
                <div class="Div_Tree_Container">
                <ul id="tv_product_info" class="easyui-tree" data-options="animate:true"></ul></div></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">�ʲ����ƣ�</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_name" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">��Ʒ��ţ�</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_Num" class="easyui-textbox"  data-options="" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">�ͺţ�</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_model" class="easyui-textbox" data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">���</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_spec" class="easyui-textbox" data-options="" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">��Ӧ�̣�</td>
            <td  align="left" class="Tbl_TD_Txt">
                <input id="tb_objmng_saler" class="easyui-combobox"  name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">�������ң�</td>
            <td  align="left" class="Tbl_TD_Txt">
                <input id="tb_objmng_factory" class="easyui-combobox"  name="" data-options="valueField:'id',textField:'text'" style="width:275px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label">��װ��λ��</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_Unit" class="easyui-textbox"  data-options="" style="width:275px;"/></td>
            <td  align="left" class="Tbl_TD_Label">����(Ԫ)��</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_objmng_price" class="easyui-numberbox"  precision="2" data-options="min:0,max:1000000,required:true" style="width:275px;"/></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px"> 
                <input id="btn_objmng_delete" type="button" style=" width:70px;" value="ɾ��" />
                <input id="btn_objmng_addsub" type="button" style=" width:70px;" value="�������" />
                <input id="btn_objmng_submit" type="button" style=" width:70px;" value="�ύ" />
                <input id="btn_objmng_cancel" type="button" style=" width:70px;" value="����" /></td>
        </tr>
    </table>
</form>
</body>
</html>


