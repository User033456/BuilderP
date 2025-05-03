using System.Text;

namespace BuilderP;

public class HttpRequestBuilder : IRequestBuilder
{
    private string _Method;
    private string _HttpV;
    private string _Body;
    private List<string> _UrlParts = new List<string>();
    private List<string[]> _Headers = new List<string[]>();
    public IRequestBuilder QueryMethod(string method)
    {
        if (!string.IsNullOrWhiteSpace(method))
        {
            _Method = method;
        }
        return this;
    }

    public IRequestBuilder UrlPart(string part)
    {
        if (!string.IsNullOrWhiteSpace(part))
        {
            _UrlParts.Add(part);
        }
        return this;
    }

    public IRequestBuilder Url(params string[] parts)
    {
        if (parts != null || parts.Length != 0)
        {
            _UrlParts.AddRange(parts);
        }
        return this;
    }
    public IRequestBuilder Header(string header, string value)
    {
        if (!string.IsNullOrWhiteSpace(header) && !string.IsNullOrWhiteSpace(value))
        {
            _Headers.Add(new string[] { header, value });
        }
        return this;
    }

    public IRequestBuilder Headers(params string[][] headers)
    {
        if (headers != null || headers.Length != 0)
        {
            _Headers.AddRange(headers);
        }
        return this;
    }
    public IRequestBuilder HttpVersion(string version)
    {
        if (!string.IsNullOrWhiteSpace(version))
        {
            _HttpV = version;
        }
        return this;
    }

    public IRequestBuilder Body(string body)
    {
        if (!string.IsNullOrWhiteSpace(body))
        {
            _Body = body;
        }
        return this;
    }

    public HttpRequest Build()
    {
        var query = new StringBuilder();
        if (!string.IsNullOrEmpty(_Method))
        {
            query.Append(_Method + " ");
        }

        if (_UrlParts.Count > 0)
        {
            for (int i = 0; i < _UrlParts.Count; i++)
            {
                query.Append('/');
                query.Append(_UrlParts[i]);
            }
            query.Append(' ');
        }
        if (!string.IsNullOrEmpty(_HttpV))
        {
            query.Append("HTTP/" + _HttpV + "\n");
        }

        if (_Headers.Count > 0)
        {
            foreach (var Header in _Headers)
            {
                query.Append(Header[0] + ": " + Header[1] + "\n");
            }
            query.Append("" + "\n");
        }
        if (!string.IsNullOrWhiteSpace(_Body))
        {
            query.Append(_Body);
        }
        _UrlParts = new List<string>();
        _Headers = new List<string[]>();
        return new HttpRequest(query.ToString());
    }
}