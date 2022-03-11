using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
      
        public SL_WCF.Result GetAll()
        {
            ML.Result resultAlumno = BL.Alumno.GetAllEF();
            return new Result { Correct = resultAlumno.Correct, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex, Objects = resultAlumno.Objects };
        }

        public SL_WCF.Result GetByIdEF(int Id)
        {
            ML.Result resultRecetaAlumno = BL.RecetaAlumno.GetByIdEF(Id);
            return new Result { Correct = resultRecetaAlumno.Correct, ErrorMessage = resultRecetaAlumno.ErrorMessage, Ex = resultRecetaAlumno.Ex, Object = resultRecetaAlumno.Object };

        }

        public SL_WCF.Result GetByMatricula(int matricula)
        {
            ML.Result resultRecetaAlumno = BL.Alumno.GetByIdEF(matricula);
            return new Result { Correct = resultRecetaAlumno.Correct, ErrorMessage = resultRecetaAlumno.ErrorMessage, Ex = resultRecetaAlumno.Ex, Object = resultRecetaAlumno.Object };

        }

        public SL_WCF.Result Add(ML.RecetasAlumnos alumno)
        {
            ML.Result resultRecetaAlumno = BL.RecetaAlumno.Add(alumno);
            return new Result { Correct = resultRecetaAlumno.Correct, ErrorMessage = resultRecetaAlumno.ErrorMessage, Ex = resultRecetaAlumno.Ex };
        }


        public SL_WCF.Result Update(ML.Receta receta)
        {
            ML.Result resultReceta = BL.Receta.UpdateEF(receta);
            return new Result { Correct = resultReceta.Correct, ErrorMessage = resultReceta.ErrorMessage, Ex = resultReceta.Ex };
        }

        public SL_WCF.Result GetByIdReceta(int Id)
        {
            ML.Result resultRecetaAlumno = BL.RecetaAlumno.GetByIdEF(Id);
            return new Result { Correct = resultRecetaAlumno.Correct, ErrorMessage = resultRecetaAlumno.ErrorMessage, Ex = resultRecetaAlumno.Ex, Object = resultRecetaAlumno.Object };
        }

    }
}
