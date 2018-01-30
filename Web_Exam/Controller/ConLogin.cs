using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using Web_Exam.Model;

namespace Web_Exam.Controller
{
    public class ConLogin
    {
        Controller.Connection Connection_ = new Connection();

        public User LoginUser(string Correo,string pwd)
        {
            SqlConnection cnn = new SqlConnection();
            User model = new User();

            string query = string.Empty;

            pwd = EnCrypted_RS._Encrypted.Encrypt(pwd);

            query = "SELECT Id_User,Correo,Pwd,Nombre,Ap_Paterno,Ap_Materno,FechaNac,TipoUsuario" +
                ",FechaAlta,FechaBaja,FechaModificacion,EnableU FROM Users WHERE Correo=@CORREO AND Pwd=@PWD";

            try
            {
                cnn = Connection_.Conexion();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 100;
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@CORREO", Correo);
                cmd.Parameters.AddWithValue("@PWD", pwd);

                cnn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            model.Id_User = Convert.ToInt32(dr[0].ToString());
                            model.Correo = dr[1].ToString();
                            model.Pwd = dr[2].ToString();
                            model.Nombre = dr[3].ToString();
                            model.Ap_Paterno = dr[4].ToString();
                            model.Ap_Materno = dr[5].ToString();
                            model.FechaNac = Convert.ToDateTime(dr[6].ToString());

                            if (dr.GetSqlInt32(7).IsNull)
                                model.TipoUsuario = 0;
                            else
                                model.TipoUsuario = dr.GetInt32(7);
                        }
                }


            }
            catch (Exception ex)
            {

            }

            finally
            {
                if(cnn.State==ConnectionState.Open)
                    cnn.Close();
            }

            return model;

        }

    }
}