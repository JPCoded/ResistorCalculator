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

namespace ResistorCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Color 
        {
         Black,
         Red,
         Orange,
         Yellow,
         Green,
         Blue,
         Violet,
         Grey,
         White,
         Gold,
         Silver   
        }

        public MainWindow()
        {
            InitializeComponent();
       
        }

        private void BtnSub1_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RB1.PreviousColor();
        }


        private void BtnAdd1_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           RB1.NextColor();
        }
    }
}
