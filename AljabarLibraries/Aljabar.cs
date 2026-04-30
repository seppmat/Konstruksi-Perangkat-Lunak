using System;

namespace AljabarLibraries
{
    public class Aljabar
    {
        // Fungsi A: Akar Persamaan Kuadrat
        public static double[] AkarPersamaanKuadrat(double[] persamaan)
        {
            // persamaan: {a, b, c}
            double a = persamaan[0];
            double b = persamaan[1];
            double c = persamaan[2];

            double diskriminan = (b * b) - (4 * a * c);

            if (diskriminan < 0)
            {
                // tidak ada akar real
                return new double[] { };
            }

            double x1 = (-b + Math.Sqrt(diskriminan)) / (2 * a);
            double x2 = (-b - Math.Sqrt(diskriminan)) / (2 * a);

            return new double[] { x1, x2 };
        }

        // Fungsi B: Hasil Kuadrat ( (ax + b)^2 )
        public static double[] HasilKuadrat(double[] persamaan)
        {
            // persamaan: {a, b}
            double a = persamaan[0];
            double b = persamaan[1];

            double A = a * a;        // a^2
            double B = 2 * a * b;    // 2ab
            double C = b * b;        // b^2

            return new double[] { A, B, C };
        }
    }
}