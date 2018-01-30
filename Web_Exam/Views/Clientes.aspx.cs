using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using Web_Exam.Controller;
using Web_Exam.Model;
using System.IO;

namespace Web_Exam.Views
{
    public partial class Clientes : System.Web.UI.Page
    {
        //Connection clsConection = new Connection();

        ConClientes controller = new ConClientes();

        public static Cliente ModeloSeleccionado = new Cliente();

        public static List<Cliente> ListClientes = new List<Cliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            FechaNac.Attributes.Add("readonly", "readonly");
        }

        protected void AddClient_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty | Ap_Paterno.Text == string.Empty | Ap_Materno.Text == string.Empty | FechaNac.Text == string.Empty | Edad.Text == string.Empty)
                return;


            Cliente model = new Cliente();

            model.Nombre =      txtName.Text;
            model.Ap_Paterno =  Ap_Paterno.Text;
            model.Ap_Materno =  Ap_Materno.Text;
            model.FechaNac =    Convert.ToDateTime(FechaNac.Text);
            model.Edad =        Convert.ToInt32(Edad.Text);

            var item = ListClientes.Where(c => c.Nombre == model.Nombre & c.Ap_Materno == model.Ap_Materno & c.Ap_Paterno == model.Ap_Paterno);

            if (item.Count() > 0)
                return;

            ListClientes.Add(model);

            LlenarGrid();
        }

        public void LlenarGrid()
        {
            DGClientes.DataSource = ListClientes;
            DGClientes.DataBind();

            LimpiarCajas();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            string s = controller.InsertCliente(ListClientes);

            if (s.Contains("Error"))
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            ListClientes = controller.GetClientes();
            LlenarGrid();
        }

        protected void DGClientes_EditCommand(object source, DataGridCommandEventArgs e)
        {
            LlenarLabels(e.Item.ItemIndex);
        }

        private void LlenarLabels(int index)
        {
            Cliente model = new Cliente();

            model = ListClientes[index];

            txtName.Text = model.Nombre;
            Ap_Paterno.Text = model.Ap_Paterno;
            Ap_Materno.Text = model.Ap_Materno;
            FechaNac.Text = model.FechaNac.ToString();
            Edad.Text = model.Edad.ToString();

            ModeloSeleccionado = model;

        }

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            if (ModeloSeleccionado.IdCliente == 0)
                return;

            ModeloSeleccionado.Nombre = txtName.Text;
            ModeloSeleccionado.Ap_Paterno = Ap_Paterno.Text;
            ModeloSeleccionado.Ap_Materno = Ap_Materno.Text;
            ModeloSeleccionado.FechaNac = Convert.ToDateTime(FechaNac.Text);
            ModeloSeleccionado.Edad = Convert.ToInt32(Edad.Text);

            string s = controller.InsertCliente(ListClientes, ModeloSeleccionado);

            if (s.Contains("Error"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "');", true);
                return;
            }

            ListClientes = controller.GetClientes();
            LlenarGrid();
        }

        private void LimpiarCajas()
        {
            txtName.Text = string.Empty;
            Ap_Paterno.Text = string.Empty;
            Ap_Materno.Text = string.Empty;
            FechaNac.Text = string.Empty;
            Edad.Text = string.Empty;
        }

        protected void DGClientes_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            Cliente model = new Cliente();

            model = ListClientes[e.Item.ItemIndex];

            bool res = controller.DeleteClient(model);

            if (res)
            {
                ListClientes.Remove(model);

                LlenarGrid();
            }
        }
    }
}