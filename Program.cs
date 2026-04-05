using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul tidak valid");
        }

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentException("Input play count tidak valid");
        }

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow pada play count");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID Video     : " + id);
        Console.WriteLine("Judul Video  : " + title);
        Console.WriteLine("Play Count   : " + playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Yosep");

            video.IncreasePlayCount(5000000);
            video.IncreasePlayCount(7000000);

            for (int i = 0; i < 1000; i++)
            {
                video.IncreasePlayCount(10000000);
            }

            video.PrintVideoDetails();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}