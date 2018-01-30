using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web_Exam.Model
{
    public class Cliente
    {
        [Browsable(false)]
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Apellido Paterno")]
        public string Ap_Paterno { get; set; }

        [DisplayName("Apellido Materno")]
        public string Ap_Materno { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNac { get; set; }

        public int Edad { get; set; }

        [Browsable(false)]
        public bool Insert { get; set; }

    }
}