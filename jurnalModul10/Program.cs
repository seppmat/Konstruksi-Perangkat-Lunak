using System;
using MatematikaLibraries;

class Program
{
    static void Main(string[] args)
    {
        // FPB
        Console.WriteLine("FPB(60, 45): " + Matematika.FPB(60, 45));

        // KPK
        Console.WriteLine("KPK(12, 8): " + Matematika.KPK(12, 8));

        // Turunan
        Console.WriteLine("Turunan:");
        Console.WriteLine(Matematika.Turunan(new int[] { 1, 4, -12, 9 }));

        // Integral
        Console.WriteLine("\nIntegral:");
        Console.WriteLine(Matematika.Integral(new int[] { 4, 6, -12, 9 }));
    }
}