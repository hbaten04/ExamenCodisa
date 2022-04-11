using ExamenCodisa.DAO;
using ExamenCodisa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.BLL
{
    public class BArea
    {
        Procedimiento objProc = null;
        Execute objExcute = null; 
        public void upsert(Area areaEntity, string pOp)
        {
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_MANTENIMIENTO_AREA";

            objProc.Parametros.Add(new Parametro { Nombre = "pOp", Valor = pOp, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdArea", Valor = areaEntity.idArea, Tipo = DbType.Int32, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pNombre", Valor = areaEntity.nombre, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pDescripcion", Valor = areaEntity.descripcion, Tipo = DbType.String, Out = false });




            objExcute.Upsert(objProc);

        }
        public void eliminar(int pIdArea, string pOp)
        {
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_MANTENIMIENTO_AREA";

            objProc.Parametros.Add(new Parametro { Nombre = "pOp", Valor = pOp, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdArea", Valor = pIdArea, Tipo = DbType.Int32, Out = false });





            objExcute.Upsert(objProc);

        }

        public List<Area> listaAreas ()
        {
            List<Area> listArea = new List<Area>();

            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_LISTA_AREAS";

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {
                listArea.Add(new Area
                {
                    idArea = Convert.ToInt32(item["IdArea"])
                    ,
                    nombre = item["Nombre"].ToString()
                    ,
                    descripcion = item["Descripcion"].ToString()
                });
            }

            return listArea;
        }
        public Area listaAreaXId(int pIdArea)
        {
            Area objArea = null;

            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_LISTA_AREAS_X_ID";

            objProc.Parametros.Add(new Parametro { Nombre = "@pIdArea", Valor = pIdArea, Tipo = DbType.Int32, Out = false });

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {
                objArea = new Area();

                objArea.idArea = Convert.ToInt32(item["IdArea"]);

                objArea.nombre = item["Nombre"].ToString();

                objArea.descripcion = item["Descripcion"].ToString();
                
            }

            return objArea;
        }
    }
}
