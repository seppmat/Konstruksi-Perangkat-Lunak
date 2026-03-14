using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        //TableDriven
        KodePos kodePos = new KodePos();

        Console.Write("Masukkan kelurahan: ");
        string kelurahan = Console.ReadLine();

        string kode = kodePos.getKodePos(kelurahan);
        Console.WriteLine("Kode pos: " + kode);

        Console.WriteLine();

        //StateBased
        DoorMachine pintu = new DoorMachine();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Pilih aksi:");
            Console.WriteLine("1. Buka Pintu");
            Console.WriteLine("2. Kunci Pintu");
            Console.WriteLine("3. Keluar");

            Console.Write("Input: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                pintu.Buka();
            }
            else if (pilihan == "2")
            {
                pintu.Kunci();
            }
            else if (pilihan == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Input tidak valid");
            }
        }
    }
}