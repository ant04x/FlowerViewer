using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FlowerViewer
{
    class Model : IModel
    {
        MainWindow mw;
        static string flowersPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Resources\\flowers.json";
        List<Flower> flowers;
        Flower selFlower;

        public Model(MainWindow mainWindow)
        {
            mw = mainWindow;
            if (File.Exists(flowersPath))
            {
                flowers = Utils.FromJson(flowersPath);
            }
            else
            {
                flowers = new List<Flower>();
                flowers.Add(new Flower());
            }
            selFlower = flowers[0];
            RefreshUI();
        }

        public void BackFlower()
        {
            int index = flowers.IndexOf(selFlower);
            if (index == 0)
                selFlower = flowers[flowers.Count - 1];
            else if (index == -1)
                selFlower = flowers[0];
            else
                selFlower = flowers[index - 1];
        }

        public void NextFlower()
        {
            int index = flowers.IndexOf(selFlower);
            if (index + 1 == flowers.Count)
                selFlower = flowers[0];
            else
                selFlower = flowers[index + 1];
        }

        // TODO Probar
        public void SetColor()
        {
            int optionsCount = Enum.GetNames(typeof(Flower.Colors)).Length;
            for (int i = 0; i < optionsCount; i++)
                if (mw.cmbxColor.SelectedIndex == i)
                    selFlower.color = (Flower.Colors)i;
        }

        // TODO Implements
        public void ViewDesc()
        {
            throw new NotImplementedException();
        }

        public void ProcessImgDialog()
        {
            // Crea un diálogo para abrir un archivo.
            OpenFileDialog ofd = new OpenFileDialog();

            // Determinamos el filtro para el tipo de archivos
            ofd.DefaultExt = ".png";
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Comprobamos si el resultado es positivo
            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                selFlower.image = Utils.SaveObject(ofd);
                mw.imgFlower.Source = Utils.ViewJsonImg(selFlower.image);
            }
        }

        public void DropImg()
        {
            selFlower.image = null;
            mw.imgFlower.Source = null;
        }

        public void NewFlower()
        {
            flowers.Add(new Flower());
            selFlower = flowers[flowers.Count - 1];
        }

        public void SaveFlowers()
        {
            File.WriteAllText(flowersPath, JsonConvert.SerializeObject(flowers));
        }

        public void DropFlower()
        {
            int indexOriginal = flowers.IndexOf(selFlower);
            Flower auxFlower = flowers[indexOriginal];
            BackFlower();
            // Crear una nueva flor si no hay nada
            if(flowers.Count == 1)
                flowers.Add(new Flower());
            int index = flowers.IndexOf(auxFlower);
            flowers.RemoveAt(index);

            // Si se elimina el primero no dar la vuelta.
            if (indexOriginal == 0)
                selFlower = flowers[0];
        }

        public void RefreshUnclickables()
        {
            if (mw.tbName.Text != "Introduce el nombre de la flor...")
                selFlower.name = mw.tbName.Text;
            if (mw.tbDescription.Text.Length > 0)
                selFlower.description = mw.tbDescription.Text;
        }

        public void RefreshUI()
        {
            mw.tbName.Text = selFlower.name;
            mw.cmbxColor.SelectedIndex = (int)selFlower.color;
            mw.tbDescription.Text = selFlower.description;
            if (selFlower.image != null)
            {
                byte[] imageView = Convert.FromBase64String(selFlower.image);
                mw.imgFlower.Source = Utils.LoadImage(imageView);
            }
            else
                mw.imgFlower.Source = null;
        }
    }
}
