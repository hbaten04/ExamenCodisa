using ExamenCodisa.DAO;
using ExamenCodisa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.BLL
{
    public class BEmpleado
    {
        Procedimiento objProc = null;
        Execute objExcute = null;
        public List<Empleado> listaEmpleadoXArea(int pIdArea)
        {
            List<Empleado> listEmpleado = new List<Empleado>();
            Empleado objEmpleado = null;
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_LISTA_EMPLEADO_X_AREA";

            objProc.Parametros.Add(new Parametro { Nombre = "@pIdArea", Valor = pIdArea, Tipo = DbType.Int32, Out = false });

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {

                objEmpleado = new Empleado();

                objEmpleado.idEmpleado = Convert.ToInt32(item["IdEmpleado"]);

                objEmpleado.nombreCompleto = item["NombreCompleto"].ToString();

                objEmpleado.cedula = item["Cedula"].ToString();

                objEmpleado.correo = item["correo"].ToString();

                objEmpleado.fechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());

                objEmpleado.fechaIngreso = Convert.ToDateTime(item["FechaIngreso"].ToString());

                objEmpleado.idJefe = item["IdJefe"] is DBNull ? 0 : Convert.ToInt32(item["IdJefe"]);

                objEmpleado.idArea = Convert.ToInt32(item["IdArea"]);


                if (item["Foto"] is DBNull)
                {
                    objEmpleado.fotoToStringUrl = "/Img/sinFoto.png";
                }
                else
                {
                    objEmpleado.foto = (byte[])(item["Foto"]);
                    objEmpleado.fotoToStringUrl = Convert.ToBase64String(objEmpleado.foto);

                    objEmpleado.fotoToStringUrl = string.Format("data:image/jpg;base64,{0}", objEmpleado.fotoToStringUrl);
                }

                //objEmpleado.foto = item["Foto"] is DBNull ?  (byte[])(item["Foto"]);

                //objEmpleado.fotoToStringUrl = Convert.ToBase64String(objEmpleado.foto);

                //objEmpleado.fotoToStringUrl = string.Format("data:image/jpg;base64,{0}", objEmpleado.fotoToStringUrl);



                //listEmpleado.Add(new Empleado
                //{
                //    idEmpleado = Convert.ToInt32(item["IdEmpleado"])
                //    ,
                //    nombreCompleto = item["NombreCompleto"].ToString()
                //    ,
                //    cedula = item["Cedula"].ToString()
                //    ,
                //    correo = item["correo"].ToString()
                //    ,
                //    fechaNacimiento = item["FechaNacimiento"].ToString()
                //    ,
                //    fechaIngreso = item["FechaIngreso"].ToString()
                //    ,
                //    idJefe = item["IdJefe"] is DBNull ? 0 : Convert.ToInt32(item["IdJefe"])
                //    ,
                //    idArea = Convert.ToInt32(item["IdArea"])
                //    ,
                //    foto = (byte[])(item["Foto"])


                //});

                listEmpleado.Add(objEmpleado);
            }

            return listEmpleado;
        }
        public Empleado listaEmpleadoXId(int pIdEmpleado)
        {
          
            Empleado objEmpleado = null;
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_OBTIENE_EMP_X_ID";

            objProc.Parametros.Add(new Parametro
            {
                Nombre = "@pIdEmpleado",
                Valor = pIdEmpleado,
                Tipo = DbType.Int32,
                Out = false
            });

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {

                objEmpleado = new Empleado();

                objEmpleado.idEmpleado = Convert.ToInt32(item["IdEmpleado"]);

                objEmpleado.nombreCompleto = item["NombreCompleto"].ToString();

                objEmpleado.cedula = item["Cedula"].ToString();

                objEmpleado.correo = item["correo"].ToString();

                objEmpleado.fechaNacimiento =Convert.ToDateTime(item["FechaNacimiento"].ToString());

                objEmpleado.fechaIngreso = Convert.ToDateTime(item["FechaIngreso"].ToString());

                objEmpleado.idJefe = item["IdJefe"] is DBNull ? 0 : Convert.ToInt32(item["IdJefe"]);

                objEmpleado.idArea = Convert.ToInt32(item["IdArea"]);

                objEmpleado.foto = item["Foto"] is DBNull ? null : (byte[])(item["Foto"]);

                //if (item["Foto"] is DBNull)
                //{
                //    objEmpleado.fotoToStringUrl = "/Img/sinFoto.png";
                //}
                //else
                //{
                //    objEmpleado.foto = (byte[])(item["Foto"]);
                //    objEmpleado.fotoToStringUrl = Convert.ToBase64String(objEmpleado.foto);

                //    objEmpleado.fotoToStringUrl = string.Format("data:image/jpg;base64,{0}", objEmpleado.fotoToStringUrl);
                //}



            }

            return objEmpleado;
        }
        public List<Empleado> listaEmpleadoCBO()
        {
            List<Empleado> listEmpleado = new List<Empleado>();

            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_LISTA_EMPLEADO_CBO";

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {
                listEmpleado.Add(new Empleado
                {
                    idEmpleado = Convert.ToInt32(item["IdEmpleado"])
                    ,
                    nombreCompleto = item["NombreCompleto"].ToString()

                });
            }

            return listEmpleado;
        }
        public DatosExtraEmp datosExtraEmp(int pIdEmpleado)
        {
            DatosExtraEmp listEmpleado = new DatosExtraEmp();

            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_DATOS_EXTRAS_EMP";

            objProc.Parametros.Add(new Parametro { Nombre = "@pIdEmpleado", Valor = pIdEmpleado, Tipo = DbType.Int32, Out = false });

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            listEmpleado.idEmpleado = Convert.ToInt32(dt.Rows[0]["IdEmpleado"]);
            listEmpleado.empleado.nombreCompleto = dt.Rows[0]["NombreCompleto"].ToString();
            listEmpleado.edad = Convert.ToInt32(dt.Rows[0]["EDAD"]);
            listEmpleado.antiguedad_empresa = Convert.ToInt32(dt.Rows[0]["ANTIGUEDAD_LABORAL"]);

            if (dt.Rows[0]["Foto"] is DBNull)
            {
                listEmpleado.empleado.fotoToStringUrl = "/Img/sinFoto.png";
            }
            else
            {
                listEmpleado.empleado.foto = (byte[])(dt.Rows[0]["Foto"]);
                listEmpleado.empleado.fotoToStringUrl = Convert.ToBase64String(listEmpleado.empleado.foto);

                listEmpleado.empleado.fotoToStringUrl = string.Format("data:image/jpg;base64,{0}", listEmpleado.empleado.fotoToStringUrl);
            }


            return listEmpleado;
        }
        public void upsert(Empleado empleadoEntity, string pOp)
        {
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_MANTENIMIENTO_EMPLEADO";

            objProc.Parametros.Add(new Parametro { Nombre = "pOp", Valor = pOp, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdEmpleado", Valor = empleadoEntity.idEmpleado, Tipo = DbType.Int32, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pNombreCompleto", Valor = empleadoEntity.nombreCompleto, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pCedula", Valor = empleadoEntity.cedula, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pCorreo", Valor = empleadoEntity.correo, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pFechaNacimiento", Valor = empleadoEntity.fechaNacimiento.ToString("yyyy-MM-dd"), Tipo = DbType.Date, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pFechaIngreso", Valor = empleadoEntity.fechaIngreso.ToString("yyyy-MM-dd"), Tipo = DbType.Date, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdJefe", Valor = empleadoEntity.idJefe, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdArea", Valor = empleadoEntity.idArea, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pFoto", Valor = empleadoEntity.foto, Tipo = DbType.Binary, Out = false });




            objExcute.Upsert(objProc);

        }

        public void asociarHabilidad(EmpleadoHabilidad empleadoHabilidad)
        {
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_ASOCIAR_HABILIDAD";

            objProc.Parametros.Add(new Parametro { Nombre = "@pIdEmpleado", Valor = empleadoHabilidad.idEmpleado, Tipo = DbType.Int32, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pNombreHabilidad", Valor = empleadoHabilidad.nombreHabilidad, Tipo = DbType.Int32, Out = false });


            objExcute.Upsert(objProc);

        }
        public void eliminar(int pIdEmpleado, string pOp)
        {
            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_MANTENIMIENTO_EMPLEADO";

            objProc.Parametros.Add(new Parametro { Nombre = "pOp", Valor = pOp, Tipo = DbType.String, Out = false });
            objProc.Parametros.Add(new Parametro { Nombre = "@pIdEmpleado", Valor = pIdEmpleado, Tipo = DbType.Int32, Out = false });
            




            objExcute.Upsert(objProc);

        }
    }
}
