<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BloodBank.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 28%;
            height: 133px;
            background-color: #00FF99;
        }
        .auto-style4 {
            width: 710px;
            height: 28px;
        }
        .auto-style5 {
            width: 710px;
            height: 24px;
        }
        .auto-style6 {
            margin-left: 79px;
        }
        .auto-style7 {
            width: 452px;
            height: 28px;
        }
        .auto-style8 {
            width: 452px;
            height: 24px;
        }
        .auto-style9 {
            height: 378px;
        }
        .auto-style10 {
            background-color: #0066CC;
        }
    </style>
</head>
<body style="height: 393px">
    <form id="form1" runat="server">
        <div class="auto-style9">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7">UserName</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="userName" runat="server" CssClass="auto-style6" Height="26px" Width="164px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Password</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="password" runat="server" CssClass="auto-style6" Height="26px" Width="164px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>


            </table>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="Login_Button" runat="server" Height="37px" OnClick="Login_Button_Click" Text="Login" Width="81px" CssClass="auto-style10" />
            <br />
            <br />
            <asp:Label ID="lblstatus1" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:HyperLink ID="forgetPassword" runat="server" ForeColor="#3333FF" NavigateUrl="~/PasswordReset.aspx">ForgetPassword?</asp:HyperLink>
            <br />
            <br />
            <br />
            <asp:HyperLink ID="registerHyperLink" runat="server" NavigateUrl="~/Registration/BloodBank SignUp.aspx">Click here to register</asp:HyperLink>
&nbsp; if u haven&#39;t register yet<br />
            <br />
    </form>
</body>
</html>
