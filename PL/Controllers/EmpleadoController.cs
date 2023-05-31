using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            ML.Result result = BL.EmpleadoModel.GetALL();

            ML.Empleado empleado = new ML.Empleado();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {

            }
            return View(empleado);
        }

        public ActionResult Form(int? IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            if (IdEmpleado == 0)
            {
                return View();
            }
            else
            {
                //ML.Result result = BL.Empleado();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            if(empleado.IdEmpleado == 0)
            {
                ML.Result result = BL.EmpleadoModel.Add(empleado);
                return RedirectToAction("GetAll","Empleado");
            }
            else
            {
                //ML.Result result = BL.Empleado.Update();
                return PartialView("GetAll");
            }
        }

    }
}