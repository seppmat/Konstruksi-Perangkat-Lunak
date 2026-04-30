using System;

namespace MatematikaLibraries
{
    public class Matematika
    {
        // A. FPB (Faktor Persekutuan Terbesar)
        public static int FPB(int input1, int input2)
        {
            while (input2 != 0)
            {
                int temp = input2;
                input2 = input1 % input2;
                input1 = temp;
            }
            return input1;
        }

        // B. KPK (Kelipatan Persekutuan Terkecil)
        public static int KPK(int input1, int input2)
        {
            return (input1 * input2) / FPB(input1, input2);
        }

        // C. Turunan
        public static string Turunan(int[] persamaan)
        {
            // contoh: {1, 4, -12, 9} => x^3 + 4x^2 -12x + 9
            int n = persamaan.Length - 1;
            string hasil = "";

            for (int i = 0; i < persamaan.Length - 1; i++)
            {
                int koef = persamaan[i];
                int pangkat = n - i;

                int hasilKoef = koef * pangkat;
                int hasilPangkat = pangkat - 1;

                if (hasilKoef == 0) continue;

                if (hasil != "" && hasilKoef > 0)
                    hasil += " + ";
                else if (hasilKoef < 0)
                    hasil += " - ";

                int absKoef = Math.Abs(hasilKoef);

                if (absKoef != 1 || hasilPangkat == 0)
                    hasil += absKoef;

                if (hasilPangkat > 0)
                    hasil += "x";

                if (hasilPangkat > 1)
                    hasil += hasilPangkat;
            }

            return hasil;
        }

        // D. Integral
        public static string Integral(int[] persamaan)
        {
            // contoh: {4, 6, -12, 9}
            int n = persamaan.Length - 1;
            string hasil = "";

            for (int i = 0; i < persamaan.Length; i++)
            {
                int koef = persamaan[i];
                int pangkat = n - i;

                int hasilPangkat = pangkat + 1;
                double hasilKoef = (double)koef / hasilPangkat;

                if (hasilKoef == 0) continue;

                if (hasil != "" && hasilKoef > 0)
                    hasil += " + ";
                else if (hasilKoef < 0)
                    hasil += " - ";

                double absKoef = Math.Abs(hasilKoef);

                if (absKoef != 1 || hasilPangkat == 0)
                    hasil += absKoef;

                if (hasilPangkat > 0)
                    hasil += "x";

                if (hasilPangkat > 1)
                    hasil += hasilPangkat;
            }

            hasil += " + C";

            return hasil;
        }
    }
}