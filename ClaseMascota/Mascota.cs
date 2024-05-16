using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMascota
{
    public class Mascota
    {
        public int Id { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public int Sexo { get; set; }
        public int PrecioVenta { get; set; }
        public string NombreComprador { get; set; }
        public string RutComprador { get; set; }
    }
}
