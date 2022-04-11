using ExamenCodisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.BLL
{
    public class BEmpleadoArea
    {
        public EmpleadoArea listaEmpleadoArea(int idArea = 0)
        {
            BArea objArea = new BArea();
            BEmpleado objEmpleado = new BEmpleado();

            EmpleadoArea mEmpleadoArea = new EmpleadoArea()
            {
                listEmpleado = objEmpleado.listaEmpleadoXArea(idArea)
                ,
                listArea = objArea.listaAreas()
            };

            return mEmpleadoArea;
        }
    }
}
