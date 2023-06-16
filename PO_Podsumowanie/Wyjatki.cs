using System;
using System.Collections.Generic;
using System.Text;

namespace PO_Podsumowanie_Wyjatki
{
    /*
     * Wyjątki (exception) pozwalają na wyrzucenie błedu w inny sposób niż po prostu wypisanie czegoś w konsoli
     * 
     * Jeżeli program ma przestać działać przy wyjątku można zrobić tak:
     * throw new Exception("wiadomość wyjątku");
     * 
     * Jeżeli program ma kontunować działanie, trzeba użyć bloku try catch
     * 
     * try - program próbuje wykonać kod
     * catch - wyłapuje, że wystąpił wyjątek (nie wiadomo jaki)
     * catch(Exception e) - wyłapuje jakikolwiek wyjątek
     * catch(ArgumentException e) - wyłapuje konkretny wyjątek, wtedy można napisać kilka catchów,
     * i w każdym obsłużyć inny wyjątek
     * finaly - wywoływane na końcu, nieważne czy był wyjątek czy nie
     * 
     * Customowe Exception muszą dziedziczyć z klasy Exception
     * 
     */
    class Wyjatki
    {
        public static void Test()
        {
            Wyj2();
        }
        public static void Wyj1()
        {
            Console.WriteLine("Napisz liczbe albo nie");
            string line = Console.ReadLine();
            try
            {
                int n = Convert.ToInt32(line); // jak line to nie liczba, to tutaj bedzie przerwanie
                if (n > 10)
                    throw new ArgumentException("liczba powyzej 10");
            }
            catch(FormatException e)
            {
                Console.WriteLine("\t" + e.Message);
                Console.WriteLine("nie podales liczby");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("finally:    koniec");
            }
        }
        public static void Wyj2()
        {
            Console.WriteLine("podaj liczbe");
            int n = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (n > 10)
                    throw new CustomException("liczba wieksza niz 10", n); // wyrzucanie własnego wyjątku
            }
            catch(CustomException e)
            {
                Console.WriteLine("\t" + e.Message + ": " + e.Value);
            }
        }

        class CustomException : Exception
        {
            public int Value;
            public CustomException(string message, int value) : base(message)
            {
                Value = value;
            }
        }
    }
}
