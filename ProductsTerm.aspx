<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductsTerm.aspx.cs" Inherits="PaymentManagement.ProductsTerm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maintd">
        <h3>
            ProductsTerm</h3>
        <div id="internBasic">
            <table border="0" class="chara1 tableborder1" width="100%">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgPress" runat="server" Width="88%" CellPadding="2" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10" DataKeyField="Id" HorizontalAlign="Center" CssClass="chara1 tableborder3"
                            BorderWidth="0px" OnSelectedIndexChanged="dgPress_SelectedIndexChanged" OnDeleteCommand="dgPress_DeleteCommand"
                            OnPageIndexChanged="dgPress_PageIndexChanged">
                            <AlternatingItemStyle BackColor="#effaf7"></AlternatingItemStyle>
                            <Columns>
                                <asp:ButtonColumn Text="Edit" HeaderText="Edit" CommandName="Select" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="ProductTermID" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LbProductTermid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Product" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LbProduct" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ProductName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Is effective" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LblEffective" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsEffective") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                        </asp:DataGrid>
                        <asp:Label ID="lblAlert" runat="server" CssClass="chara1" Visible="False" ForeColor="Red">No term now.</asp:Label>
                        <hr />
                        <span style="font-size: 18px;">&nbsp;detail</span>
                        <br />
                        <br />
                        <table class="chara1 tableborder2" width="100%" id="detail">
                            <tr>
                                <td valign="top">
                                    ProductTermID:
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_producttermid" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Products:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProducts" runat="server" DataTextField="ProductName" Width="200px"
                                        DataValueField="ProductId" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Terms
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTerms" runat="server" Width="200px" DataTextField="Type"
                                        DataValueField="TermId" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxAmount" runat="server" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="CbxIsEffective" runat="server" Text="Is effective" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnAddOrModify" runat="server" CssClass="input2" Text="Add" OnClick="btnAddOrModify_Click">
                                    </asp:Button>&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="input2"
                                        Visible="False" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
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
</asp:Content>
