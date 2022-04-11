using ExamenCodisa.BLL;
using ExamenCodisa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Controllers
{
    public class TreeviewController : Controller
    {
        public IActionResult Index()
        {
            List<TreeView> nodes = new List<TreeView>();

            //Loop and add the Parent Nodes.
            //foreach (VehicleType type in this.Context.VehicleTypes)
            //{
            //    nodes.Add(new TreeView { id = type.Id.ToString(), parent = "#", descripcion = type.Name });
            //}

            ////Loop and add the Child Nodes.
            //foreach (VehicleSubType subType in this.Context.VehicleSubTypes)
            //{
            //    nodes.Add(new TreeView { id = subType.VehicleTypeId.ToString() + "-" + subType.Id.ToString(), parent = subType.VehicleTypeId.ToString(), descripcion = subType.Name });
            //}

            BTreeview bTreeview = new BTreeview();

            nodes = bTreeview.jerarquiaEmp();

            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string selectedItems)
        {
            List<TreeView> items = JsonConvert.DeserializeObject<List<TreeView>>(selectedItems);
            return RedirectToAction("Index");
        }
    }
}
