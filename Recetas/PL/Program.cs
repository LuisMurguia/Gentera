using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            ML.Result result = BL.Alumno.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Alumnos alumno in result.Objects)
                {
                    Console.WriteLine("IdUsuario: " + alumno.Matricula);
                    Console.WriteLine("Nombre: " + alumno.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + alumno.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + alumno.ApellidoMaterno);
                }
                Console.WriteLine("Se visualizo correctamente");
            }
            else
            {
                Console.WriteLine("No se visualizo correctamente");
            }
            Console.ReadKey();
        }
    }
}
