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
    }
}