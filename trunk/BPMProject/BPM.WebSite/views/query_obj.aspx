<%@ Page Language="C#" AutoEventWireup="true" CodeFile="query_obj.aspx.cs" Inherits="views_query_obj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>资产查询</title>
    <link href="../css/skin.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../js/default.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" class="Tbl_Info">
        <tr>
            <td  align="center" colspan="4" class="Tbl_TD_Value">复合查询条件</td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_name" type="checkbox" name="CheckBox1" />资产名称：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_name" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_factory" type="checkbox" name="CheckBox1" />生产厂家：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_factory" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_spec" type="checkbox" name="CheckBox1" />规格：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_spec" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_model" type="checkbox" name="CheckBox1" />型号：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_model" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_source" type="checkbox" name="CheckBox1" />来源：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_source" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_warehouse" type="checkbox" name="CheckBox1" />库房编号：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_warehouse" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
        </tr>
        <tr>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_time_interval" type="checkbox" name="CheckBox1" />时间区间：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_time_interval_start" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
            <td  align="left" class="Tbl_TD_Label"><input id="cb_qryobj_warehous" type="checkbox" name="CheckBox1" />库房编号：</td>
            <td  align="left" class="Tbl_TD_Txt"><input id="tb_qryobj_warehou" class="Tbl_TD_TextBox" type="text" maxlength="48"/></td>
        </tr>
        <tr>
            <td  align="left" colspan ="4" class="Tbl_TD_Value"><asp:Button ID="Button1" runat="server" Text="查询" Width="84px" /></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width:830px" border="0">
        <tr>
            <td  align="left" style="width:830px;height:48px">
                <asp:GridView ID="gv_Result" runat="server" AutoGenerateColumns="False"
                              CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left"
                              PageSize="4" Width="830px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="usr_name" HeaderText="编号">
                            <ControlStyle Width="20%" />
                            <HeaderStyle Height="24px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usr_dept" HeaderText="名称">
                            <ControlStyle Width="35%" />
                            <HeaderStyle Height="24px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usr_rank" HeaderText="生产厂家" >
                            <ControlStyle Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usr_memo" HeaderText="数量" >
                            <ControlStyle Width="3%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="type" HeaderText="库房号" >
                            <ControlStyle Width="3%" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("usr_time") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="详细" runat="server" Text='<%# Bind("usr_time") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="3%" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</form>
</body>
</html>



