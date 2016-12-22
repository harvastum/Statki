using System;

namespace Okręty
{
    /// <summary>
    /// Wychodzi na to, że jednak do niczego się nie przydała ta klasa.
    /// Wszystko zrobiłem w ramach floty.
    /// Obiektowość to nie jest moja mocna strona :L
    /// </summary>
    class Statek
    {
        private int hp;
        private Random los = new Random();
        int x;
        int y;
        int[] occupies=new int[] {-1,-1,-1,-1};
         bool vertical;

        public bool Vertical
        {
            get
            {
                return vertical;
            }

            set
            {
                vertical = value;
            }
        }

        public Statek(int x, int y, int length, bool vert)
        {
            hp = length;
            vertical = vert;
            this.x = x;
            this.y = y;


            switch (length)
            {

                case 1:
                    occupies[0] = 10*x + y;

                    break;
                case 2:
                    if (vert)
                        occupies[1] = 10 * x + y + 1;
                    else
                        occupies[1] = 10 * (x + 1) + y;
                    goto case 1;
                case 3:
                    if (vert)
                        occupies[2] = 10 * x + y + 2;
                    else
                        occupies[2] = 10 * (x + 2) + y;
                    goto case 2;
                case 4:
                    if (vert)
                        occupies[3] = 10*x + y + 3;
                    else
                        occupies[3] = 10*(x + 3) + y;

                    goto case 3;
            }

        }


        ~Statek()
        {
            


        }



        
    }
}
