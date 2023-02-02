namespace HttpProxy.Core;

public class ProxyHttpClient
{
    public HttpClient Client { get; private set; }

    public ProxyHttpClient(HttpClient httpClient)
    {
        Client = httpClient;
    }
}