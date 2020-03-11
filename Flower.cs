using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerViewer
{
    class Flower
    {
        string name;

        enum Color
        {
            Blanco,
            Rojo,
            Amarillo,
            Morado,
            Azul
        }

        string description;

        byte[] image;
    }
}
