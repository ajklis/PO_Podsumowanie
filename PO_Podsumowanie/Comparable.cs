using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Text;

namespace PO_Podsumowanie_Comparable
{
    class Comparable
    {
        public static void Test()
        {
            Student a = new Student("A", 1);
            Student b = new Student("B", 2);
            Student c = new Student("C", 2);
            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine();
            Console.WriteLine();

            List<Student> lista = new List<Student> { c,b,a };
            Show(lista);
            lista.Sort();
            Show(lista);

        }
        public static void Show<T>(List<T> list)
        {
            foreach(var v in list)
                Console.WriteLine(v);
        }
    }

    class Student : IComparable<Student>, IComparable<int> 
    {
        public string Imie;
        public int Index;

        public Student(string imie, int index)
        {
            Imie = imie;
            Index = index;
        }

        public int CompareTo(Student other)
        {
            return Imie.CompareTo(other.Imie);
            // zwraca -1 jak mniejsze, 0 jak równe i 1 jak większe
        }
        public int CompareTo(int other) // teraz można porównać studenta do liczby
        {
            return Index.CompareTo(other);
        }
        public override string ToString()
        {
            return $"{Imie} {Index}";
        }

        public class StudentPoIndexieASCComparer : IComparer<Student> // rosnący comparer po indeksie
        {
            public int Compare(Student x, Student y)
            {
                if (x == null || y == null)
                    return 1;
                return x.Index.CompareTo(y.Index);
            }
        }

    }
}
