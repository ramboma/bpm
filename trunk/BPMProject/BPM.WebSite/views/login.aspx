<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="views_login" CodePage="936" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>系统登录</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/widget/qrcode/jquery.qrcode.js"></script>
    <script type="text/javascript" src="../scripts/widget/qrcode/qrcode.js"></script>
    <script type="text/javascript" src="../scripts/login.js"></script>
</head>
<body>
<table align="center" cellpadding="0" cellspacing="0" style="width:800px;height:640px;">
        <tr>
            <td  align="center" style="height:200px"></td>
        </tr>
        <tr>
            <td  align="center" style="height:200px">
	<div class="easyui-panel" title="系统登录" style="width:400px;padding:30px 70px 20px 70px">
		<div style="margin-bottom:10px">
			用户名：<input id="tb_login_username" class="easyui-textbox" style="width:100%;height:32px;padding:12px" data-options="prompt:'用户名',iconCls:'icon-man',iconWidth:32"/>
		</div>
		<div style="margin-bottom:20px">
		    密码：<input id="tb_login_password" class="easyui-textbox" type="password" style="width:100%;height:32px;padding:12px" data-options="prompt:'Password',iconCls:'icon-lock',iconWidth:32"/>
		</div>
		<div>
			<a href="#" onclick="$.Login()" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" style="padding:5px 0px;width:100%;">
				<span style="font-size:14px;">Login</span>
			</a>
		</div>
	</div>
            </td>
        </tr>
        <tr>
            <td  align="center" style="height:200px"></td>
        </tr>
    </table>
</body>
</html>