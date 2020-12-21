using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PimWebApp.Data
{
    public class Usuario
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="* Obligatorio")]
        public string Direccion { get; set; }

        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="* Formato Incorrecto")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        public string Contraseña { get; set; }

        public string Nota { get; set; }

        public int ID_Categoria { get; set; }

    }
}
