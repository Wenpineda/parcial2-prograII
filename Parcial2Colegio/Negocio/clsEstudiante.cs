using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2Colegio.Negocio
{
    public class clsEstudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string carrera { get; set; }
        public string asignatura { get; set; }
        public decimal promedio1 { get; set; }
        public decimal promedio2 { get; set; }
        public decimal promedio3 { get; set; }
        public decimal promediofinal { get; set; }
    }
}
