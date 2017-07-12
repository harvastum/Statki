
using System.Windows.Controls;

namespace Okręty

{
    class Flota
    {
        private int _hp ;
        private MainWindow okno;
        Statek[] statki = new Statek [10];
        public bool[,] Jużstrzelano = new bool[10,10] ;
        



        public Flota(MainWindow okno)
        {
            _hp = 20;
            this.okno = okno;
            statki[9]=new Statek(4);


             for (int i = 7; i < 9; i++) statki[i] = new Statek(3);

             for (int i = 4; i < 7; i++) statki[i] = new Statek(2);

             for (int i = 0; i < 4; i++) statki[i] = new Statek(1); 

            
        }
        
        public void Check(int x, int y, Button b)
        {
            if (Statek.Occupied[x, y])
            {
                
                okno.info.Text = "Trafiony!";
                _hp--;
                okno.remaining.Text = "Statki do zestrzelenia: " + _hp;
                b.Background = okno.ShipImage();



            }
            else
            {
                okno.info.Text = "Pudło!";
                b.Background = okno.Splash();
               

            }

            if (_hp == 0)
            {
                okno.TheGrid.IsEnabled = false;
                okno.TheGrid.Opacity = 0.2;
                okno.info.Text = "Udało się!!!";
                
            }
         }      
    }
}
