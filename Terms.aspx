<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Terms.aspx.cs" Inherits="PaymentManagement.Terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maintd">
        <h3>
            Terms</h3>
        <div id="internBasic">
            <table border="0" class="chara1 tableborder1" width="100%">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgPress" runat="server" Width="88%" CellPadding="2" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10" DataKeyField="TermId" HorizontalAlign="Center"
                            CssClass="chara1 tableborder3" BorderWidth="0px" OnSelectedIndexChanged="dgPress_SelectedIndexChanged"
                            OnDeleteCommand="dgPress_DeleteCommand" OnPageIndexChanged="dgPress_PageIndexChanged">
                            <AlternatingItemStyle BackColor="#effaf7"></AlternatingItemStyle>
                            <Columns>
                                <asp:ButtonColumn Text="Edit" HeaderText="Edit" CommandName="Select" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete" HeaderStyle-CssClass="celltitle2"
                                    ItemStyle-CssClass="cell4"></asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="Type" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbltype" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Type") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Description" HeaderStyle-CssClass="celltitle2" ItemStyle-CssClass="cell8">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbldescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" CssClass="pager"></PagerStyle>
                        </asp:DataGrid>
                        <asp:Label ID="lblAlert" runat="server" CssClass="chara1" Visible="False" ForeColor="Red">No term now.</asp:Label>
                        <hr />
                        <span style="font-size: 18px;">&nbsp;term detail</span>
                        <br />
                        <br />
                        <table class="chara1 tableborder2" width="100%" id="detail">
                            <tr>
                                <td valign="top">
                                    Type:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxType" runat="server" CssClass="input4" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Description
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxDescription" runat="server" CssClass="input4" Width="200px"></asp:TextBox>
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
