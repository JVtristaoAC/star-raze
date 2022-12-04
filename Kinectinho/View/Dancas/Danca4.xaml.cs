using Kinectinho.Model;
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

namespace Kinectinho.View.Dancas
{
    /// <summary>
    /// Lógica interna para Danca4.xaml
    /// </summary>
    public partial class Danca4 : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        KinectSensor kinect;
        int Segundos, Pontos;
        bool Testes;

        public Danca4()
        {
            InitializeComponent();
            InicializarSensor();
            Video.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void InicializarSensor()
        {
            kinect = InicializarPrimeiroSensor();
            kinect.SkeletonStream.Enable();

            // Vinculando aos eventos para exeibir o esqueleto do usuário na tela de "espelho" canvas
            kinect.ColorStream.Enable();
            kinect.DepthStream.Enable();
            kinect.DepthFrameReady += kinect_DepthFrameReady;
            kinect.SkeletonFrameReady += SkeletonFrameReady;
            kinect.SkeletonFrameReady += KinectEvent;

        }
        private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {
                if (quadroAtual != null)
                {
                    if (Video.Source != null)
                    {
                        //1 MaoEsqDirAcima(quadroAtual);
                        //2 MaosEsticadaEsqDir(quadroAtual);
                        //3 MaoEsqParaDirMaoDirParaEsq(quadroAtual);
                        //4 MaosEsqDir(quadroAtual);


                        if (Segundos >= 13 || Segundos <= 16)
                            //1
                            MaoEsqDirAcima(quadroAtual);

                        if (Segundos >= 17 || Segundos <= 25)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 28 || Segundos <= 34)
                            //3
                            MaoEsqParaDirMaoDirParaEsq(quadroAtual);

                        if (Segundos >= 35 || Segundos <= 43)
                            //1
                            MaoEsqDirAcima(quadroAtual);

                        if (Segundos >= 43 || Segundos <= 58)
                            //4
                            MaosEsqDir(quadroAtual);

                        if (Segundos >= 49 || Segundos <= 56)
                           //2
                           MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 57 || Segundos <= 65)
                            //4
                            MaosEsqDir(quadroAtual);

                        if (Segundos >= 66 || Segundos <= 62)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 63 || Segundos <= 67)
                            //1
                            MaoEsqDirAcima(quadroAtual);

                        if (Segundos >= 68 || Segundos <= 87)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 89 || Segundos <= 95)
                            //3
                            MaoEsqParaDirMaoDirParaEsq(quadroAtual);

