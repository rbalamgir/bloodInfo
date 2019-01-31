<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BloodBank.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 37%;
            height: 205px;
            background-color: #66FFCC;
        }
        .auto-style2 {
            width: 116px;
        }
        .auto-style3 {
            background-color: #666699;
        }
    </style>
</head>
<body style="height: 289px">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">OldPassword</td>
                <td>
                    <asp:TextBox ID="oldPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">NewPassword</td>
                <td>
                    <asp:TextBox ID="newpassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="confirmPasswordButton" runat="server" CssClass="auto-style3" Height="27px" OnClick="confirmPasswordButton_Click" Text="ConfirmPassword" Width="125px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="cancelButton" runat="server" CssClass="auto-style3" OnClick="cancelButton_Click" Text="Cancel" Width="99px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
