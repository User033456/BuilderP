namespace BuilderP;

public class HttpRequestDirector
{
    private readonly IRequestBuilder _builder;

    public HttpRequestDirector(IRequestBuilder builder)
    {
        _builder = builder;
    }
    public HttpRequest SimpleQuery(string method, string httpv, params string[] url)
    {
        return _builder.QueryMethod(method).Url(url).HttpVersion(httpv).Build();
    }
    public HttpRequest FullQuery(string method, string httpv, string body, string[] url, string[][] headers)
    {
        return _builder.QueryMethod(method).Url(url).HttpVersion(httpv)
            .Headers(headers)
            .Body(body)
            .Build();
    }
}