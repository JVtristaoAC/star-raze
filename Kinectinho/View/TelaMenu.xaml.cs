using Kinectinho.ViewModel;
using Microsoft.Kinect;
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
using System.Windows.Shapes;
using System.Windows.Threading;




namespace Kinectinho.View
{
    /// <summary>
    /// Lógica interna para TelaMenu.xaml
    /// </summary>
    public partial class TelaMenu : Window
    {

        public TelaMenu()
        {
            InitializeComponent();
            DataContext = new ViewModel.MenuModel();

            _carouselDABDancas.SelectionChanged += _carouselDABDancas_SelectionChanged;

           


        }

        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;


        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _carouselDABDancas_SelectionChanged(FrameworkElement selectedElement)
        {
            var viewModel = DataContext as ViewModel.MenuModel;

            if (viewModel == null)
            {
                return;
            }

            viewModel.SelectedDancaDAB = selectedElement.DataContext as Model.Danca;
                
        }

        private void Proximo_Click(object sender, RoutedEventArgs e)
        {         
            _carouselDABDancas.RotateRight();
            

        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABDancas.RotateLeft();
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow janela = new MainWindow();
            janela.Show();
            this.Close();
        }
   

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
                var viewModel = DataContext as ViewModel.MenuModel;
                switch (viewModel.SelectedDancaDAB.Carroussel)
                {
                    case 1:
                        Dancas.Danca1 janela1 = new Dancas.Danca1();
                        janela1.Show();
                        this.Close();

                        break;
                    case 2:
                        Dancas.Danca2 janela2 = new Dancas.Danca2();
                        janela2.Show();
                        this.Close();
                        break;

                    case 3:
                        Dancas.Danca3 janela3 = new Dancas.Danca3();
                        janela3.Show();
                        this.Close();
                        break;

                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel carregar a Danca", "Kinect Não Conectado");
            }
            

           
           

        }
    }
}
