namespace BuilderP;

public class HttpRequest
{
    public string Query;

    public HttpRequest(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Ну не может быть пустой запрос.");
        Query = query.Trim();
    }
    public override string ToString() => Query;
}