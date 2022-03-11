using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;


namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ServiceReference1.Service1Client clientDepto = new ServiceReference1.Service1Client();
            var result = clientDepto.GetAll();
            //ML.Result result = BL.Departamento.GetAllEF();

            ML.Alumnos alumno = new ML.Alumnos();
            if (result.Correct)
            {
                alumno.Alumno = result.Objects.ToList();
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("GetAll");
            }
        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? Matricula)
        {
            ServiceReference1.Service1Client ServicioAlumno = new ServiceReference1.Service1Client();
            ML.Alumnos alumno = new ML.Alumnos();

            if (Matricula == null)
            {
                return View(alumno);
            }
            else
            {

                //var result = ServicioAlumno.GetByIdEF(Matricula.Value);
                ML.Result result = BL.Alumno.GetByIdEF(Matricula.Value);

                if (result.Correct)
                {
                    alumno.Matricula = ((ML.Alumnos)result.Object).Matricula;
                    alumno.Nombre = ((ML.Alumnos)result.Object).Nombre;
                    alumno.ApellidoPaterno = ((ML.Alumnos)result.Object).ApellidoPaterno;
                    alumno.ApellidoMaterno = ((ML.Alumnos)result.Object).ApellidoMaterno;

                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }// Aqui termina 
        }
    }
}