                        if (Segundos >= 96 || Segundos <= 102)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 103 || Segundos <= 110)
                            //3
                            MaoEsqParaDirMaoDirParaEsq(quadroAtual);

                        if (Segundos >= 110 || Segundos <= 127)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);

                        if (Segundos >= 127 || Segundos <= 135)
                            //3
                            MaoEsqParaDirMaoDirParaEsq(quadroAtual);

                        if (Segundos >= 135 || Segundos <= 140)
                            //2
                            MaosEsticadaEsqDir(quadroAtual);


                        
                        //if(Pontos == 1000)

                        //else if(Pontos == 2000)

                        //else if (Pontos == 3000)

                        //else if (Pontos == 4000)

                        //else if (Pontos == 5000)

                        //else if (Pontos == 6000)

                        //else if (Pontos == 7000)

                        //else if (Pontos == 9000)

                        //else if (Pontos == 10000)

                        //else if (Pontos == 11000)

                        //else if (Pontos == 12000)

                        //else if (Pontos == 13000)

                        //else if(Pontos == 14000)

                        //else if (Pontos == 15000)

                        //else if (Pontos == 16000)

                        //else if (Pontos == 17000)

                        //else if (Pontos == 18000)

                        //else if (Pontos == 19000)

                        //else if (Pontos == 20000)

                        //else if (Pontos == 21000)

                        //else if (Pontos == 22000)

                        //else if (Pontos == 23000)

                        //else if (Pontos == 24000)

                        //else if (Pontos == 25000)

                        //else if (Pontos == 26000)

                        //else if (Pontos == 27000)

                        //else if (Pontos == 28000)

                        //else if (Pontos == 29000)

                        //else if (Pontos == 30000)

                        //else if (Pontos == 31000)

                        //else if (Pontos == 32000)

                        //else if (Pontos == 33000)

                        //else if (Pontos == 34000)

                        //else if (Pontos == 35000)

                        //else if (Pontos == 36000)

                        //else if (Pontos == 37000)

                        //else if (Pontos == 38000)

                        //else if (Pontos == 39000)

                        //else if (Pontos == 40000)

                        //else if (Pontos == 41000)

                        //else if (Pontos == 42000)

                        //else if (Pontos == 43000)

                        //else if (Pontos == 44000)

                        //else if (Pontos == 45000)

                        //else if (Pontos == 46000)

                        //else if (Pontos == 47000)

                        // 4800 4900 5000 5100 5200 5300 5400 5500 5600 5700 5800 5900 6000 6100 6200 6300 6400 6500 6600 6700 6800 6900 7000 7100 7200 7300 7400 7500 7600 7700 7800 7900
                        // 8000 8100 8200 8300 8400 8500 8600 8700 8800 8900 9000 9100 9200 9300 9400 9500 9600 9700 9800 9900 10000



                    }
                }
            }
        }


        //1
        private void MaoEsqDirAcima(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint cabeca = usuario.Joints[JointType.Head];

                bool novoTesteMaoAcimaCabeca = maoDireita.Position.Y > cabeca.Position.Y || maoEsquerda.Position.Y > cabeca.Position.Y;

                if (Testes != novoTesteMaoAcimaCabeca)
                {
                    Testes = novoTesteMaoAcimaCabeca;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 10;



                    }
                }
            }

        }
        //2
        private void MaosEsticadaEsqDir(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint Espinha = usuario.Joints[JointType.Spine];

                bool novoTesteMaoDirEsticada = maoDireita.Position.X > Espinha.Position.X && maoEsquerda.Position.X > Espinha.Position.X || maoDireita.Position.X < Espinha.Position.X && maoEsquerda.Position.X < Espinha.Position.X;

                if (Testes != novoTesteMaoDirEsticada)
                {
                    Testes = novoTesteMaoDirEsticada;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 10;

                    }
                    else
                    {

                    }
                }
            }

        }
        //3
        private void MaoEsqParaDirMaoDirParaEsq(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint Espinha = usuario.Joints[JointType.Spine];

                bool MaoEsqParaDirMaoDirParaEsq = maoDireita.Position.X < Espinha.Position.X || maoEsquerda.Position.X > Espinha.Position.X;

                if (Testes != MaoEsqParaDirMaoDirParaEsq)
                {
                    Testes = MaoEsqParaDirMaoDirParaEsq;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 10;

                    }
                    else
                    {

                    }
                }
            }
        }
        //4
        private void MaosEsqDir(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint Espinha = usuario.Joints[JointType.Spine];

                bool MaosEsqDir = maoDireita.Position.X < Espinha.Position.X && maoEsquerda.Position.X < Espinha.Position.X || maoDireita.Position.X > Espinha.Position.X && maoEsquerda.Position.X > Espinha.Position.X;


                if (Testes != MaosEsqDir)
                {
                    Testes = MaosEsqDir;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 10;

                    }
                    else
                    {

                    }
                }
            }

        }


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

                return BitmapSource.Create(quadro.Width, quadro.Height, 960, 960, PixelFormats.Bgr32, null, bytesImagem, quadro.Width * quadro.BytesPerPixel);
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
                return BitmapSource.Create(quadro.Width, quadro.Height, 960, 960, PixelFormats.Bgr32, null, bytesImagem, quadro.Width * 4);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Video.Source = new Uri(System.Environment.CurrentDirectory + "/resources/Musicas/amogus.mp4");
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            Pontuacao.Danca = 3;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (Video.Source != null)
            {
                Segundos++;




            }




        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            Pontuacao.Pontos = Pontos;
           // MessageBox.Show("A musica acabou");

            TelaPontos janela = new TelaPontos();
            janela.Show();
            this.Close();
            kinect.Dispose();
        }

        void SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            esqueletobugado.Children.Clear();
            Skeleton[] esqueletos = null;

            using (SkeletonFrame esqueletos_quadros_ms = e.OpenSkeletonFrame())
            {
                if (esqueletos_quadros_ms != null)
                {
                    esqueletos = new Skeleton[esqueletos_quadros_ms.SkeletonArrayLength];
                    esqueletos_quadros_ms.CopySkeletonDataTo(esqueletos);
                }
            }

            if (esqueletos == null) return;

            foreach (Skeleton esqueleto in esqueletos)
            {
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked)
                {
                    //Oh, I'll never kill myself to save my soul
                    Joint handJoint = esqueleto.Joints[JointType.HandRight];
                    Joint elbowJoint = esqueleto.Joints[JointType.ElbowRight];
                    bones_esqueleto(esqueleto.Joints[JointType.Head], esqueleto.Joints[JointType.ShoulderCenter]);
                    bones_esqueleto(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.Spine]);
                    bones_esqueleto(esqueleto.Joints[JointType.Spine], esqueleto.Joints[JointType.HipCenter]);
                    bones_esqueleto(esqueleto.Joints[JointType.HipCenter], esqueleto.Joints[JointType.HipLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.HipLeft], esqueleto.Joints[JointType.KneeLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.KneeLeft], esqueleto.Joints[JointType.AnkleLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.AnkleLeft], esqueleto.Joints[JointType.FootLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.HipCenter], esqueleto.Joints[JointType.HipRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.HipRight], esqueleto.Joints[JointType.KneeRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.KneeRight], esqueleto.Joints[JointType.AnkleRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.AnkleRight], esqueleto.Joints[JointType.FootRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.ShoulderLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.ShoulderLeft], esqueleto.Joints[JointType.ElbowLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.ElbowLeft], esqueleto.Joints[JointType.WristLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.WristLeft], esqueleto.Joints[JointType.HandLeft]);
                    bones_esqueleto(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.ShoulderRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.ShoulderRight], esqueleto.Joints[JointType.ElbowRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.ElbowRight], esqueleto.Joints[JointType.WristRight]);
                    bones_esqueleto(esqueleto.Joints[JointType.WristRight], esqueleto.Joints[JointType.HandRight]);
                    //I was gone, but how was I to know?
                }
            }
        }



        void bones_esqueleto(Joint j1, Joint j2)
        {
            Line esp_bones_esqueleto = new Line();
            esp_bones_esqueleto.Stroke = new SolidColorBrush(Colors.Purple);
            esp_bones_esqueleto.StrokeThickness = 5;
            ColorImagePoint j1P = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(j1.Position, ColorImageFormat.RgbResolution640x480Fps30);
            esp_bones_esqueleto.X1 = j1P.X;
            esp_bones_esqueleto.Y1 = j1P.Y;
            ColorImagePoint j2P = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(j2.Position, ColorImageFormat.RgbResolution640x480Fps30);
            esp_bones_esqueleto.X2 = j2P.X;
            esp_bones_esqueleto.Y2 = j2P.Y;

        }
        public static KinectSensor InicializarPrimeiroSensor()
        {
            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            kinect.Start();
            return kinect;
        }


        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            Video.Play();
            timer.Start();
            esqueletobugado.Visibility = Visibility.Visible;
            btnIniciar.Visibility = Visibility.Hidden;
            Borda.Visibility = Visibility.Visible;
            Voltar.Visibility = Visibility.Hidden;
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {

            MainWindow janela = new MainWindow();
            janela.Show();
            this.Close();
            Parar_Executar();

        }

        private void Parar_Executar()
        {
            Pontuacao.Pontos = 0;
            Video.Stop();
            Video.Source = null;
            timer.Stop();
        }

    }
}
