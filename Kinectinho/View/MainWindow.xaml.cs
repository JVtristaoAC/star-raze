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
using Microsoft.Kinect;


namespace Kinectinho
{

   public partial class MainWindow : Window
   {

       

        public MainWindow() 
       {
          InitializeComponent();
          
        }

       
        


        private void Jogar_Click(object sender, RoutedEventArgs e)
        {
            
            View.TelaMenu janela = new View.TelaMenu();
            janela.Show();
            this.Close();
            
        }

        private void Configurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
                View.TelaFerramentas janela = new View.TelaFerramentas();
                janela.Show();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Não foi possivel carregar Ferramentas", "Kinect Não Conectado");
            }
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             
            

        }
    }
}
