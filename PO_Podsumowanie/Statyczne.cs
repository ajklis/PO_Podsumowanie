using System;
using System.Collections.Generic;
using System.Text;

namespace PO_Podsumowanie_Static
{
    static class Statyczna
    { // moze zawierac tylko pola i metody statyczne
        static int zmienna = 10;
        public static void Test()
        {
            NStatic n = new NStatic(10);
            n.Metoda();
            //n.Statyczna(); // nie dziala
            NStatic.Statyczna();
        }
    }

    class NStatic
    {
        static int STALA = 10;
        int val;

        public NStatic(int val)
        {
            this.val = val + STALA;
        }
        public void Metoda()
        {
            Console.WriteLine("Wywolano metode");
        }
        public static void Statyczna()
        {
            Console.WriteLine("Wywolano statyczna");
        }

        public void Test()
        {
            Metoda();
            Statyczna(); // git
        }
        public static void STest()
        {
            //Metoda(); // nie dziala
            Statyczna();
        }

        /* W klasie statycznej mogą być tylko pola statyczne
         * 
         * W klasie niestatycznej mogą być statycznie i nie
         * 
         * Metody niestatyczne mogą się odwoływać do zmiennych i metod statycznych,
         * ale nie w drugą stronę
         * 
         * Żeby odwołać się do metod niestatycznych:
         * NStatic n = new NStatic(10);
         * n.Metoda() - dziala
         * Do statycznych:
         * n.Statyczna() - nie dziala
         * NStatic.Statyczna() - dziala
         * 
         */
    }
}
