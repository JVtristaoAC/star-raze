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
            this.Hide();
        }

        private void Carrossel_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dança mao");
        }

        private void Carrossel_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dança mao");
        }

        private void Carrossel_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dança mao");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
