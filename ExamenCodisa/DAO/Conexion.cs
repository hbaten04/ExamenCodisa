using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.DAO
{
    public class Conexion
    {
        public SqlConnection oCnx = null;

        
        public Conexion()
        {
            oCnx = new SqlConnection(ConfigurationManager.AppSettings["conexion"].ToString());
        }

        public void abrirConexion()
        {
            if (oCnx.State == ConnectionState.Closed || oCnx.State == ConnectionState.Broken)
                oCnx.Open();
        }
        public void cerrarConexion()
        {
            if (oCnx.State == ConnectionState.Open)
                oCnx.Close();
        }
    }
}
