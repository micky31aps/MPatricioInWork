using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AgendaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Agenda agenda = new ML.Agenda();
            ML.Result result = BL.Agenda.GetAll();

            if (result.Correct)
            {
                agenda.Agendas = result.Objects;
            }
            else
            {

            }
            return View(agenda);
        }
        public ActionResult Form(int? IdTelefono)
        {
            ML.Agenda agenda = new ML.Agenda();
            if (IdTelefono == null)
            {
                return View(agenda);
            }
            else
            {
                ML.Result result = BL.Agenda.GetById(IdTelefono.Value);
                if (result.Correct)
                {
                    agenda = ((ML.Agenda)result.Object);
                    agenda.Agendas = result.Objects;
                    return View(agenda);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontro el registro" + result.ErrorMessage;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Agenda agenda)
        {
            ML.Result result = new ML.Result();
            if (agenda.IdTelefono == 0)
            {
                result = BL.Agenda.Add(agenda);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El telefono se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El telefono no se registro correctamente";
                }
            }
            else
            {
                result = BL.Agenda.Update(agenda);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El telefono se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El telefono no se actualizo correctamente";
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdTelefono)
        {
            ML.Agenda agenda = new ML.Agenda();
            agenda.IdTelefono = IdTelefono;
            ML.Result result = BL.Agenda.Delete(IdTelefono);
            if (result.Correct)
            {
                ViewBag.Mensaje = "El telefono se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El telefono no se ha eliminado correctamente";
            }
            return PartialView("Modal");
        }
	}
}