using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using Web_Exam.Model;

namespace Web_Exam.Controller
{
    public class ConUsers
    {
        Connection ClasConexion = new Connection();

        public DataTable ExecOperacionesUser(int op, string correo, string pwd = null, string Nombre = null,
                                              string Ap_Paterno = null, string Ap_Materno = null,DateTime? FechaNac=null,int? TipoUsuario=null)
        {
            DataTable rest = new DataTable();

            SqlConnection cnn = ClasConexion.Conexion();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "OperacionesUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 100;

                cmd.Parameters.AddWithValue("@OP", op);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@Pwd", pwd);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Ap_Paterno", Ap_Paterno);
                cmd.Parameters.AddWithValue("@Ap_Materno", Ap_Materno);
                cmd.Parameters.AddWithValue("@FechaNac", FechaNac);
                cmd.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);

                cnn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    rest.Load(dr);
                }


            }
            catch (Exception ex)
            {
                DataColumn dc = new DataColumn();
                //dt.Columns.Add(dc);
                dc = new DataColumn("codigo");
                rest.Columns.Add(dc);
                dc = new DataColumn("Error");
                rest.Columns.Add(dc);

                DataRow newRow = rest.NewRow();
                newRow["codigo"] = "ER01";
                newRow["Error"] = "*Error*"+"Correo:'"+correo+"'"+ ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            return rest;
        }

        public List<User> SelectedUser(int op,string correo)
        {
            DataTable DT = ExecOperacionesUser(op, correo);

            List<User> rest = new List<User>();

            foreach (DataRow item in DT.Rows)
            {
                User model = new User();
                model.Id_User = Convert.ToInt32(item[0].ToString());
                model.Correo = item[1].ToString();
                model.Pwd = item[2].ToString();
                model.Nombre = item[3].ToString();
                model.Ap_Paterno = item[4].ToString();
                model.Ap_Materno = item[5].ToString();
                model.FechaNac = Convert.ToDateTime(item[6].ToString());

                if(item[7].ToString()==string.Empty)
                    model.TipoUsuario = null;
                else
                    model.TipoUsuario=Convert.ToInt32(item[7].ToString());

                if (item[8].ToString() == string.Empty)
                    model.FechaAlta = null;
                else
                    model.FechaAlta = Convert.ToDateTime(item[8].ToString());

                if (item[9].ToString() == string.Empty)
                    model.FechaBaja = null;
                else
                    model.FechaBaja = Convert.ToDateTime(item[9].ToString());

                if (item[10].ToString() == string.Empty)
                    model.FechaModificacion = null;
                else
                    model.FechaModificacion = Convert.ToDateTime(item[10].ToString());

                rest.Add(model);
            }

            return rest;
        }

        public string RegisterUsers(User item)
        {
            string rest = string.Empty;

            item.Pwd = EnCrypted_RS._Encrypted.Encrypt(item.Pwd);

            try
            {
                DataTable DT = ExecOperacionesUser(2, item.Correo, item.Pwd, item.Nombre, item.Ap_Paterno, item.Ap_Materno, item.FechaNac, item.TipoUsuario);

                foreach (DataRow items in DT.Rows)
                {
                    rest = items[1].ToString();
                }
            }
            catch (Exception ex)
            {
                return "*Error*" + ex.Message;
            }

            return rest;
        }


        public List<TiposUser> GetTypeUser()
        {
            string query = "select idTipo,tipo,descripcion from TiposUsers with(nolock) where Enabled_T=1";


 
        }
    }
}