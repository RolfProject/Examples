using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

using Web_Exam.Model;



namespace Web_Exam.Controller
{

    public class ConClientes
    {
        Connection ClasConexion = new Connection();
        _Encrypted ClsEncryp = new _Encrypted();
        
        public ConClientes() 
        {}

        

        public string InsertCliente(List<Cliente> ListClientes, Cliente model = null)
        {
            ListClientes.RemoveAll(x => x.Insert == true);

            DataTable dt = new DataTable("Clientes");
            DataColumn dc = new DataColumn();
            //dt.Columns.Add(dc);
            dc = new DataColumn("IdCliente");
            dt.Columns.Add(dc);
            dc = new DataColumn("Nombre");
            dt.Columns.Add(dc);
            dc = new DataColumn("Ap_Paterno");
            dt.Columns.Add(dc);
            dc = new DataColumn("Ap_Materno");
            dt.Columns.Add(dc);
            dc = new DataColumn("FechaNac");
            dt.Columns.Add(dc);
            dc = new DataColumn("Edad");
            dt.Columns.Add(dc);

            SqlConnection cnn = ClasConexion.Conexion();

            if (model == null)
            {

                foreach (Cliente item in ListClientes)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["IdCliente"] = null;
                    newRow["Nombre"] = item.Nombre;
                    newRow["Ap_Paterno"] = item.Ap_Paterno;
                    newRow["Ap_Materno"] = item.Ap_Materno;
                    newRow["FechaNac"] = item.FechaNac;
                    newRow["Edad"] = item.Edad;
                    dt.Rows.Add(newRow);
                }

                try
                {
                    cnn.Open();

                    using (SqlBulkCopy bulkC = new SqlBulkCopy(cnn))
                    {
                        bulkC.DestinationTableName = dt.TableName;

                        bulkC.WriteToServer(dt);
                    }

                    cnn.Close();
                    cnn.Dispose();

                    return "OK";

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Alerta", @"alert('" + ex.Message + "In InsertClientes"+" ');", true);
                    return "Error:" + ex.Message;
                }
            }
            else if (model.IdCliente != 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["IdCliente"] = model.IdCliente;
                newRow["Nombre"] = model.Nombre;
                newRow["Ap_Paterno"] = model.Ap_Paterno;
                newRow["Ap_Materno"] = model.Ap_Materno;
                newRow["FechaNac"] = model.FechaNac;
                newRow["Edad"] = model.Edad;
                dt.Rows.Add(newRow);

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Create table #TempClientes (IdCliente int,Nombre varchar(50),Ap_Paterno varchar(50),Ap_Materno varchar(50),FechaNac datetime,Edad int)";
                    cmd.Connection = cnn;

                    cnn.Open();

                    cmd.ExecuteNonQuery();

                    using (SqlBulkCopy bulk = new SqlBulkCopy(cnn))
                    {
                        bulk.DestinationTableName = "#TempClientes";
                        bulk.WriteToServer(dt);
                        bulk.Close();
                    }

                    string query = "UPDATE C SET  C.Ap_Materno=T.Ap_Materno, C.Ap_Paterno=T.Ap_Paterno, "
                    + " C.Nombre=T.Nombre, Edad=T.Edad, C.FechaNac=T.FechaNac  FROM "
                    + dt.TableName + " C JOIN #TempClientes T ON T.IdCliente=C.IdCliente ; DROP TABLE #TempClientes; ";

                    cmd.CommandText = query;
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                    cnn.Dispose();

                    return "OK";

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Alerta", @"alert('" + ex.Message + "In UpdateClientes" + " ');", true);
                    return "Error:" + ex.Message;
                }

            }

            return "OK";
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> res = new List<Cliente>();
            string query = "select IdCliente,Nombre,Ap_Paterno,Ap_Materno,FechaNac,Edad from Clientes with (nolock)";

            SqlDataReader dr = null;

            try
            {
                SqlConnection cnn = ClasConexion.Conexion();

                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 100;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                    while (dr.Read())
                    {
                        Cliente model = new Cliente();
                        model.IdCliente = Convert.ToInt32(dr[0].ToString());
                        model.Nombre = dr[1].ToString();
                        model.Ap_Paterno = dr[2].ToString();
                        model.Ap_Materno = dr[3].ToString();
                        model.FechaNac = Convert.ToDateTime(dr[4].ToString());
                        model.Edad = Convert.ToInt32(dr[5].ToString());
                        model.Insert = true;
                        res.Add(model);
                    }

                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Alerta Error!", @"alert('" + ex.Message + " ');", true);
            }

            return res;
        }

        public bool DeleteClient(Cliente model)
        {
            int rest = 0;
            string query = string.Format("Delete From Clientes Where IdCliente={0}", model.IdCliente);

            try
            {
                SqlConnection cnn = ClasConexion.Conexion();

                //cnn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cnn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                rest = cmd.ExecuteNonQuery();

                if (rest > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(null, this.GetType(), "Alerta Error!", @"alert('" + ex.Message + " ');", true);
                return false;
            }
        }
    }
}