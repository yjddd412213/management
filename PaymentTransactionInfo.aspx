<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PaymentTransactionInfo.aspx.cs" Inherits="PaymentManagement.PaymentTransactionInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maintd">
        <div id="internBasic">
            <table border="0" class="chara1 tableborder1" width="100%">
                <tr>
                    <td>
                        <table width="710px">
                            <tr>
                                <td style="width: 50px;">
                                </td>
                                <td style="width: 100px;">
                                    <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">
                                        <asp:ListItem Text="Search By PaymentResult" Value="1" Selected="True" />
                                        <asp:ListItem Text="Search By PaymentTime" Value="2" />
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlresult" runat="server">
                                        <asp:ListItem Text="Success" Value="1" />
                                        <asp:ListItem Text="Failure" Value="2" />
                                    </asp:DropDownList>
                                    <asp:Label ID="lblstart" runat="server" Text="Start time:"></asp:Label>
                                    <asp:TextBox ID="tbxstart" Width="100px" onclick="if(self.gfPop)gfPop.fPopCalendar(this);return false;"
                                        runat="server"></asp:TextBox>
                                    <asp:Label ID="lblend" runat="server" Text="end time:"></asp:Label>
                                    <asp:TextBox ID="tbxend" Width="100px" onclick="if(self.gfPop)gfPop.fPopCalendar(this);return false;"
                                        runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr height="20px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataGrid ID="dgPress" runat="server" Width="88%" CellPadding="2" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10" DataKeyField="TransactionId" HorizontalAlign="Center"
                            CssClass="chara1 tableborder3" BorderWidth="0px" OnSelectedIndexChanged="dgPress_SelectedIndexChanged"
                            OnPageIndexChanged="dgPress_PageIndexChanged">
                            <AlternatingItemStyle BackColor="#effaf7"></AlternatingItemStyle>
                            <Columns>
                                <asp:ButtonColumn Text="Look" HeaderText="Edit" CommandName="Select" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="Inywhere ID" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LblInywhereId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InywhereId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Charge Date" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LblDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChargeDate") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="PaymentSuccess" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblresult" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsPay") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                        </asp:DataGrid>
                        <asp:Label ID="lblAlert" runat="server" CssClass="chara1" Visible="False" ForeColor="Red">No Payment Info Now.</asp:Label>
                        <hr />
                        <span style="font-size: 18px;">detail</span>
                        <br />
                        <br />
                        <table class="chara1 tableborder2" width="100%" id="detail">
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
                    </td>
                </tr>
                <tr>
                    <td height="15">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <iframe width="174" height="189" name="gToday:normal:agenda.js" id="gToday:normal:agenda.js"
        src="../calendar/ipopeng.htm" scrolling="no" frameborder="0" style="z-index: 999;
        left: -500px; visibility: visible; position: absolute; top: -500px; margin-top: -100px;">
    </iframe>
</asp:Content>
