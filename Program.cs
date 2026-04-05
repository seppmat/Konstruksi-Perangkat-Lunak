using System;
using System.Collections.Generic;

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

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + username);
        int i = 1;
        foreach (var video in uploadedVideos)
        {
            Console.WriteLine("Video " + i + " judul: " + video.GetTitle());
            i++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user = new SayaTubeUser("Yosep");

        SayaTubeVideo v1 = new SayaTubeVideo("Review Film Interstellar oleh Yosep");
        SayaTubeVideo v2 = new SayaTubeVideo("Review Film Inception oleh Yosep");
        SayaTubeVideo v3 = new SayaTubeVideo("Review Film The Dark Knight oleh Yosep");
        SayaTubeVideo v4 = new SayaTubeVideo("Review Film Parasite oleh Yosep");
        SayaTubeVideo v5 = new SayaTubeVideo("Review Film Avengers Endgame oleh Yosep");
        SayaTubeVideo v6 = new SayaTubeVideo("Review Film Joker oleh Yosep");
        SayaTubeVideo v7 = new SayaTubeVideo("Review Film Whiplash oleh Yosep");
        SayaTubeVideo v8 = new SayaTubeVideo("Review Film Fight Club oleh Yosep");
        SayaTubeVideo v9 = new SayaTubeVideo("Review Film Forrest Gump oleh Yosep");
        SayaTubeVideo v10 = new SayaTubeVideo("Review Film The Matrix oleh Yosep");

        user.AddVideo(v1);
        user.AddVideo(v2);
        user.AddVideo(v3);
        user.AddVideo(v4);
        user.AddVideo(v5);
        user.AddVideo(v6);
        user.AddVideo(v7);
        user.AddVideo(v8);
        user.AddVideo(v9);
        user.AddVideo(v10);

        v1.IncreasePlayCount(100);
        v2.IncreasePlayCount(200);
        v3.IncreasePlayCount(300);

        user.PrintAllVideoPlaycount();
        Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());
    }
}