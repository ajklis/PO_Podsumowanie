using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PO_Podsumowanie_Klasy
{
    /*
     * Klasy abstrakcyjne są tylko do dziedziczenia, nie można tworzyć ich instancji
     * Klas sealed nie można dziedziczyć
     * 
     * Jeżeli w klasach pochodnych jakaś funkcja ma być zaimplementowana to oznacza się ją abstract
     * 
     * Jeżeli nie zawsze chcemy ją zmienić, np tylko w jednej pochodnej klasie, oznaczamy
     * ją jako virtual
     * Do metod bez abstract lub virtual można użyć operatora new żeby ją zmienić,
     * ale w takim wypadku
     * 
     * Bazowa p = new Pochodna();
     * p.Metoda();
     * 
     * wywoła się funkcja klasy bazowej a nie funkcja new w klasie pochodnej
     * 
     * Ogólnie operator new nadpisuje funkcje a override je zamienia
     * Gdyby w przykładzie wyżej Metoda była override w klasie pochodnej, wywołała by się
     * funkcja klasy pochodnej
     */
    
    class KlasyTest
    {
        public static void Test()
        {
            Wlasciwosci w = new Wlasciwosci();
            w.Zmienna = 10;
            int num = w.Zmienna;

            // PRZYKŁAD RÓŻNICY MIĘDZY NEW I OVERRIDE
            Pochodna p = new Pochodna();
            Abstrakcyjna a = p; // moze tak byc

            p.Metoda(); // wywoła nową metodę
            a.Metoda(); // wywola "NABS metoda w ABS klasie"

            p.MetodaV(); // wywoła nadpisaną metodę
            a.MetodaV(); // też wywoła nadpisaną metodę
            
        }
    }

    class Wlasciwosci
    {
        private int wartosc; // zmienna
        protected int Wartosc // właściwość
        {
            get => wartosc;
            set => wartosc = value;
        }
        // mozna tez tak
        public int Wart { get; protected set; }
        // można też coś takiego
        public int Publiczna { get; set; } 
        // teraz nie ma potrzeby robienia drugiej zmiennej
        // Mozna też dopisać coś do metod get set
        private int zmienna;
        public int Zmienna
        {
            get
            {
                Console.WriteLine("Pobrano zmienną");
                return zmienna;
            }
            private set
            {
                Console.WriteLine("Ustawiono zmienną");
                zmienna = value;
            }
        }
        public int GetWartosc() => wartosc; // mozna też to zrobić metodą
    }

    abstract class Abstrakcyjna // nie można zrobić jej instancji, można z niej tylko dziedziczyć
    {
        public abstract void MetodaAbs();
        public virtual void MetodaV() // virtual pozwala na nadpisanie tej metody w klasach dziedziczonych
        {
            Console.WriteLine("Nieabstarkcyjna wirtualna metoda w abstrakcyjnej klasie");
        }
        public void Metoda()
        {
            Console.WriteLine("NABS metoda w ABS klasie");
        }
    }
    class Pochodna : Abstrakcyjna // w klasach pochodnych metody abstrakcyjne muszą być zaimplementowane
    {
        public override void MetodaAbs()
        {
            Console.WriteLine("Nadpisana metoda abs");
        }
        //public new void MetodaV() // tworzy nową metodę o tej samej nazwie (nie nadpisuje metody bazowej!)
        public override void MetodaV() // to nadpisuje metode bazową
        {
            Console.WriteLine("nadpisana metoda w pochodnej");
        }
        public new void Metoda() // jeżeli zamiast new by było override to był by błąd 
        {                        // i program się nie skompiluje
            Console.WriteLine("nowa metoda, nie nadpisana");
        }
    }
}
