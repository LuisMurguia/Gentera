using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
   public class RecetasAlumnos
    {
        public int IdRecetaAlumno { get; set; }

        public ML.Alumnos Alumno { get; set; }
        public ML.Receta Receta { get; set; }
        public List<object> RecetaAlumno { get; set; }
    }
}
