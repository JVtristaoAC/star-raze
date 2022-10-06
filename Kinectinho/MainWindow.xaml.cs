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


using WpfAnimatedGif;
namespace Kinectinho
{

   public partial class MainWindow : Window
   {

       

        public MainWindow() 
       {
          InitializeComponent();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(Environment.CurrentDirectory + "/resources/inicio.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Fundo, image);
        }

       
        


        private void Jogar_Click(object sender, RoutedEventArgs e)
        {
            
            View.TelaMenu janela = new View.TelaMenu();
            janela.Show();
            this.Close();
        }

        private void Configurar_Click(object sender, RoutedEventArgs e)
        {
           
            View.TelaFerramentas janela = new View.TelaFerramentas();
            janela.Show();
            this.Close();
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
