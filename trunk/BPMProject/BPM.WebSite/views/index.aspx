﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="views_index" codepage="936"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>工作流程自动化管理系统</title>
    <link href="../css/skin.css" type="text/css" rel="Stylesheet"/>
    <script type="text/javascript" src="../scripts/default.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" align="center" class="Tbl_logo">
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" align="center" class="Tbl_Content" >
        <tr>
            <td align="left"  valign="top" class="Td_menu">
                <div class="Div_Menu_Container">
                    <div id="div_main_menu" class="Div_Menu_Item_Main" onclick="Return_main()"></div>
                    <div id="div_objmng_menu" class="Div_Menu_Item_ObjMng" onclick="Change_MenuState(0)"></div>
                    <div id="div_objmng_container" class="Div_Menu_Sub_Container">
                        <input id="btn_objmng_in" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="资产入库" />
                        <input id="btn_objmng_out" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="资产出库" />
                        <input id="btn_objmng_reg" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="设备入账" />
                        <input id="btn_objmng_change" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="设备变动"/>
                        <input id="btn_objmng_unreg" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="设备报废" />
                    </div>
                    <div id="div_docmng_menu" class="Div_Menu_Item_DocMng" onclick="Change_MenuState(5)"></div>
                    <div id="div_docmng_container" class="Div_Menu_Sub_Container">
                        <input id="btn_docmng_book_in" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="图书入库" />
                        <input id="btn_docmng_doc_in" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="文档入库" />
                        <input id="btn_docmng_book_reg" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="图书借阅" />
                        <input id="btn_docmng_doc_reg" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="文档查阅" />
                        <input id="btn_docmng_setright" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="查阅授权" />
                    </div>

                    <div id="div_processrun_menu" class="Div_Menu_Item_processrun" onclick="Change_MenuState(1)"></div>
                    <div id="div_processrun_container" class="Div_Menu_Sub_Container">
                        <input id="btn_process_create" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="创建" />
                        <input id="btn_process_promote" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="催办" />
                        <input id="btn_process_reverse" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="回退" />
                        <input id="btn_process_deliver" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="转交" />
                        <input id="btn_process_monitor" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="监控" />
                    </div>
                    <div id="div_qrystc_menu" class="Div_Menu_Item_Qrystc" onclick="Change_MenuState(4)"></div>
                    <div id="div_qrystc_container" class="Div_Menu_Sub_Container">
                        <input id="btn_qrystc_obj" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="资产查询" />
                        <input id="btn_qrystc_dev" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="设备查询" />
                        <input id="btn_qrystc_doc" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="资料查询" />
                        <input id="btn_qrystc_process" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="流程查询" />
                        <input id="btn_qrystc_consume" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="消耗统计" />
                        <input id="btn_qrystc_work" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="工作量统计" />
                    </div>

                    <div id="div_dataanysis_nemu" class="Div_Menu_Item_analysis" onclick="Change_MenuState(2)"></div>
                    <div id="div_dataanalysis_Container" class="Div_Menu_Sub_Container">
                        <input id="btn_ayalysis_score" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="绩效分析" />
                        <input id="btn_analysis_quality" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="质量分析" />
                        <input id="btn_analysis_reality" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="可靠性分析" />
                    </div>
                    <div id="div_config_nemu" class="Div_Menu_Item_Config" onclick="Change_MenuState(3)"></div>
                    <div id="div_config_Container" class="Div_Menu_Sub_Container">
                        <input id="btn_config_dept" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="部门管理" />
                        <input id="btn_config_employee" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="人员管理" />
                        <input id="btn_config_product" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="品名管理" />
                        <input id="btn_config_role" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="角色管理" />
                        <input id="btn_config_process" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="流程管理" />
                        <input id="btn_config_recover" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="备份恢复" />
                        <input id="btn_config_quit" class="Btn_Menu_Item" type="button" onclick="btn_click(this)" value="退出登录"  />
                    </div>
                </div>
            </td>
            <td align="center"  valign="top" style="width:864px; height:600px;">
                <div id ="Div_Dispay" class="Div_Frame">
                    <iframe  id="Iframe_Display" style=" width:100%;height:100%; border:0px;" scrolling="yes" src="../views/main.aspx"></iframe>
                </div>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" align="center" class="Tbl_bottom">
        <tr>
            <td align="center">版权所有：北京国信智科 Copyright◎2013-2021 联系人：xxx 电话：0000000000</td>
        </tr>
    </table>
</form>
</body>
</html>

