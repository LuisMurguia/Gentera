using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class RecetaAlumnoController : Controller
    {
        // GET: RecetaAlumno
        public ActionResult GetById(int Matricula)
        {
            Session["IdAlumno"] = Matricula;
            ML.Result result = BL.RecetaAlumno.GetByIdEF(Matricula);
            ML.RecetasAlumnos recetasAlumnos = new ML.RecetasAlumnos();//instancia del modelo
            recetasAlumnos.Alumno = new ML.Alumnos();
            recetasAlumnos.Alumno.Matricula = Matricula;

            //ML.Result  GetById   Alumno
            if (result.Correct)
            {
                recetasAlumnos.RecetaAlumno = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al traer la informacion" + result.ErrorMessage;
            }

            return View("GetById", recetasAlumnos);
        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdReceta)
        {
            ServiceReference1.Service1Client ServicioAlumno = new ServiceReference1.Service1Client();
            ML.RecetasAlumnos recetasAlumnos = new ML.RecetasAlumnos();
            recetasAlumnos.Receta = new ML.Receta();
            //recetasAlumnos.Alumno = new ML.Alumnos();


            if (IdReceta == null)
            {
                return View(recetasAlumnos.Receta);
            }
            else
            {

                //var result = ServicioAlumno.GetByIdReceta(IdReceta.Value);
                ML.Result result = BL.Receta.GetByIdEF(IdReceta.Value);
                if (result.Correct)
                {
                    recetasAlumnos.Receta.IdReceta = ((ML.Receta)result.Object).IdReceta;
                    recetasAlumnos.Receta.Diagnostico = ((ML.Receta)result.Object).Diagnostico;
                    recetasAlumnos.Receta.Tratamiento = ((ML.Receta)result.Object).Tratamiento;
                    recetasAlumnos.Receta.Fecha = ((ML.Receta)result.Object).Fecha;

                    return View(recetasAlumnos.Receta);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }

        }// Aqui termina 


        [HttpPost]
        public ActionResult Form(ML.Receta receta)
        {
            ML.Result result = new ML.Result();

            ML.RecetasAlumnos alumnomateriaItem = new ML.RecetasAlumnos ();

            if (receta.IdReceta == 0)
            {
                result = BL.RecetaAlumno.Add(new ML.RecetasAlumnos() 
                {
                 Receta=receta,
                 Alumno=new ML.Alumnos() {  Matricula=(int)Session["IdAlumno"] }
                });
                if (result.Correct)
                {
                    ViewBag.Message = "Alumno agregado correctamente";
                }
            }
            else
            {
                result = BL.Receta.UpdateEF(receta);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizaron los datos del alumno correctamente";
                }
            }

            return PartialView("Modal");
        }

    }
}
