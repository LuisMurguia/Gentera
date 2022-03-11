using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Receta
    {

        public static ML.Result GetByIdEF(int IdReceta)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {


                    var Query = context.RecetaGetById(IdReceta).ToList();
                    result.Objects = new List<object>();

                    if (Query != null)
                    {
                        foreach (var obj in Query)
                        {
                            ML.Receta receta = new ML.Receta();
  
                            receta.IdReceta = obj.IdReceta;
                            receta.Fecha = obj.Fecha.ToString("dd/MM/yyyy");
                            receta.Diagnostico = obj.Diagnostico;
                            receta.Tratamiento = obj.Tratamiento;

                            result.Object=receta;
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

        public static ML.Result UpdateEF(ML.Receta receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RecetasEntities context = new DL.RecetasEntities())
                {
                    var Query = context.UpdateReceta( receta.Diagnostico, receta.Tratamiento, receta.IdReceta);

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

        //public static ML.Result Add(ML.Receta receta)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL.RecetasEntities context = new DL.RecetasEntities())
        //        {
        //            var query = context.RecetaAdd(receta.Alumno.Matricula, receta.Fecha,
        //                receta.Diagnostico, receta.Tratamiento);

        //            result.Object = receta;

        //            if (query >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontraron registros";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}


    }
}
