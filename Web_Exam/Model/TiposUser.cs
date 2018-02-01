using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Exam.Model
{
    public class TiposUser
    {
        public int idTipo { get; set; }

        public string   tipo		{get;set;}

        public string descripcion { get; set; }

        public bool Enabled_T { get; set; }

    }
}