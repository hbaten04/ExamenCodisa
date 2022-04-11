using ExamenCodisa.BLL;
using ExamenCodisa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ExamenCodisa.Controllers
{
    public class AreaController : Controller
    {

        private readonly ILogger<AreaController> _logger;
        //IConfiguration _configuration;
        string apiUrl = string.Empty;

        BArea objBArea = null;
        public AreaController(ILogger<AreaController> logger)
        {
            _logger = logger;
            //_configuration = configuration;
            //apiUrl = _configuration.GetValue<string>("UrlApi");
        }
        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            objBArea = new BArea();
            IEnumerable<Area> listaArea = objBArea.listaAreas();
            return View(listaArea);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Area mArea)
        {


            if (ModelState.IsValid)
            {
                objBArea = new BArea();
                objBArea.upsert(mArea, "1");

                TempData["mensaje"] = "El area se ha creado correctamente";


                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Area mArea)
        {


            if (ModelState.IsValid)
            {
                objBArea = new BArea();
                objBArea.upsert(mArea, "2");

                TempData["mensaje"] = "El area se ha modificado correctamente";


                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArea(int idArea)
        {


                objBArea = new BArea();
                objBArea.eliminar(idArea, "3");

                TempData["mensaje"] = "El area se ha eliminado correctamente";


                return RedirectToAction("Index");
            

            
        }

        [HttpGet]
        [Route("Area/Edit/{idArea:int}")]
        public IActionResult Edit(int idArea)
        {


            if (idArea == 0 )
            {
                return NotFound();
            }

            objBArea = new BArea();
            var mArea = objBArea.listaAreaXId(idArea);

            if(mArea == null)
            {
                return NotFound();
            }

            return View(mArea);
        }

        [HttpGet]
        [Route("Area/Delete/{idArea:int}")]
        public IActionResult Delete(int idArea)
        {


            if (idArea == 0)
            {
                return NotFound();
            }

            objBArea = new BArea();
            var mArea = objBArea.listaAreaXId(idArea);

            if (mArea == null)
            {
                return NotFound();
            }

            return View(mArea);
        }

    }
}
