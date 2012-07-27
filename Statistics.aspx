<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Statistics.aspx.cs" Inherits="PaymentManagement.UserInfoManagement.Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maintd">
        <div id="internBasic">
            <h3>
                Statistics</h3>
            <table class="chara1 tableborder1">
                <tr>
                    <td>
                        Specify Date:
                    </td>
                    <td>
                        From&nbsp;<asp:TextBox ID="tb_startdate" runat="server" onclick="WdatePicker()" Width="80px"></asp:TextBox>
                    </td>
                    <td>
                        to&nbsp;<asp:TextBox ID="tb_enddate" runat="server" onclick="WdatePicker()" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <ul>
                            <li>Total account count :
                                <asp:Label ID="lbl_all" ForeColor="Blue" Font-Bold="true" Text="0" runat="server"></asp:Label></li>
                            <li>Total paid account count :
                                <asp:Label ID="lbl_paid" ForeColor="Blue" Font-Bold="true" Text="0" runat="server"></asp:Label></li>
                            <li>Total payment number :
                                <asp:Label ID="lbl_num" ForeColor="Blue" Font-Bold="true" Text="0" runat="server"></asp:Label></li>
                        </ul>
                    </td>
                </tr>
            </table>
            <table style="width: 800px">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgPress" runat="server" Width="100%" CellPadding="2" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10" HorizontalAlign="Center" BorderWidth="0px">
                            <Columns>
                                <asp:BoundColumn DataField="Product" HeaderText="Product"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Monthly" HeaderText="Monthly"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quarterly" HeaderText="Quarterly"></asp:BoundColumn>
                                <asp:BoundColumn DataField="HalfYear" HeaderText="HalfYear"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Yearly" HeaderText="Yearly"></asp:BoundColumn>
                                <asp:BoundColumn DataField="VIP" HeaderText="VIP"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Total" HeaderText="Total Users" ItemStyle-Width="80px">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Paid" HeaderText="Paid Users" ItemStyle-Width="80px">
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
