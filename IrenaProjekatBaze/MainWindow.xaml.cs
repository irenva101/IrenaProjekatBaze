﻿using IrenaProjekatBaze.Models;
using IrenaProjekatBaze.ViewModel;
using System;
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

namespace IrenaProjekatBaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            const string imagePath = "Images/logo3.png";
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(imagePath, UriKind.Relative)));
            InitializeComponent();
            DataContext = new MainWindowViewModel() { Window = this };
            myGrid.Background = imageBrush;
            
        }
    }
}
