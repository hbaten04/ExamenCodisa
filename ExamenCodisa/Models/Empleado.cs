using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombreCompleto { get; set; }
        public string cedula { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",
         ErrorMessage = "Correo invalido")]
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int idJefe { get; set; }
        public int idArea { get; set; }
        public byte[] foto { get; set; }
        public string fotoToStringUrl { get; set; }
    }
}
