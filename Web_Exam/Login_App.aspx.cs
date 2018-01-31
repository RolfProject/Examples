using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Web_Exam.Model;
using Web_Exam.Controller;

namespace Web_Exam
{
    public partial class Login_App : System.Web.UI.Page
    {
        ConLogin ConLogin = new ConLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarTextBoxs())
                return;

            ClassStatic.UsuarioLogg = ConLogin.LoginUser(TxtCorreo.Text.Trim(), txtPwd.Text.Trim());

            if (ClassStatic.UsuarioLogg != null)
            {
                //Ruting to Home
                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Correo/Contraseña Incorrecta');", true);
            }

        }

        private void Limpiar()
        {
            TxtCorreo.Text = string.Empty;

            txtPwd.Text = string.Empty;
        }

        private bool ValidarTextBoxs()
        {
            if (TxtCorreo.Text.Trim().Length == 0 | txtPwd.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Debe Ingresar Usuario y Contraseña');", true);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}