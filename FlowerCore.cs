using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;

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
                // Crea un diálogo para abrir un archivo.
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                // Determinamos el filtro para el tipo de archivos
                dlg.DefaultExt = ".png";
                dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                // Comprobamos si el resultado es positivo
                bool? result = dlg.ShowDialog();

                // Si el resultado es positivo convertimos la imágen
                if (result == true)
                {
                    // Ruta del documento
                    string filename = dlg.FileName;

                    // Guardar objeto Flower
                    byte[] imageArray = File.ReadAllBytes(filename);
                    selFlower.image = Convert.ToBase64String(imageArray);

                    // Visualizar imágen
                    byte[] imageView = Convert.FromBase64String(selFlower.image);
                    mw.imgFlower.Source =  LoadImage(imageView);
                }
            };

            // BORRAR
            mw.btnDelete.Click += (o, i) =>
            {
                selFlower.image = null;
                mw.imgFlower.Source = null;
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

        // Convertor de byte a Bitmap
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
