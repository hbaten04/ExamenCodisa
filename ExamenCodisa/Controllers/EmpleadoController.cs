using ExamenCodisa.BLL;
using ExamenCodisa.Models;
using ExamenCodisa.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCodisa.Controllers
{
    public class EmpleadoController : Controller
    {
        BEmpleadoArea bObjEmpArea = null;
        BEmpleado objEmpleado = null;
        BArea objArea = null;
        static byte[] vFoto = null;
        static int vIdEmpleado = 0;
        IConfiguration configure;
        public EmpleadoController(IConfiguration _configuration)
        {
            configure = _configuration;

        }
        public IActionResult Index()
        {

            bObjEmpArea = new BEmpleadoArea();
            EmpleadoArea mEmpleadoArea = new EmpleadoArea();
            mEmpleadoArea = bObjEmpArea.listaEmpleadoArea();

            return View(mEmpleadoArea);
        }

        [HttpPost]
        public IActionResult Index(int idEmpleadoArea)
        {

            bObjEmpArea = new BEmpleadoArea();
            EmpleadoArea mEmpleadoArea = new EmpleadoArea();
            mEmpleadoArea = bObjEmpArea.listaEmpleadoArea(idEmpleadoArea);



            return View(mEmpleadoArea);
        }

        public IActionResult Create()
        {

            objArea = new BArea();
            objEmpleado = new BEmpleado();
            ViewBag.Area = objArea.listaAreas();
            ViewBag.Jefe = objEmpleado.listaEmpleadoCBO();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado mEmpleado)
        {
            if (ModelState.IsValid)
            {
                objEmpleado = new BEmpleado();

                if (Request.Form.Files.Count() != 0)
                {

                    foreach (var item in Request.Form.Files)
                    {

                        MemoryStream ms = new MemoryStream();
                        item.CopyTo(ms);

                        mEmpleado.foto = ms.ToArray();

                        objEmpleado.upsert(mEmpleado, "1");

                        TempData["mensaje"] = "El empleado se ha creado correctamente";
                    }
                }
                else
                {
                    objEmpleado.upsert(mEmpleado, "1");
                    TempData["mensaje"] = "El empleado se ha creado correctamente";
                }


            }

            return RedirectToAction("Index");
        }


        [Route("Empleado/DetallesExtra/{idEmpleado:int}")]
        public IActionResult DetallesExtra(int idEmpleado)
        {
            DatosExtraEmp objDatosExtra = new DatosExtraEmp();
            objEmpleado = new BEmpleado();

            objDatosExtra = objEmpleado.datosExtraEmp(idEmpleado);

            return View(objDatosExtra);
        }

        [HttpGet]
        [Route("Empleado/Edit/{idEmpleado:int}")]
        public IActionResult Edit(int idEmpleado)
        {
            if (idEmpleado == 0)
            {
                return NotFound();
            }

            objEmpleado = new BEmpleado();

            var mEmpleado = objEmpleado.listaEmpleadoXId(idEmpleado);
            vFoto = mEmpleado.foto;
            if (mEmpleado == null)
            {
                return NotFound();
            }

            return View(mEmpleado);
        }

        [HttpPost]
        public IActionResult Edit(Empleado mEmpleado)
        {




            objEmpleado = new BEmpleado();


            if (Request.Form.Files.Count() != 0)
            {
                foreach (var item in Request.Form.Files)
                {

                    MemoryStream ms = new MemoryStream();
                    item.CopyTo(ms);

                    mEmpleado.foto = ms.ToArray();

                    objEmpleado.upsert(mEmpleado, "2");
                }
            }
            else
            {
                if (mEmpleado.foto == null)
                    mEmpleado.foto = vFoto;
                objEmpleado.upsert(mEmpleado, "2");
            }

            TempData["mensaje"] = "El empleado se ha modificado correctamente";


            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmpleado(int idEmpleado)
        {
            objEmpleado = new BEmpleado();


            objEmpleado.eliminar(idEmpleado, "3");

            TempData["mensaje"] = "El empleado se ha eliminado correctamente";


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Empleado/Delete/{idEmpleado:int}")]
        public IActionResult Delete(int idEmpleado)
        {
            DatosExtraEmp objDatosExtra = new DatosExtraEmp();
            objEmpleado = new BEmpleado();

            objDatosExtra = objEmpleado.datosExtraEmp(idEmpleado);

            return View(objDatosExtra);

            
        }

        [HttpGet]
        [Route("Empleado/Skills/{idEmpleado:int}")]
        public IActionResult Skills(int idEmpleado)
        {
            Service objService = new Service(configure);

            IEnumerable<EmpleadoHabilidad> iEmpleadoHab;

            iEmpleadoHab = objService.getListaHabilidad(idEmpleado);

            return View(iEmpleadoHab);


        }

        [HttpGet]
        [Route("Empleado/CreateSkill/{idEmpleado:int}")]
        public IActionResult CreateSkill(int idEmpleado)
        {

            Service objService = new Service(configure);

            IEnumerable<EmpleadoHabilidad> iEmpleadoHab;

            iEmpleadoHab = objService.getListaHabilidad(0);

            ViewBag.Habilidad = iEmpleadoHab;
            ViewBag.IdEmpleado = idEmpleado;
            vIdEmpleado = idEmpleado;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(EmpleadoHabilidad empleadoHabilidad)
        {


            objEmpleado = new BEmpleado();
            empleadoHabilidad.idEmpleado = vIdEmpleado;
            objEmpleado.asociarHabilidad(empleadoHabilidad);

            return RedirectToAction("Index");
        }


    }
}
