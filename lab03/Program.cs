using System.Text.Json;
using System.Globalization;

public class Tweet
{
    public string Text { get; set; }
    public string UserName { get; set; }
    public string LinkToTweet { get; set; }
    public string FirstLinkUrl { get; set; }
    public string CreatedAt { get; set; }

    public DateTime CreatedAtDate =>
        DateTime.ParseExact(
            CreatedAt,
            "MMMM d, yyyy 'at' h:mmtt",
            CultureInfo.InvariantCulture
        );
    public string TweetEmbedCode { get; set; }
    public override string ToString()
    {
        return $"{Text}, {UserName}, {CreatedAt}";
    }
}

public class Program
{
    public static void Main()
    {
        string path = "favorite-tweets.jsonl";

        var tweets = File.ReadLines(path)
                 .Where(line => !string.IsNullOrWhiteSpace(line))
                 .Select(line => JsonSerializer.Deserialize<Tweet>(line))
                 .ToList();

        tweets.OrderBy(t => t.Text)
            .Take(10)
            .ToList()
            .ForEach(t => Console.WriteLine(t.Text));

        tweets.OrderBy(t => t.CreatedAtDate)
            .Take(10)
            .ToList()
            .ForEach(t => Console.WriteLine(t.CreatedAt));

        Console.WriteLine(tweets.OrderBy(t => t.CreatedAtDate).Last());

        Console.WriteLine(tweets.OrderBy(t => t.CreatedAtDate).First());

        var dict = tweets
            .GroupBy(t => t.UserName)
            .ToDictionary(t => t.Key, t => t.ToList());

        dict.Take(20)
            .ToList()
            .ForEach(kvp => Console.WriteLine($"{kvp.Key} {kvp.Value.Count}"));

        var words = tweets
            .SelectMany(t => t.Text.Split(' '))
            .ToList()
            .GroupBy(w => w)
            .ToDictionary(w => w.Key, w => w.Count())
            .OrderByDescending(w => w.Value);

        words.Take(20)
            .ToList()
            .ForEach(kvp => Console.WriteLine($"{kvp.Key} {kvp.Value}"));

        Console.WriteLine("");

        words.Where(kvp => kvp.Key.Length > 5)
            .Take(10)
            .ToList()
            .ForEach(kvp => Console.WriteLine($"{kvp.Key} {kvp.Value}"));
    }
}