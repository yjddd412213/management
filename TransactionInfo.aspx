<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="TransactionInfo.aspx.cs" Inherits="PaymentManagement.UserInfoManagement.TransactionInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Transaction Info</h3>
        <table class="chara1 tableborder1">
            <tr>
                <td>
                    Transaction ID:&nbsp;
                </td>
                <td colspan="3">
                    <asp:TextBox ID="tb_id" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    User ID:&nbsp;
                </td>
                <td colspan="3">
                    <asp:TextBox ID="tb_userid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Pay Date:&nbsp;
                </td>
                <td>
                    From&nbsp;<asp:TextBox ID="tb_startdate" runat="server" onclick="WdatePicker()" Width="70px"></asp:TextBox>
                </td>
                <td>
                    To&nbsp;<asp:TextBox ID="tb_enddate" runat="server" onclick="WdatePicker()" Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="height: 10px;">
                    </div>
                </td>
            </tr>
        </table>
        <table style="width: 800px">
            <tr>
                <td>
                    <asp:DataGrid ID="dgPress" runat="server" Width="100%" CellPadding="2" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="10" DataKeyField="TransactionId" HorizontalAlign="Center"
                        CssClass="chara1 tableborder3" BorderWidth="0px" OnSelectedIndexChanged="dgPress_SelectedIndexChanged"
                        OnPageIndexChanged="dgPress_PageIndexChanged">
                        <AlternatingItemStyle BackColor="#effaf7"></AlternatingItemStyle>
                        <Columns>
                            <asp:ButtonColumn Text="Detail" CommandName="Select" HeaderStyle-CssClass="celltitle2"
                                ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                            <asp:BoundColumn DataField="TransactionId" HeaderText="Transaction ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="InywhereId" HeaderText="User ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ProductId" HeaderText="Product ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ProductTermId" HeaderText="ProductTerm ID"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Charge Date" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                <ItemTemplate>
                                    <asp:Label ID="LblDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChargeDate") %>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Amount" HeaderText="Amount"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="IsPay" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                <ItemTemplate>
                                    <asp:Label ID="Lblresult" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsPay") %>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="InAppPurchase" HeaderText="InAppPurchase"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pl_detail" runat="server" Visible="false">
            <table class="chara1 tableborder2" id="detail">
                <tr>
                    <td valign="top">
                        Inywhere id:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxInywhereID" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Product name:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxProductName" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Term
                    </td>
                    <td>
                        <asp:TextBox Width="200px" ID="tbxTerm" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Amount
                    </td>
                    <td>
                        <asp:TextBox ID="tbxAmount" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Charge Date
                    </td>
                    <td>
                        <asp:TextBox ID="tbxDate" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer Id
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustomerID" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer address1
                    </td>
                    <td>
                        <asp:TextBox ID="tbxaddress1" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer address2
                    </td>
                    <td>
                        <asp:TextBox ID="tbxaddress2" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer city
                    </td>
                    <td>
                        <asp:TextBox ID="tbxcity" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer company
                    </td>
                    <td>
                        <asp:TextBox ID="tbxcompany" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer country
                    </td>
                    <td>
                        <asp:TextBox ID="tbxcountry" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer email
                    </td>
                    <td>
                        <asp:TextBox ID="tbxemail" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer faxmumber
                    </td>
                    <td>
                        <asp:TextBox ID="tbxfax" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer name
                    </td>
                    <td>
                        <asp:TextBox ID="tbxname" Width="200px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Customer phone
                    </td>
                    <td>
                        <asp:TextBox ID="tbxphone" Width="200px" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
