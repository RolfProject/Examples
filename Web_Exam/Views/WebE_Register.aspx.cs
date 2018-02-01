using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Web_Exam.Controller;

using Web_Exam.Model;

namespace Web_Exam.Views
{
    public partial class WebE_Register : System.Web.UI.Page
    {
        ConUsers conUsers = new ConUsers();
        ConLogin ConLogin = new ConLogin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClassStatic.UsuarioLogg == null)
                Response.Redirect("~/Login_App.aspx");

            FechaNac.Attributes.Add("readonly", "readonly");

            Page.Title = "Register";


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            User model = new User();
            model.Nombre =      TxtNombre.Text;
            model.Pwd =         TxtPwd.Text;
            model.Correo =      TxtCorreo.Text;
            model.Ap_Materno =  TxtAp_Materno.Text;
            model.Ap_Paterno =  TxtAp_Paterno.Text;
            model.FechaNac =  Convert.ToDateTime(FechaNac.Text);

            string rest = conUsers.RegisterUsers(model);

            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('" + rest + "');", true);

            if (rest.Contains("*OK*"))
                Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateDatos()
        {
            return false;
        }

        private void Limpiar()
        {
            TxtNombre.Text = string.Empty;
            TxtPwd.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtAp_Materno.Text = string.Empty;
            TxtAp_Paterno.Text = string.Empty;
            FechaNac.Text = string.Empty;

            Response.Redirect("~/Home.aspx");
        }

        private void ValidateTipo(int tipo)
        {
            if (ClassStatic.UsuarioLogg.TipoUsuario == 1)
            {
                lblTipo.Visible = false;
                CmbTipos.Visible = false;
            }
            else
            {
                lblTipo.Visible = true;
                CmbTipos.Visible = true;


            }
        }
    }
}