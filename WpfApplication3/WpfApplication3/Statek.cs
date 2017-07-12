using System;

namespace Okręty
{
    class Statek
    {
        private static readonly int n = 10;

        

        public static bool [,]Occupied=new bool [n,n];
        public static bool[,] Jużstrzelano = new bool[10, 10];
        

        private Random los = new Random();
       
         



        

        public Statek(int length)
        {   

            bool vert = los.Next() % 2 == 1;
            int coords, x, y, offset = (vert) ? 1 : 10;

            
            

            switch (length)
            {
                case 1:
                    do
                    {


                        vert = (los.Next() % 2 == 1);
                        x = los.Next(10);
                        y = los.Next(10);
                        coords = 10 * x + y;

                    } while (CheckAvailability(coords));

                    break;

                case 2:
                    do
                    {
                        x = los.Next(9);
                        y = los.Next(9);
                        coords = 10 * x + y;

                    } while (CheckAvailability(coords) || CheckAvailability(coords + offset));

                    break;
                case 3:

                    do
                    {
                        x = los.Next(8);
                        y = los.Next(8);
                        coords = 10 * x + y;
                    } while (CheckAvailability(coords) || CheckAvailability(coords + offset) || CheckAvailability(coords + 2 * offset));

                    break;

                case 4:
                    do
                    {
                        x = los.Next(7);
                        y = los.Next(7);
                        coords = 10 * x + y;
                    } while (CheckAvailability(coords) || CheckAvailability(coords + offset) || CheckAvailability(coords + 2 * offset) || CheckAvailability(coords + 3 * offset));
                    
                    break;
                default:        //Only done to get rid of VS notifications, needless besides that.
                    x = 1;
                    y = 1;
                    break;
            }

            DodajStatek(x, y, length, vert);


        }




      

        private bool CheckAvailability(int coords)
        {


            return (
                  CheckField(coords - 11) || CheckField(coords - 1) || CheckField(coords + 9) ||
                  CheckField(coords - 10) || CheckField(coords) || CheckField(coords + 10) ||
                  CheckField(coords - 9) || CheckField(coords + 1) || CheckField(coords + 11)
                     );

        }
        private bool CheckField(int coord)
        {
            try
            {
                return (Occupied[coord / 10, coord % 10]);

            }
            catch (IndexOutOfRangeException)
            { 

            }
            return false;
        }
        private void DodajStatek(int x, int y, int length, bool vert)
        {
            Occupied[x, y] = true;
            if (vert)
            {
                switch (length)
                {
                    case 1:
                        break;
                    case 2:
                        Occupied[x, y + 1] = true;
                        goto case 1;
                    case 3:
                        Occupied[x, y + 2] = true;
                        goto case 2;
                    case 4:
                        Occupied[x, y + 3] = true;
                        goto case 3;
                }
            }
            else
            {
                switch (length)
                {
                    case 1:
                        break;
                    case 2:
                        Occupied[x + 1, y] = true;
                        goto case 1;
                    case 3:
                        Occupied[x + 2, y] = true;
                        goto case 2;
                    case 4:
                        Occupied[x + 3, y] = true;
                        goto case 3;
                }
            }

        }




    }
}
