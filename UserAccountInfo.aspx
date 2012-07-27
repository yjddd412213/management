<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UserAccountInfo.aspx.cs" Inherits="PaymentManagement.UserInfoManagement.UserAccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function GetAllCheckBox(CheckAll) {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    items[i].checked = CheckAll.checked;
                }
            }
        }
    </script>
    <div>
        <h3>
            User Account Info</h3>
        <table>
            <tr>
                <td>
                    Inywhere ID:&nbsp;
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tb_id" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Registration Date:
                </td>
                <td>
                    From&nbsp;<asp:TextBox ID="tb_start" runat="server" onclick="WdatePicker()" Width="70px"></asp:TextBox>
                </td>
                <td>
                    To&nbsp;<asp:TextBox ID="tb_enddate" runat="server" onclick="WdatePicker()" Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="cb_paid" runat="server" Text="Paid" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="gv_UserAccountInfo" runat="server" PageSize="10" AutoGenerateColumns="false"
                DataKeyNames="UserId,Activated,Suspended" AllowPaging="true" BorderWidth="0px"
                OnPageIndexChanging="gv_UserPageChange" OnRowEditing="gv_UserRowEditing" OnRowCancelingEdit="gv_UserRowCanceling"
                OnRowDeleting="gv_UserDeleting" OnRowUpdating="gv_UserRowUpdating" OnRowCommand="gv_UserCommand">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="true" ItemStyle-Width="200px"
                        HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="true" ItemStyle-Width="100px"
                        HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                    <asp:BoundField DataField="Activated" HeaderText="Activated" ItemStyle-CssClass="gv_hid"
                        HeaderStyle-CssClass="gv_hid"></asp:BoundField>
                    <asp:BoundField DataField="CreationTime" HeaderText="CreationTime" ReadOnly="true"
                        ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                    <asp:BoundField DataField="Suspended" HeaderText="Suspended" ItemStyle-CssClass="gv_hid"
                        HeaderStyle-CssClass="gv_hid"></asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Activated" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lbl_activated" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Activated") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_activated" runat="server">
                                <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                <asp:ListItem Text="False" Value="False"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="80px" HeaderText="Suspended" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lbl_suspended" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Suspended") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_suspended" runat="server">
                                <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                <asp:ListItem Text="False" Value="False"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField Text="Detail" CommandName="Detail" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                    </asp:ButtonField>
                    <%--                    <asp:ButtonField ButtonType="Link" CommandName="Edit" Text="Edit"/>
                    <asp:ButtonField ButtonType="Link" CommandName="Delete" Text="Delete"/>--%>
                    <asp:CommandField ShowEditButton="True" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />
                </Columns>
                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </div>
    </div>
    <div>
        <asp:Panel ID="pl_accountInfo" runat="server" Visible="false">
            <h3>
                Product Account Info</h3>
            <div>
                <div style="height: 3px">
                </div>
                <asp:GridView ID="gv_AccountInfo" runat="server" PageSize="10" AutoGenerateColumns="false"
                    OnRowCancelingEdit="gv_accountCacel" OnRowEditing="gv_accountEdit" OnRowUpdating="gv_accountUpdate"
                    DataKeyNames="ApplicationID,UserId,Locked" AllowPaging="true" BorderWidth="0px"
                    OnPageIndexChanging="gv_AccountPageChange">
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="UserId" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left">
                        </asp:BoundField>
                        <asp:BoundField DataField="ApplicationID" HeaderText="ApplicationID" ItemStyle-Width="100px"
                            HeaderStyle-HorizontalAlign="Left" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" ItemStyle-Width="100px"
                            HeaderStyle-HorizontalAlign="Left" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="PaymentTime" HeaderText="PaymentTime" ItemStyle-Width="100px"
                            HeaderStyle-HorizontalAlign="Left" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="Locked" ItemStyle-CssClass="gv_hid" HeaderStyle-CssClass="gv_hid" />
                        <asp:TemplateField ItemStyle-Width="80px" HeaderText="Locked" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Locked" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Locked") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Locked" runat="server">
                                    <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                    <asp:ListItem Text="False" Value="False"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <asp:Label ID="lbl_noinfo" runat="server" Text="Product Account Info does not exist"
                Visible="false"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
