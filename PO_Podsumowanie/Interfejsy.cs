using System;
using System.Collections.Generic;
using System.Text;

namespace PO_Podsumowanie_Interfejsy
{
    /*
     * Interfejsy to coś podobnego do klasy: mogą dodawać metody do funkcji albo wymuszać nadpisanie
     * Nie można tworzyć ich instancji, ale można używać ich jako typów:
     * 
     * IInterface obj = new Klasa(); - zadziała
     * 
     * wtedy można wywołać 
     * obj.Metoda(); oraz
     * obj.MetodaAbs(); 
     * 
     * ale nie można wywołać 
     * obj.MetodaKlasy();
     * ponieważ nie jest ona zdefiniowana w interfejsie
     * 
     * Klasa może dziedziczyć tylko z jednej klasy, ale z dowolnej ilości interfejsów
     */
    
    class InterfejsyTest
    {
        public static void Test()
        {
            IInterface obj = new Klasa();
            obj.Metoda();
            obj.MetodaAbs();
            //obj.MetodaKlasy(); - nie zadziala
            Klasa k = (Klasa)obj;
            k.MetodaKlasy(); // to juz tak
        }
    }

    interface IInterface
    {
        public void Metoda()
        {
            Console.WriteLine("Wywołano IInterface.Metoda()");
        }
        public abstract void MetodaAbs();
        //public void Metoda1();
    }
    class Klasa : IInterface
    {
        // nie trzeba implementować IInterface.Metoda();
        public new void MetodaAbs() // bez tego program się nie skompiluje
        {
            Console.WriteLine("Nadpisana metoda abstrakcyjna");
        }
        public void MetodaKlasy()
        {
            Console.WriteLine("Metoda klasy");
        }
    }

}
