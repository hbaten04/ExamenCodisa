using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Models
{
    public class DatosExtraEmp
    {
        public Empleado empleado { get; set; } = new Empleado();
        public int edad { get; set; }
        public int antiguedad_empresa { get; set; }
        public int idEmpleado { get; set; }
    }
}
