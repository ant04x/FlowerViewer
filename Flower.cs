using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerViewer
{
    class Flower
    {
        public string name;

        public enum Colors
        {
            Blanco = 0,
            Rojo = 1,
            Amarillo = 2,
            Morado = 3,
            Azul = 4
        }

        public Colors color = new Colors();

        public string description;

        public string image;
    }
}
