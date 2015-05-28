<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="views_main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="../css/skin.css" />
    <link rel="Stylesheet" type="text/css" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../scripts/widget/easyui/themes/icon.css"/>
    <script type="text/javascript" src="../scripts/widget/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="../scripts/widget/easyui/jquery.easyui.min.js"></script>    
    <script type="text/javascript" src="../scripts/main.js"></script>
</head>
<body>
<table cellpadding="0" cellspacing="0" align="left" class="Tbl_Frame_main">
    <tr>
        <td align="center"  valign="top" style="width:864px; height:600px;">
            <table cellpadding="0" cellspacing="0" border="0" align="center" style="width:864px; height:600px; background-color:#99FFCC">
                <tr>
                <td align="left" style="width:864px; height:26px">
                    <img alt="" src="../images/mywork.png" style="width: 150px; height: 26px" />
                </td>
            </tr>
                <tr>
                    <td align="left" valign="top" style="width:864px; height:174px; background-color:#CCFFCC">
                    <table class="easyui-datagrid" style="width:864px;height:174px;font-size:16px">
                    <thead>
                    <tr>
                    <th data-options="field:'1',width:80">任务号</th>
                    <th data-options="field:'2',width:160">流程类型</th>
                    <th data-options="field:'3',width:300,align:'center'">任务名称</th>
                    <th data-options="field:'4',width:200,align:'center'">到达时间</th>
                    <th data-options="field:'5',width:100">创建人</th>
                    </tr>
                    </thead>
                    </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width:864px; height:26px">
                        <img alt="" src="../images/needwork.png" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:864px; height:174px; background-color:#FFCCCC">
                        <table id="table_needwork" border="1px" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <th w_index="1" align="center" width="80px">任务号</th>
                                <th w_index="2" align="center" width="160px">流程类型</th>
                                <th w_index="3" align="center" width="300px">任务名称</th>
                                <th w_index="4" align="center" width="200px">到达时间</th>
                                <th w_index="5" align="center" width="100px">创建人</th>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width:864px;height:200px">
                        <table cellpadding="0" cellspacing="0" border="0" align="center" style="width:864px; height:200px; background-color:#99FFCC">
                            <tr>
                                <td align="left" style="width:432px; height:26px">
                                    <img alt="" src="../images/message.png" style="width: 150px; height: 26px" />
                                </td>
                                <td align="left" style="width:432px; height:26px">
                                    <img alt="" src="../images/schedule.png" style="width: 150px; height: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:432px; background-color:#FFFFCC">
                                    <table id="table_msg" border="1px" cellpadding="0px" cellspacing="0px">
                                        <tr>
                                            <th w_index="1" align="center" width="80px">时间</th>
                                            <th w_index="2" align="center" width="150px">类型</th>
                                            <th w_index="3" align="center" width="200px">内容</th>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top" style="width:432px; height:174px; background-color:#FFEEAA">
                                    <table id="table_schedule" border="1px" cellpadding="0px" cellspacing="0px">
                                        <tr>
                                            <th w_index="1" align="center" width="200px">时间</th>
                                            <th w_index="2" align="center" width="230px">内容</th>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</body>
</html>
