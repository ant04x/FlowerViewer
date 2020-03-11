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
            Blanco,
            Rojo,
            Amarillo,
            Morado,
            Azul
        }

        public Colors color = new Colors();

        public string description;

        public byte[] image;
    }
}
