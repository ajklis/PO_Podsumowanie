using System;

namespace PO_Podsumowanie_Konstruktory
{
    class Bazowa
    {
        public int v1;
        protected int v2;
        private int v3;
        // konstruktor bazowy
        public Bazowa(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
        public Bazowa(int v1) : this(v1, 0, 0)
        {
            // this odwoluje sie w tym wypadku do konstruktora aktualnej klasy z danymi parametrami
            Console.WriteLine("Wywolano krotszy konstruktor");
        }
    }

    class Pochodna : Bazowa
    {
        public Pochodna(int v1, int v2, int v3) : base(v1, v2, v3)
        {
            
        }
        public Pochodna() : base(10, 20, 30)
        {
            int pobrana1 = v1; // git
            int pobrana2 = v2; // git
            //int pobrana3 = v3; // nie zadziala, bo v3 jest prywatne w klasie bazowej
            // zeby odczytac wartosc z v3 trzeba zrobic do tego metode albo wlasciwosc
        }
    }

    class KonstruktoryTest
    {
        public static void Test()
        {
            Bazowa b = new Bazowa(10);
            int num;
            num = b.v1; // git

            //num = b.v2;
            //num = b.v3;
            // nie dziala bo private/protected

            Pochodna p = new Pochodna();
            num = p.v1; // git

            //num = p.v2;
            //num = p.v3;
            // to samo co wyzej
        }
    }
}
