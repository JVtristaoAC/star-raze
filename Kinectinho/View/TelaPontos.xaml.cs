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
    /// Lógica interna para TelaPontos.xaml
    /// </summary>
    public partial class TelaPontos : Window
    {
        public TelaPontos()
        {
            InitializeComponent();
        }

        private void btnRepetir_Click(object sender, RoutedEventArgs e)
        {
            Dancas.Danca1 janela = new Dancas.Danca1();
            janela.Show();
            this.Hide();
        }

        private void btnEscolha_Click(object sender, RoutedEventArgs e)
        {
            TelaMenu janela = new TelaMenu();
            janela.Show();
            this.Hide();
        }
    }
}
