﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // FlowerCore.Process(this, FlowerCore.fromJSON("C:\\Usuarios\\Antonio\\flowers.json"));
            List<Flower> listaEjemplo = new List<Flower>();
            listaEjemplo.Add(new Flower());
            listaEjemplo.Add(new Flower());
            listaEjemplo[1].color = Flower.Colors.Azul;
            FlowerCore.Process(this, listaEjemplo);
        }
    }
}
