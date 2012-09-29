using System.Net;

namespace asyncnet
{
    public delegate void OnRequestCallback(HttpListenerRequest req, IAsyncHttpResponse res);
}