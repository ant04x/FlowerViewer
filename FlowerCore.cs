using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FlowerViewer
{
    class FlowerCore
    {
        public static void Process(MainWindow mw)
        {
            Flower selFlower = null;

            /*----------------NAVEGATION----------------*/
            mw.navBtnBack.Click += (o, i) =>
            {
                
            };

            mw.navBtnNext.Click += (o, i) =>
            {

            };

            /*----------------NAVEGATION----------------*/

            mw.cmbxColor.SelectionChanged += (o, i) =>
            {
                // Blanco
                if (mw.cmbxColor.SelectedIndex == 0)
                    selFlower.color = Flower.Colors.Blanco;

                // Rojo
                if (mw.cmbxColor.SelectedIndex == 1)
                    selFlower.color = Flower.Colors.Rojo;

                // Amarillo
                if (mw.cmbxColor.SelectedIndex == 2)
                    selFlower.color = Flower.Colors.Amarillo;

                // Morado
                if (mw.cmbxColor.SelectedIndex == 3)
                    selFlower.color = Flower.Colors.Morado;

                // Azul
                if (mw.cmbxColor.SelectedIndex == 4)
                    selFlower.color = Flower.Colors.Azul;
            };
        }
    }
}
