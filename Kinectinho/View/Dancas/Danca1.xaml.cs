using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Kinectinho.Model;
using Microsoft.Kinect;


namespace Kinectinho.View.Dancas
{
    /// <summary>
    /// Lógica interna para Danca1.xaml
    /// </summary>

    public partial class Danca1 : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        KinectSensor kinect;
        int Segundos, Pontos;
        bool Testes;


        public Danca1()
        {
            InitializeComponent();
            InicializarSensor();
            Video.MediaEnded += MediaPlayer_MediaEnded;

        }

      
        public static KinectSensor InicializarPrimeiroSensor()
        {
            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            kinect.Start();
            return kinect;
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

        

        private void kinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            esqueletobugado.Background = new ImageBrush(ReconhecerHumanos(e.OpenDepthImageFrame()));
        }

        private void kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            esqueletobugado.Background = new ImageBrush(ObterImagemSensorRGB(e.OpenColorImageFrame()));
        }
        /**
       * Desenhar o esqueleto do usuário.
       */
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
            Video.Source = new Uri(System.Environment.CurrentDirectory + "/resources/Musicas/69.mp4");
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            Pontuacao.Danca = 1;

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
            //MessageBox.Show("A musica acabou");

            TelaPontos janela = new TelaPontos();
            janela.Show();
            this.Close();
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
        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            Video.Play();
            timer.Start();
            esqueletobugado.Visibility = Visibility.Visible;
            btnIniciar.Visibility = Visibility.Hidden;
            Borda.Visibility = Visibility.Visible;
            Voltar.Visibility = Visibility.Hidden;

        }

        private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {
                if (quadroAtual != null)
                {
                    if(Video.Source != null)
                    {

                        //1 - MaosAcima(quadroAtual);
                        //2 - MaoEsqDirAcima(quadroAtual);
                        //3 - MaosEsticadas(quadroAtual);
                        //4 - MaosAbaixo(quadroAtual);
                        //5 - MaosEsticadaEsqDir(quadroAtual);


                        if (Segundos >= 5 && Segundos <= 8)
                            //1 -
                            MaosAcima(quadroAtual);

                        if (Segundos >= 13 && Segundos <= 15)
                            //2 -
                            MaoEsqDirAcima(quadroAtual);

                        if(Segundos >= 18 && Segundos <= 25)
                            //3 -
                            MaosEsticadas(quadroAtual);

                        if(Segundos >= 38 && Segundos <= 45)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 48 && Segundos <= 53)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 55 && Segundos <= 60)
                            //5 -
                            MaosEsticadaEsqDir(quadroAtual);

                        if(Segundos >= 61 && Segundos <= 65)
                            //3 -
                            MaosEsticadas(quadroAtual);
                            
                        if(Segundos >= 65 && Segundos <= 70)
                            //2 -
                            MaoEsqDirAcima(quadroAtual);

                        if(Segundos >= 75 && Segundos <= 80)
                            //3 -
                            MaosEsticadas(quadroAtual);    

                        if(Segundos >= 92 && Segundos <= 96)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 100 && Segundos <= 105)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 110 && Segundos <= 112)
                            //2 -
                            MaoEsqDirAcima(quadroAtual);

                        if(Segundos >= 120 && Segundos <= 124)
                            //3 -
                            MaosEsticadas(quadroAtual);

                        if(Segundos >= 131 && Segundos <= 134)
                            //3 -
                            MaosEsticadas(quadroAtual);

                        if(Segundos >= 138 && Segundos <= 141)
                            //2 -
                            MaoEsqDirAcima(quadroAtual);

                        if(Segundos >= 145 && Segundos <= 148)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 154 && Segundos <= 156)
                            //4 -
                            MaosAbaixo(quadroAtual);

                        if(Segundos >= 159 && Segundos <= 164)
                            //5 -
                            MaosEsticadaEsqDir(quadroAtual);


                        
                    }
                }
            }
        }

        
        //1
        private void MaosAcima(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint cabeca = usuario.Joints[JointType.Head];

                bool novoTesteMaoAcimaCabeca = maoDireita.Position.Y > cabeca.Position.Y && maoEsquerda.Position.Y > cabeca.Position.Y;

                if (Testes != novoTesteMaoAcimaCabeca)
                {
                    Testes = novoTesteMaoAcimaCabeca;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 1000;
                        


                    }
                }
            }

        }

        //2
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
                        Pontos = Pontos + 1000;
                       

                    }
                }
            }

        }

        //3
        private void MaosEsticadas(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint MaoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint cotoveloEsquerdo = usuario.Joints[JointType.ElbowLeft];
                Joint cotoveloDireito = usuario.Joints[JointType.ElbowRight];
                Joint quadril = usuario.Joints[JointType.HipCenter];

                bool novoTesteMaosEsticada = maoDireita.Position.X > cotoveloDireito.Position.X && cotoveloEsquerdo.Position.X > MaoEsquerda.Position.X && MaoEsquerda.Position.Y > quadril.Position.Y && maoDireita.Position.Y > quadril.Position.Y;

                if (Testes != novoTesteMaosEsticada)
                {
                    Testes = novoTesteMaosEsticada;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 1000;

                       
                    }
                    else
                    {
                       
                    }
                }
            }

        }

        //4
        private void MaosAbaixo(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];

            quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                Joint cotoveloDireito = usuario.Joints[JointType.ElbowRight];
                Joint cotoveloEsquerdo = usuario.Joints[JointType.ElbowLeft];


                bool novoTesteMaosAbaixo = maoDireita.Position.Y < cotoveloDireito.Position.Y && maoEsquerda.Position.Y < cotoveloEsquerdo.Position.Y;

                if (Testes != novoTesteMaosAbaixo)
                {
                    Testes = novoTesteMaosAbaixo;
                    if (Testes == true)
                    {
                        Pontos = Pontos + 1000;
                    }
                    else
                    {

                    }
                }
            }

        }

        //5
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
                        Pontos = Pontos + 1000;
                        
                    }
                    else
                    {

                    }
                }
            }

        }
    }
}
