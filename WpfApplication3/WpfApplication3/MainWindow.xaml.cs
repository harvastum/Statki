using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using NUnit.Framework.Constraints;

/// <summary>
///  
/// Codebehind for the main window.
/// Creates buttons, functions responsible for changing images are located here as well.
/// 
/// </summary>
namespace Okręty
{
    
    public partial class MainWindow : Window
    {
        
        private int naboje=0;
        private Button[,] siatka;
        private Flota flota;
        public MainWindow()
        {
            
            InitializeComponent();
            flota=new  Flota(this);
            siatka=new Button[10,10];
            

            //Dynamic buttons assigning.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    siatka[i,j] = new Button();
                    Grid.SetColumn(siatka[i,j], i);
                    Grid.SetRow(siatka[i,j], j);
                    TheGrid.Children.Add(siatka[i,j]);
                   
                    siatka[i, j].Name = "q" + i.ToString() + j.ToString();
                    siatka[i,j].Background= Transparent();


                    siatka[i, j].Style = new Style();
                    siatka[i, j].Style.Seal();



                    siatka[i,j].Click += AllButtons_Click;
                }
            }
            Window.Background = Back();




        }



        private void AllButtons_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            int x = Grid.GetColumn(b);
            int y = Grid.GetRow(b);

            if (flota.Jużstrzelano[x, y])
            {
                info.Text = "Tutaj już strzelałeś!!!";
                return;
            }
            flota.Jużstrzelano[x, y] = true;

            

            flota.Check(Grid.GetColumn(b),Grid.GetRow(b),b);
            naboje++;
            Licznik.Text = "Wykorzystane naboje: " + naboje.ToString();

        }


        #region OBRAZKI

        public ImageBrush Transparent()
        {
            ImageBrush newBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\Images\\przez.jpg"))
            };
            return newBrush;
        }


        public ImageBrush ShipImage()
        {
            ImageBrush newBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\Images\\5.png"))
            };
            return newBrush;
        }
        public ImageBrush Back()
        {
            ImageBrush newBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\Images\\1.jpg"))
            };
            return newBrush;
        }
        public ImageBrush Splash()
        {
            ImageBrush newBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\Images\\Przechwytywanie.png"))
            };
            return newBrush;
        }

        #endregion


    }

}
