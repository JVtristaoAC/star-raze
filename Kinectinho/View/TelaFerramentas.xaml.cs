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
using System.Windows.Shapes;

namespace Kinectinho.View
{
    /// <summary>
    /// Lógica interna para TelaFerramentas.xaml
    /// </summary>
    public partial class TelaFerramentas : Window
    {
        public TelaFerramentas()
        {
            InitializeComponent();
        }





        private void Volume_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            String Sound = Convert.ToString(Volume.Value);

            SomText.Content = Sound;
        }
    }
}
