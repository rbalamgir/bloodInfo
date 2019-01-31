<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="BloodBank.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 331px;
        }
        .auto-style2 {
            width: 23%;
            height: 41px;
            background-color: #CC9900;
        }
        .auto-style4 {
            height: 47px;
            width: 97px;
        }
        .auto-style5 {
            height: 47px;
            width: 163px;
        }
        .auto-style6 {
            background-color: #666666;
        }
    </style>
</head>
<body style="height: 311px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">Email</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="email" runat="server" Height="28px" Width="180px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="resetPasswordButton" runat="server" CssClass="auto-style6" Height="32px" Text="Reset Password" Width="117px" OnClick="resetPasswordButton_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
