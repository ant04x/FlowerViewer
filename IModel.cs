using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FlowerViewer
{
    interface IModel
    {
        void BackFlower();
        void NextFlower();
        void SetColor();
        void ViewDesc();
        void ProcessImgDialog();
        void DropImg();
        void NewFlower();
        void SaveFlowers();
        void DropFlower();
        void RefreshUnclickables();
        void RefreshUI();
    }
}
