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
        byte[] info_cores_sensor_kinect = null;
        WriteableBitmap bmp_rgb_cores = null;


        public TelaFerramentas()
        {
            InitializeComponent();
            InicializarSensor();


        }

        public static KinectSensor InicializarPrimeiroSensor(int anguloElevacaoInicial)
        {

            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);

            kinect.Start();
            kinect.ElevationAngle = anguloElevacaoInicial;

            return kinect;



        }

        private void InicializarSensor()
        {
            // Inicializando o kinect no angulo 0.
            kinect = InicializarPrimeiroSensor(0);

            // Vinculando aos eventos para exeibir o esqueleto do usuário na tela de "espelho" canvas
            kinect.DepthStream.Enable();
            kinect.SkeletonStream.Enable();
            kinect.ColorStream.Enable();
            kinect.AllFramesReady += AllFramesReady;
          
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
        void AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            byte[] imagem = ObterImagemSensorRGB(e.OpenColorImageFrame());

            using (ColorImageFrame visualizacao = e.OpenColorImageFrame())
            {
                ReconhecerDistancia(e.OpenDepthImageFrame(), imagem, 2000);
                if (visualizacao == null) return;

                if (info_cores_sensor_kinect == null)
                    info_cores_sensor_kinect = new byte[visualizacao.PixelDataLength];

                visualizacao.CopyPixelDataTo(info_cores_sensor_kinect);

                if (bmp_rgb_cores == null)
                {
                    this.bmp_rgb_cores = new WriteableBitmap(
                        visualizacao.Width,
                        visualizacao.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null);
                }

                this.bmp_rgb_cores.WritePixels(new Int32Rect(0, 0, visualizacao.Width, visualizacao.Height), info_cores_sensor_kinect, visualizacao.Width * visualizacao.BytesPerPixel, 0);
                if (imagem != null)
                    esqueletobugado.Background =
                    new ImageBrush(
                        BitmapSource.Create(kinect.ColorStream.FrameWidth, kinect.ColorStream.FrameHeight,
                        96, 96, PixelFormats.Bgr32, null, imagem,
                        kinect.ColorStream.FrameWidth * kinect.ColorStream.FrameBytesPerPixel
                                        ));

                
            }
        }

        private byte[] ObterImagemSensorRGB(ColorImageFrame quadro)
        {
            if (quadro == null) return null;

            using (quadro)
            {
                byte[] bytesImagem = new byte[quadro.PixelDataLength];
                quadro.CopyPixelDataTo(bytesImagem);

                return bytesImagem;
            }
        }

        private void ReconhecerDistancia(DepthImageFrame quadro, byte[] bytesImagem, int distanciaMaxima)
        {
            if (quadro == null || bytesImagem == null) return;

            using (quadro)
            {
                DepthImagePixel[] imagemProfundidade = new DepthImagePixel[quadro.PixelDataLength];
                quadro.CopyDepthImagePixelDataTo(imagemProfundidade);

                DepthImagePoint[] pontosImagemProfundidade = new DepthImagePoint[640 * 480];
                kinect.CoordinateMapper.MapColorFrameToDepthFrame(kinect.ColorStream.Format, kinect.DepthStream.Format, imagemProfundidade, pontosImagemProfundidade);

                for (int i = 0; i < pontosImagemProfundidade.Length; i++)
                {
                    var point = pontosImagemProfundidade[i];
                    if (point.Depth < distanciaMaxima && KinectSensor.IsKnownPoint(point))
                    {
                        var pixelDataIndex = i * 4;

                        byte maiorValorCor = Math.Max(bytesImagem[pixelDataIndex], Math.Max(bytesImagem[pixelDataIndex], bytesImagem[pixelDataIndex + 2]));

                        bytesImagem[pixelDataIndex] = maiorValorCor;
                        bytesImagem[pixelDataIndex] = maiorValorCor;
                        bytesImagem[pixelDataIndex + 2] = maiorValorCor;
                    }
                }
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
        }


}
}