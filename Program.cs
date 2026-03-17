class Program
{
    static void Main(string[] args)
    {
        KodeBuah kb = new KodeBuah();

        Console.Write("Masukkan nama buah: ");
        string input = Console.ReadLine();

        string kode = kb.getKodeBuah(input);
        Console.WriteLine("Kode buah: " + kode);

        Console.WriteLine();



        PosisiKarakterGame karakter = new PosisiKarakterGame();

        karakter.UbahState(PosisiKarakterGame.State.Terbang);  
        karakter.UbahState(PosisiKarakterGame.State.Jongkok);  
        karakter.UbahState(PosisiKarakterGame.State.Tengkurap);
        karakter.UbahState(PosisiKarakterGame.State.Berdiri);

        Console.ReadLine();
    }
}