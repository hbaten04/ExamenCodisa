using ExamenCodisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Repository
{
    interface IService
    {
        IEnumerable<EmpleadoHabilidad> getListaHabilidad(int pIdEmpleado);
    }
}
