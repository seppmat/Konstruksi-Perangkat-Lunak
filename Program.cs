using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        this.playCount += count;
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
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Yosep");
        video.IncreasePlayCount(100);
        video.IncreasePlayCount(250);
        video.PrintVideoDetails();
    }
}