using ExamenCodisa.DAO;
using ExamenCodisa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.BLL
{
    public class BTreeview
    {
        Procedimiento objProc = null;
        Execute objExcute = null;
        public List<TreeView> jerarquiaEmp()
        {
            TreeView objTreeview = null;

            List<TreeView> listTreeView = new List<TreeView>();

            objProc = new Procedimiento();
            objExcute = new Execute();
            objProc.NombreProcedimiento = "PRC_JERARQUIA_EMP";

            DataTable dt = new DataTable();

            dt = objExcute.Consultar(objProc);

            foreach (DataRow item in dt.Rows)
            {
                objTreeview = new TreeView();

                objTreeview.id = item["IdEmpleado"].ToString();

                objTreeview.parent= item["IdJefe"].ToString();

                objTreeview.text = item["NombreCompleto"].ToString();

                listTreeView.Add(objTreeview);

            }

            return listTreeView;
        }
    }
}
