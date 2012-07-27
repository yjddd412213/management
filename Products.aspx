<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="PaymentManagement.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maintd">
        <h3>
            Products</h3>
        <div id="internBasic">
            <table border="0" class="chara1 tableborder1" width="100%">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgPress" runat="server" Width="88%" CellPadding="2" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10" DataKeyField="ProductId" HorizontalAlign="Center"
                            CssClass="chara1 tableborder3" BorderWidth="0px" OnSelectedIndexChanged="dgPress_SelectedIndexChanged"
                            OnDeleteCommand="dgPress_DeleteCommand" OnPageIndexChanged="dgPress_PageIndexChanged">
                            <AlternatingItemStyle BackColor="#effaf7"></AlternatingItemStyle>
                            <Columns>
                                <asp:ButtonColumn Text="Edit" HeaderText="Edit" CommandName="Select" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="ProductId" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblpid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ProductId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ProductName" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ProductName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="IsVip" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="LblVIP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsVip") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                        </asp:DataGrid>
                        <asp:Label ID="lblAlert" runat="server" CssClass="chara1" Visible="False" ForeColor="Red">No Products Now.</asp:Label>
                        <hr />
                        <h3>products detail</h3>
                        <br />
                        <table class="chara1 tableborder2" width="100%" id="detail">
                            <tr>
                                <td valign="top" style="width: 100px">
                                    ProductId:
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_productid" runat="server" CssClass="input4" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    ProductName:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input4" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="CbxIsVip" runat="server" Text="Is vip" />
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
