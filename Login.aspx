<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="PaymentManagement.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="login">
        <table>
            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Valid Code:
                </td>
                <td>
                    <asp:TextBox ID="txtValid" runat="server" Width="50px"></asp:TextBox>
                    <img id="Img1" src="ValidImage.aspx" alt="Valid Code" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnLogin" CssClass="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
