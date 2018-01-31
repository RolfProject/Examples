<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_App.aspx.cs" Inherits="Web_Exam.Login_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="~/Content/StyleSheet.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div class="clasediv">
            <table cellpadding="10">
                <tr>
                    <td><asp:Label ID="Label1" Text="Correo" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" Text="Password" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnCancelar" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" /></td>
                    <td><asp:Button ID="btnIngresar"  Text="Ingresar" runat="server" OnClick="btnIngresar_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
