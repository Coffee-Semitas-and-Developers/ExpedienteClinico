using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedEvolution.Controllers.Validaciones
{
    public class ValidacionesController : Controller
    {
        public ValidacionesController()
        {

        }

        //Validacion con JQueryVal del lado del cliente
        public JsonResult FechaParaCita(DateTime FechaCita)
        {
            var IsValid = FechaCita < DateTime.Today;

            return Json(IsValid, JsonRequestBehavior.AllowGet);
        }

        //Validacion para el numero de citas atender del lado del cliente
        public JsonResult NumeroDeCitas(int NumeroCitasAtender)
        {
            var IsValid = NumeroCitasAtender >= 0 ;

            return Json(IsValid, JsonRequestBehavior.AllowGet);
        }
    }
}