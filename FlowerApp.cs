using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace FlowerViewer
{
    class FlowerApp
    {
        public static void Launch(MainWindow mw, Model m)
        {

            /*----------------NAVEGATION----------------*/
            mw.navBtnBack.Click += (o, i) =>
            {
                m.RefreshUnclickables();
                m.NextFlower();
                m.RefreshUI();
            };

            mw.navBtnNext.Click += (o, i) =>
            {
                m.RefreshUnclickables();
                m.BackFlower();
                m.RefreshUI();
            };

            /*----------------COLOR SELECTION----------------*/

            mw.cmbxColor.SelectionChanged += (o, i) =>
            {
                m.SetColor(); 
            };

            /*----------------DESCRIPCIÓN----------------*/
            // MOSTRAR
            mw.btnViewDesc.Click += (o, i) =>
            {
                m.ViewDesc();
            };

            /*----------------IMÁGEN----------------*/
            // CARGAR
            mw.btnCharge.Click += (o, i) =>
            { 
                m.ProcessImgDialog();
            };

            // BORRAR
            mw.btnDelete.Click += (o, i) =>
            {
                m.DropImg();
            };

            /*----------------MAIN ACTIONS------------*/
            // BOTÓN NUEVO
            mw.btnNew.Click += (o, i) =>
            {
                m.NewFlower();
                m.RefreshUI();
            };

            // BOTÓN GUARDAR
            mw.btnSave.Click += (o, i) =>
            {
                m.RefreshUnclickables();
                m.SaveFlowers();
            };

            // BOTÓN BORRAR
            mw.btnRemove.Click += (o, i) =>
            {
                m.BackFlower();
                m.DropFlower();
                m.RefreshUI();
            };
        }
    }
}
