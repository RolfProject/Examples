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

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ClassStatic.UsuarioLogg = ConLogin.LoginUser(TxtCorreo.Text, txtPwd.Text);

            if (ClassStatic.UsuarioLogg.Id_User != 0)
            {
                //Ruting to Home
                Response.Redirect("~/Views/Home.aspx");
            }

        }
    }
}