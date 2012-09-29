using System;
using System.Net;

namespace asyncnet
{
    public class AsyncHttpServer
    {
        private readonly HttpListener _listener;
        private OnRequestCallback _onRequestCallback;

        public AsyncHttpServer()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://+:80/");
            _listener.Start();
            _listener.BeginGetContext(GetContext, null);
        }

        private void GetContext(IAsyncResult result)
        {
            _listener.BeginGetContext(GetContext, null);
            var context = _listener.EndGetContext(result);
            _onRequestCallback(context.Request, new AsyncHttpResponse( context.Response));
            
        }

        public void OnRequest(OnRequestCallback callback)
        {
            _onRequestCallback = callback;
        }
    }
}