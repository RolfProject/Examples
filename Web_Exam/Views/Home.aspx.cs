using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Exam.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClassStatic.UsuarioLogg == null)
                Response.Redirect("~/Login_App.aspx");

            Page.Title = "HOME";
        }

        protected void SingOut_Click(object sender, EventArgs e)
        {
            ClassStatic.UsuarioLogg = null;

            Response.Redirect("~/Login_App.aspx");

        }
    }
}