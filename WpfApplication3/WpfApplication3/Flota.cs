using System;
using System.Windows.Controls;

namespace Okręty

{
    class Flota
    {
        private int protector;
        private int hp ;
        private MainWindow okno;
        private static int n = 10;
        Statek[] statki= new Statek [10];
        public bool[,] jużstrzelano =new bool[10,10] ;

        private Random los = new Random();
        



        public Flota(MainWindow okno)
        {
            hp = 20;
            this.okno = okno;
            statki[9]=new Statek(4);


             for (int i = 7; i < 9; i++) statki[i] = new Statek(3);

             for (int i = 4; i < 7; i++) statki[i] = new Statek(2);

             for (int i = 0; i < 4; i++) statki[i]=new Statek(1); 


            /*
           // beginning:
for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Statek.Occupied[i, j] = false;
                        jużstrzelano[i, j] = false;
                    }
                }


            protector = 0;
            hp=20;

            this.okno = okno;
                int coords,x,y,offset;  

                bool vert;

            
                  //Duży statek
           do
            {


                
                
                x = los.Next(7);
                y = los.Next(7);
                coords = 10 * x + y;
              //  if (protector>5000) goto beginning;
            } while (CheckAvailability(coords)|| CheckAvailability(coords+offset) || CheckAvailability(coords+2*offset) || CheckAvailability(coords+3*offset));
            DodajStatek(x, y, 4, vert);
            //statki[9] = new Statek(nowy / 10, nowy % 10, 1, vert); 


             //Większe statki
                        for (int i = 7; i < 9; i++)
                        {
                            do
                            {


                                vert = (los.Next() % 2 == 1);
                                offset = (vert) ? 1 : 10;
                                x = los.Next(8);
                                y = los.Next(8);
                                coords = 10 * x + y;
                                 //Że niby to był zły pomysł? https://imgs.xkcd.com/comics/goto.png
                               //   if (protector > 5000) goto beginning;
                            } while (CheckAvailability(coords) || CheckAvailability(coords + offset) || CheckAvailability(coords + 2 * offset));

                            DodajStatek(x, y, 3, vert);
                            //statki[i] = new Statek(nowy / 10, nowy % 10, 1, vert);


                        }



              //Mniejsze statki
                        for (int i = 4; i < 7; i++)
                        {
                
                            do
                            {
                                vert = (los.Next() % 2 == 1);
                                offset = (vert) ? 1 : 10;
                                x = los.Next(9);
                                y = los.Next(9);
                                coords = 10 * x + y;

                            } while (CheckAvailability(coords)|| CheckAvailability(coords + offset));
                           // statki[i] = new Statek(nowy / 10, nowy % 10, 2, vert);
                            DodajStatek(x, y,2,vert);

                           // statki[i] = new Statek(nowy / 10, nowy % 10, 2, vert);


                        }
            

            //Małe statki
            for (int i = 0; i < 4; i++)
                {
                    do
                    {


                        vert = (los.Next()%2 == 1);
                        x = los.Next(10);
                        y = los.Next(10);
                        coords = 10*x + y;

                    } while (CheckAvailability(coords));
                //Znaleźliśmy wolne miejsce, teraz je zajmijmy
                //  statki[i] = new Statek(nowy/10,nowy%10, 1,vert);
                DodajStatek(x, y, 1, vert);


            }

           


    */
        }





        //Sprawdzamy pola dookoła wybranego punktu
        private bool CheckAvailability(int x)            
        {


            return (
                  CheckField(x - 11) || CheckField(x-1) || CheckField(x + 9)||
                  CheckField(x - 10) || CheckField(x) || CheckField(x + 10)||
                  CheckField(x - 9) || CheckField(x+1) || CheckField(x + 11)
                     );

        }

         bool CheckField(int coord)
        {
            try
            {
                return (Statek.Occupied[coord/10, coord%10]);

            }
            catch (IndexOutOfRangeException)
            {
                protector++;
                 

            }
            return false;
        }

        
        
        public void Check(int x, int y, Button b)
        {
            

            if (Statek.Occupied[x, y])
            {
                
                okno.info.Text = "Trafiony!";
                hp--;
                okno.remaining.Text = "Statki do zestrzelenia: " + hp;
                b.Background = okno.Statek();



            }
            else
            {
                okno.info.Text = "Pudło!";
                b.Background = okno.Splash();
               

            }

            if (hp == 0)
            {
                okno.TheGrid.IsEnabled = false;
                okno.TheGrid.Opacity = 0.2;
                okno.info.Text = "Udało się!!!";
                
            }

         }      
        //private void DodajStatek(int x, int y, int length, bool vert)
        //{
        //    Occupied[x, y] = true;
        //    if (vert)
        //    {
        //        switch (length)
        //        {
        //            case 1:
        //                break;
        //            case 2:
        //                Occupied[x, y + 1] = true;
        //                goto case 1;
        //            case 3:
        //                Occupied[x, y + 2] = true;
        //                goto case 2;
        //            case 4:
        //                Occupied[x, y + 3] = true;
        //                goto case 3;
        //        }
        //    }
        //    else
        //    {
        //        switch (length)
        //        {
        //            case 1:
        //                break;
        //            case 2:
        //                Occupied[x + 1,y ] = true;
        //                goto case 1;
        //            case 3:
        //                Occupied[x+ 2, y]  = true;
        //                goto case 2;
        //            case 4:
        //                Occupied[x+ 3, y ] = true;
        //                goto case 3;
        //        }
        //    }

        //}



    }
}
