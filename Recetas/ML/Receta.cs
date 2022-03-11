using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Receta
    {
        public int IdReceta { get; set; }
        public string Fecha { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }


        public List<object> Recetas { get; set; }
    }
}
