namespace BuilderP;

class Program
{
    static void Main(string[] args)
    {
        var builder = new HttpRequestBuilder();
        var Director = new HttpRequestDirector(builder);
        string[][] Headers = new []
        {
            new string[] {"Host", "example.com"}, 
            new string[] {"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"},
            new string[] {"Content-Type", "application/json"},
            new string[] {"Content-Length","38"},
            new string[] {"Accept","application/json"}
        };
        string[] Urls = new string[] {"api","users"};
        var SimpleQuery = Director.SimpleQuery("POST", "1.1", "api", "users");
        var FullQuery = Director.FullQuery("POST", "1.1", "{\"username\":\"ivan\",\"email\":\"ivan@mail.ru\"}",Urls, Headers);
        Console.WriteLine(SimpleQuery);
        Console.WriteLine();
        Console.WriteLine(FullQuery);
    }
}