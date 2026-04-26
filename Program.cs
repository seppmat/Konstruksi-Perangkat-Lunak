using System;
using tpModul8;

class Program
{
    static void Main()
    {
        var config = new CovidConfig();
        config.UbahSatuan(); 

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.SatuanSuhu + ": ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?: ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = config.SatuanSuhu.Equals("celcius", StringComparison.OrdinalIgnoreCase)
            ? (suhu >= 36.5 && suhu <= 37.5)
            : (suhu >= 97.7 && suhu <= 99.5);

        Console.WriteLine(hari < config.BatasHariDeman && suhuValid ? config.PesanDiterima : config.PesanDitolak);
    }
}