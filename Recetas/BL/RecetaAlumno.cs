using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetaAlumno
    {
        public static ML.Result GetByIdEF(int Id)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {


                    var Query = context.RecetasAlumnosGetById(Id).ToList();
                    result.Objects = new List<object>();

                    if (Query != null)
                    {
                        foreach (var obj in Query)
                        {
                            ML.RecetasAlumnos recetasalumnos = new ML.RecetasAlumnos();
                            recetasalumnos.Receta = new ML.Receta();
                            recetasalumnos.Receta.IdReceta = obj.IdReceta;
                            recetasalumnos.Receta.Fecha = obj.Fecha.ToString("dd/MM/yyyy");
                            recetasalumnos.Receta.Diagnostico = obj.Diagnostico;
                            recetasalumnos.Receta.Tratamiento = obj.Tratamiento;

                            recetasalumnos.Alumno = new ML.Alumnos();
                            recetasalumnos.Alumno.Matricula = obj.Matricula;
                            recetasalumnos.Alumno.Nombre = obj.Nombre;
                            recetasalumnos.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            recetasalumnos.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            recetasalumnos.Alumno.FechaNacimiento = obj.Fecha;

                            result.Objects.Add(recetasalumnos);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result Add(ML.RecetasAlumnos recetasAlumnos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {
                    var query = context.RecetaAdd(recetasAlumnos.Alumno.Matricula, DateTime.ParseExact(recetasAlumnos.Receta.Fecha,"dd/MM/yyyy", CultureInfo.InvariantCulture), recetasAlumnos.Receta.Diagnostico, recetasAlumnos.Receta.Tratamiento);

                    result.Object = recetasAlumnos;

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.RecetasAlumnos receta)
        {
            ML.Result result = new ML.Result();
            receta.Receta = new ML.Receta();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {
                    var Query = context.UpdateReceta(receta.Receta.Diagnostico, receta.Receta.Tratamiento, receta.Receta.IdReceta);

                    if (Query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el alumno";
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
    }
}
