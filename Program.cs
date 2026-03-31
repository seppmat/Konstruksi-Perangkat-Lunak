using System;

class Penjumlahan
{
    public T JumlahTigaAngka<T>(T a, T b, T c)
    {
        dynamic x = a;
        dynamic y = b;
        dynamic z = c;

        return (T)(x + y + z);
    }
}

class SimpleDataBase<T>
{
    private List<T> storedData;
    private List<DateTime> inputDates;
   
    public SimpleDataBase()
    {
        storedData = new List<T>();
        inputDates = new List<DateTime>();
    }

    public void AddNewData(T data)
    {
        storedData.Add(data);
        inputDates.Add(DateTime.Now);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine(
                "Data ke-" + (i + 1) + ": " + storedData[i] +
                " | Waktu input: " + inputDates[i]
            );
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Penjumlahan obj = new Penjumlahan();

        // NIM: 103082400017 

        int a = 10;
        int b = 30;
        int c = 82;

        int hasil = obj.JumlahTigaAngka<int>(a, b, c);

        Console.WriteLine("Hasil penjumlahan: " + hasil);

        SimpleDataBase<int> db = new SimpleDataBase<int>();

        db.AddNewData(a);
        db.AddNewData(b);
        db.AddNewData(c);

        db.PrintAllData();
    }
}