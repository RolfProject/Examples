<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebE_Register.aspx.cs" Inherits="Web_Exam.Views.WebE_Register" MasterPageFile="~/Site.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <title> Registrar </title>
</asp:Content>

<asp:content runat="server" ContentPlaceHolderID="body"> 
    <div class="clasediv">
        <table>

            <tr>
                <td><asp:Label ID="label1" runat="server" Text="Correo:"></asp:Label></td>
                <td><asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="label2" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="TxtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="label3" runat="server" Text="Nombre"></asp:Label></td>
                <td><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                 <td><asp:Label ID="Label5" runat="server" Text="Apellido Paterno:"></asp:Label></td>
                 <td><asp:TextBox runat="server" ID="TxtAp_Paterno" ></asp:TextBox></td>
            </tr>
            <tr>
                  <td><asp:Label ID="Label6" runat="server" Text="Apellido Materno:"></asp:Label></td>
                  <td><asp:TextBox runat="server" ID="TxtAp_Materno"></asp:TextBox></td>
            </tr>
            <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
                    <td>
                        <asp:ScriptManager ID="Script" runat="server" EnableScriptGlobalization="true" CompositeScript-ResourceUICultures="es-MX"></asp:ScriptManager>
                        <asp:CalendarExtender ID="CalendarT" runat="server"  TargetControlID="FechaNac" Animated="true"  PopupButtonID="Calendar_"/>
                        <asp:TextBox runat="server" ID="FechaNac" ReadOnly="false"></asp:TextBox>
                        <asp:ImageButton ID="Calendar_" runat="server" ImageUrl="~/Images/calendar_clipart_.png" ImageAlign="AbsMiddle"/>
                     </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnRegistrar" Text="Registrar" runat="server" OnClick="btnRegistrar_Click" /></td>
                <td><asp:Button ID="btnCancelar"  Text="Cancelar" runat="server" OnClick="btnCancelar_Click" /></td>
                

            </tr>
        </table>
        
    </div>
</asp:content>