namespace BuilderP;

public interface IRequestBuilder
{
    IRequestBuilder QueryMethod(string method);
    IRequestBuilder UrlPart(string part);
    IRequestBuilder Url(params string[] url);
    IRequestBuilder HttpVersion(string version);
    IRequestBuilder Header(string Name, string Value);
    IRequestBuilder Headers(params string[][] headers);
    IRequestBuilder Body(string Body);
    HttpRequest Build();
}