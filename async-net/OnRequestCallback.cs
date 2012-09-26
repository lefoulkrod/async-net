using System.Net;

namespace node.cs
{
    internal delegate void OnRequestCallback(HttpListenerRequest req, HttpListenerResponse res);
}