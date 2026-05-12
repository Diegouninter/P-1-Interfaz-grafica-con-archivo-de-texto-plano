using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_1_Interfaz_grafica_con_archivo_de_texto_plano.Clases
{
    internal class Entidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }

        public Entidad()
        {

        }

        public Entidad(int id, string nombre, string carrera)
        {
            Id = id;
            Nombre = nombre;
            Carrera = carrera;
        }

    }
}
