<%@ Page Language="C#" AutoEventWireup="true" CodeFile="config_empl.aspx.cs" Inherits="views_config_empl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>

    <title>��Ա��Ϣ����</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/config_empl.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Title">
        <tr>
            <td  align="center" colspan ="2" class="Tbl_TD_Title">��Ա��Ϣ����</td>
        </tr>
    </table>
    <table id="dgt_result_query" class="easyui-datagrid" data-options="singleSelect:true,collapsible:true" style="width:830px;height:240px;font-size:16px">
        <thead>
        <tr>
            <th data-options="field:'id',width:100">���</th>
            <th data-options="field:'name',width:250">����</th>
            <th data-options="field:'deptname',width:170">����</th>
            <th data-options="field:'age',width:120">����</th>
            <th data-options="field:'sex',width:120">�Ա�</th>
            <th data-options="field:'rank',width:120">ְ��</th>
            <th data-options="field:'telno',width:120">�绰</th>
        </tr>
    </thead>
    </table>
   <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="right" colspan ="2" style="width:830px;height:48px"> 
                <input id="btn_empl_delete" type="button" style=" width:70px;" value="ɾ��" />
                <input id="btn_empl_addsub" type="button" style=" width:70px;" value="����" />
                <input id="btn_empl_edit" type="button" style=" width:70px;" value="�޸�" />
                <input id="btn_empl_submit" type="button" style=" width:70px;" value="����" />
                <input id="btn_empl_cancel" type="button" style=" width:70px;" value="����" /></td>
        </tr>
    </table>
   <div id="dlg_employee_detail" class="easyui-dialog" title="��Ա��Ϣ" data-options="" style="width:760px;height:250px;padding:10px">
	<table cellpadding="0" cellspacing="0" class="Dlg_Tbl_Query">
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">��Ա������</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_empl_name" class="easyui-textbox" style="width:250px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">���ţ�</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="sl_empl_dept" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">�����쵼��</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="sl_empl_leaderflag" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">���䣺</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_empl_age" class="easyui-numberbox" data-options="min:0,max:1000,required:true" style="width:250px;"/></td>
        </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">�Ա�</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="sl_empl_sex" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">ְ��</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="sl_empl_rank" class="easyui-combobox" name="" data-options="valueField:'id',textField:'text'" style="width:250px;"/></td>
            </tr>
        <tr>
            <td  align="left" class="Dlg_Tbl_TD_Label">�绰��</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_empl_telno" class="easyui-numberbox" data-options="min:0,max:1000000000,required:true" style="width:250px;"/></td>
            <td  align="left" class="Dlg_Tbl_TD_Label">��ע��</td>
            <td  align="left" class="Dlg_Tbl_TD_Txt"><input id="tb_empl_memo" class="easyui-textbox" style="width:250px;"/></td>
        </tr> 
      </table>
    <table cellpadding="0" cellspacing="0" class="Dlg_Tbl_Query_NoLine">
        <tr>
            <td align="center">
            <input id="btn_objmng_ok" type="button" style=" width:70px;" value="ȷ��" />
            <input id="btn_objmng_close" type="button" style=" width:70px;" value="�ر�" /></td>
        </tr>
    </table>
    </div>
</form>
</body>
</html>