using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Models
{
    public class EmpleadoArea
    {
        public List<Empleado> listEmpleado { get; set; }
        public List<Area> listArea { get; set; }

        public int idEmpleadoArea { get; set; }
    }
}
