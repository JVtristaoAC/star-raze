using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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


namespace Kinectinho.View
{
    /// <summary>
    /// Lógica interna para TelaFerramentas.xaml
    /// </summary>
    public partial class TelaFerramentas : Window
    {
        KinectSensor kinect;
        
        
        /**
         * Rastreamento do Esqueleto
         */
       

       
        public TelaFerramentas()
        {
            InitializeComponent();
            InicializarSensor();
           



        }
        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static KinectSensor InicializarPrimeiroSensor(int anguloElevacaoInicial)
        {

            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);

            kinect.Start();
            kinect.ElevationAngle = anguloElevacaoInicial;

            return kinect;



        }
        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;


        }

        private void InicializarSensor()
        {
            // Inicializando o kinect no angulo 0.
            kinect = InicializarPrimeiroSensor(0);

            // Vinculando aos eventos para exeibir o esqueleto do usuário na tela de "espelho" canvas
            kinect.DepthStream.Enable();
            kinect.DepthFrameReady += kinect_DepthFrameReady;
            kinect.SkeletonStream.Enable();


        }

        private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {
                if (quadroAtual != null)
                {


                }
            }
        }


        /**
       * Desenhar o esqueleto do usuário.
       */

        private void kinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            esqueletobugado.Background = new ImageBrush(ReconhecerHumanos(e.OpenDepthImageFrame()));
        }

        private void kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            esqueletobugado.Background = new ImageBrush(ObterImagemSensorRGB(e.OpenColorImageFrame()));
        }

        private BitmapSource ObterImagemSensorRGB(ColorImageFrame quadro)
        {
            if (quadro == null) return null;

            using (quadro)
            {
                byte[] bytesImagem = new byte[quadro.PixelDataLength];
                quadro.CopyPixelDataTo(bytesImagem);

               
                    for (int indice = 0; indice < bytesImagem.Length; indice += quadro.BytesPerPixel)
                    {
                        byte maiorValorCor = Math.Max(bytesImagem[indice], Math.Max(bytesImagem[indice + 1], bytesImagem[indice + 2]));

                        bytesImagem[indice] = maiorValorCor;
                        bytesImagem[indice + 1] = maiorValorCor;
                        bytesImagem[indice + 2] = maiorValorCor;
                    }

                return BitmapSource.Create(quadro.Width, quadro.Height, 960, 960, PixelFormats.Bgr555, null, bytesImagem, quadro.Width * quadro.BytesPerPixel);
            }
        }


        private BitmapSource ReconhecerHumanos(DepthImageFrame quadro)
        {
            if (quadro == null) return null;

            using (quadro)
            {
                DepthImagePixel[] imagemProfundidade = new DepthImagePixel[quadro.PixelDataLength];
                quadro.CopyDepthImagePixelDataTo(imagemProfundidade);

                byte[] bytesImagem = new byte[imagemProfundidade.Length * 4];

                for (int indice = 0; indice < bytesImagem.Length; indice += 4)
                {
                    if (imagemProfundidade[indice / 4].PlayerIndex != 0)
                    {
                        bytesImagem[indice + 1] = 255;
                    }
                }
                return BitmapSource.Create(quadro.Width, quadro.Height, 960, 960, PixelFormats.Bgr32, null , bytesImagem, quadro.Width * 4);
            }
        }


        private void Angulo_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            kinect.ElevationAngle = Convert.ToInt32(Angulo.Value);
        }

        private void Volume_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
           
        }



        private void Voltar_Click(object sender, RoutedEventArgs e)
        {           
            MainWindow janela = new MainWindow();
            janela.Show();
            this.Close();
            kinect.Dispose();
        }


}
}