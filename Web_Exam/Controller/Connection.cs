using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace Web_Exam.Controller
{
    public class Connection
    {

        public Connection() { }

        public SqlConnection Conexion()
        {
            SqlConnection con = new SqlConnection();

            con = pvCon_01.Conexion.getconexion();

            return con;
        }


    }
}