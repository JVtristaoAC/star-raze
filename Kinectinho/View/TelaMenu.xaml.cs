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
        int i = 1;

        public TelaMenu()
        {
            InitializeComponent();
        }

        private void Proximo_Click(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 3)
            {
                i = 1;
            }

            Danca.Source = new BitmapImage(new Uri(@"imagens/" + i + ".jpg", UriKind.Relative));
             

        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 3;
            }

            Danca.Source = new BitmapImage(new Uri(@"imagens/" + i + ".jpg", UriKind.Relative));

        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow janela = new MainWindow();
            janela.Show();
            this.Hide();
        }

        private void Jogar_Click(object sender, RoutedEventArgs e)
        {
            switch (i)
            {
                case 1:
                    Dancas.Danca1 janela1 = new Dancas.Danca1();
                    janela1.Show();
                    break;

                case 2:
                    Dancas.Danca2 janela2 = new Dancas.Danca2();
                    janela2.Show();
                    break;

                case 3:
                    Dancas.Danca3 janela3 = new Dancas.Danca3();
                    janela3.Show();
                    break;               
            }
            this.Hide();
        }
    }
}
