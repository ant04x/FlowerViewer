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
    class Utils
    {
        // Método estático conversor de byte a Bitmap
        public static BitmapImage LoadImage(byte[] imageData)
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

        public static string SaveObject(OpenFileDialog ofd)
        {

            // Ruta del documento
            string filename = ofd.FileName;

            // Guardar objeto Flower
            byte[] imageArray = File.ReadAllBytes(filename);
            return Convert.ToBase64String(imageArray);
        }

        public static BitmapImage ViewJsonImg(string imageB64)
        {
            // Visualizar imágen
            byte[] imageView = Convert.FromBase64String(imageB64);
            return LoadImage(imageView);
        }

        public static List<Flower> FromJson(string flowersPath)
        {
            string flowerJson = File.ReadAllText(flowersPath);
            return JsonConvert.DeserializeObject<List<Flower>>(flowerJson);
        }
    }
}
