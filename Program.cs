using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 200)
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
        if (count < 0 || count > 25000000)
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

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 100)
        {
            throw new ArgumentException("Username tidak valid");
        }

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
        if (video == null)
        {
            throw new ArgumentException("Video tidak boleh null");
        }

        if (video.GetPlayCount() >= int.MaxValue)
        {
            throw new ArgumentException("Play count melebihi batas");
        }

        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + username);
        int max = Math.Min(8, uploadedVideos.Count);
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].GetTitle());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Yosep");

            List<SayaTubeVideo> videos = new List<SayaTubeVideo>()
            {
                new SayaTubeVideo("Review Film Interstellar oleh Yosep"),
                new SayaTubeVideo("Review Film Inception oleh Yosep"),
                new SayaTubeVideo("Review Film The Dark Knight oleh Yosep"),
                new SayaTubeVideo("Review Film Parasite oleh Yosep"),
                new SayaTubeVideo("Review Film Avengers Endgame oleh Yosep"),
                new SayaTubeVideo("Review Film Joker oleh Yosep"),
                new SayaTubeVideo("Review Film Whiplash oleh Yosep"),
                new SayaTubeVideo("Review Film Fight Club oleh Yosep"),
                new SayaTubeVideo("Review Film Forrest Gump oleh Yosep"),
                new SayaTubeVideo("Review Film The Matrix oleh Yosep")
            };

            foreach (var v in videos)
            {
                user.AddVideo(v);
            }

            foreach (var v in videos)
            {
                for (int i = 0; i < 300; i++)
                {
                    v.IncreasePlayCount(10000000);
                }
            }

            user.PrintAllVideoPlaycount();
            Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}