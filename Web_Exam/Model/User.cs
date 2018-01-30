using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web_Exam.Model
{
    public class User
    {

        [Browsable(false)]
        public int Id_User { get; set; }

        public string Correo { get; set; }

        public string Pwd { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Apellido Paterno")]
        public string Ap_Paterno { get; set; }

        [DisplayName("Apellido Materno")]
        public string Ap_Materno { get; set; }

        public int? TipoUsuario { get; set; }

        public DateTime FechaNac { get; set; }

        [Browsable(false)]
        public DateTime? FechaAlta { get; set; }

        [Browsable(false)]
        public DateTime? FechaBaja { get; set; }

        [Browsable(false)]
        public DateTime? FechaModificacion { get; set; }

        [Browsable(false)]
        public bool EnableU { get; set; }

    }
}