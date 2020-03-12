﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FlowerViewer
{
    class FlowerCore
    {
        public static void Process(MainWindow mw, List<Flower> flowers)
        {
            Flower selFlower = flowers[0];

            /*----------------NAVEGATION----------------*/
            mw.navBtnBack.Click += (o, i) =>
            {
                int index = flowers.IndexOf(selFlower);
                if (index == 0)
                    selFlower = flowers[flowers.Count - 1];
                else
                    selFlower = flowers[index - 1];
            };

            mw.navBtnNext.Click += (o, i) =>
            {
                int index = flowers.IndexOf(selFlower);
                if (index + 1 == flowers.Count)
                    selFlower = flowers[0];
                else
                    selFlower = flowers[index + 1];
            };

            /*----------------COLOR SELECTION----------------*/

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

            /*----------------DESCRIPCIÓN----------------*/
            // MOSTRAR
            mw.btnViewDesc.Click += (o, i) =>
            {
                throw new NotImplementedException();
            };

            /*----------------IMÁGEN----------------*/
            // CARGAR
            mw.btnCharge.Click += (o, i) =>
            {

            };

            // BORRAR
            mw.btnDelete.Click += (o, i) =>
            {

            };

            /*----------------MAIN ACTIONS------------*/
            // BOTÓN NUEVO
            mw.btnNew.Click += (o, i) =>
            {

            };

            // BOTÓN GUARDAR
            mw.btnSave.Click += (o, i) =>
            {

            };

            // BOTÓN BORRAR
            mw.btnRemove.Click += (o, i) =>
            {

            };
        }

        public static List<Flower> MaterializeDir(string directory)
        {
            // EXTRAER JSONS
            // CONVERTIR JSONS A FLORES
            // DEVOLVER LISTA DE FLORES
            throw new NotImplementedException();
        }
    }
}
