using System;
using AljabarLibraries;

class Program
{
    static void Main(string[] args)
    {
        // Contoh Akar Persamaan Kuadrat
        double[] hasilAkar = Aljabar.AkarPersamaanKuadrat(new double[] { 1, -3, -10 });

        Console.WriteLine("Akar Persamaan Kuadrat:");
        foreach (var x in hasilAkar)
        {
            Console.WriteLine(x);
        }

        // Contoh Hasil Kuadrat
        double[] hasilKuadrat = Aljabar.HasilKuadrat(new double[] { 2, -3 });

        Console.WriteLine("\nHasil Kuadrat:");
        Console.WriteLine($"{hasilKuadrat[0]}x^2 + {hasilKuadrat[1]}x + {hasilKuadrat[2]}");
    }
}