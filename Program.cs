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

        Console.WriteLine("Simulasi pintu:");
        pintu.Buka();
        pintu.Kunci();

        Console.ReadLine();
    }
}