using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAllEF()
        {


            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
               
                {
                    var query = context.AllumnosGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Alumnos alumno = new ML.Alumnos();

                            alumno.Matricula = obj.Matricula;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.FechaNacimiento = obj.FechaNacimiento;

                         


                            result.Objects.Add(alumno);

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

        public static ML.Result GetByIdEF(int Matricula)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {


                    var Query = context.AlumnoGetById(Matricula).ToList();
                    result.Objects = new List<object>();

                    if (Query != null)
                    {
                        foreach (var obj in Query)
                        {
                            ML.RecetasAlumnos recetasalumnos = new ML.RecetasAlumnos();
                            recetasalumnos.Alumno = new ML.Alumnos();
                            recetasalumnos.Alumno.Matricula = obj.Matricula;
                            recetasalumnos.Alumno.Nombre = obj.Nombre;
                            recetasalumnos.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            recetasalumnos.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                           
                            result.Object=recetasalumnos;
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
    }
}
