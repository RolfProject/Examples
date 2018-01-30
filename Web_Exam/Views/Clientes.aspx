<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Web_Exam.Views.Clientes" MasterPageFile="~/Site.Master" %>

<asp:content ID="Content1" runat="server" ContentPlaceHolderID="head">

        <script type="text/javascript">

            function ConfirmDelete() {
                if (confirm("¿Estas Seguro de Eliminar el cliente?") == true) {
                    return true;
                }
                else
                    return false;
            }

            window.addEventListener("load", function () {
            document.getElementById('<%=Edad.ClientID%>').addEventListener("keypress", soloNumeros, false);
            });

            function soloNumeros(e) {
                var key = window.event ? e.which : e.keyCode;
                if (key < 48 || key > 57) {
                    e.preventDefault();}
            }

    </script>
</asp:content>

<asp:content runat="server" ContentPlaceHolderID="body">
    <div class="clasediv">
                <table >
                  <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="txtName" ></asp:TextBox>  </td>
                  </tr>
                  <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Apellido Paterno:"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="Ap_Paterno" ></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Apellido Materno:"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="Ap_Materno"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
                    <td>
                        <asp:ScriptManager ID="Script" runat="server" EnableScriptGlobalization="true" CompositeScript-ResourceUICultures="es-MX"></asp:ScriptManager>
                        <asp:CalendarExtender ID="CalendarT" runat="server"  TargetControlID="FechaNac" Animated="true"  PopupButtonID="Calendar_"/>
                        <asp:TextBox runat="server" ID="FechaNac" ReadOnly="false"></asp:TextBox>
                        <asp:ImageButton ID="Calendar_" runat="server" ImageUrl="~/Images/calendar_clipart_.png" ImageAlign="AbsMiddle"/>
                     </td>
                  </tr>
                  <tr>

                    <td><asp:Label ID="Label5" runat="server" Text="Edad:" ></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="Edad" MaxLength="3"></asp:TextBox></td>
                  </tr>
                </table>
            <br />

        <asp:Button runat="server" ID="AddClient" Text="Agregar Cliente" OnClick="AddClient_Click" />
        <asp:Button runat="server" ID="Insertar" Text="Insertar" OnClick="Insertar_Click"/>
        <asp:Button runat="server" ID="Update" Text="Refresh" OnClick="Update_Click"/>
        <asp:Button runat="server" ID="UpdateData" Text="Actualizar" OnClick="UpdateData_Click"/>
     </div>
         <br />  
     <div id="ClientesDG" runat="server" class="clasediv">
        <asp:DataGrid ID="DGClientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"  AllowSorting="True" OnEditCommand="DGClientes_EditCommand" OnDeleteCommand="DGClientes_DeleteCommand">
            <Columns> 
                <asp:BoundColumn DataField="Nombre" HeaderText="Name" ItemStyle-Wrap="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="Ap_Paterno" HeaderText="Paterno" ItemStyle-Wrap="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="Ap_Materno" HeaderText="Materno" ItemStyle-Wrap="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="FechaNac" HeaderText="Fecha Nacimiento" ItemStyle-Wrap="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="Edad" HeaderText="Edad" ItemStyle-Wrap="false"></asp:BoundColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit" runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="Delete" runat="server" Text="Delete" OnClientClick="return ConfirmDelete(this);" CommandName="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <HeaderStyle CssClass="HeaderStyle"/>
            <ItemStyle CssClass="ItemStyle" />
        </asp:DataGrid>
     </div>
</asp:content>

<asp:Content runat="server" ContentPlaceHolderID="footer">


</asp:Content>
