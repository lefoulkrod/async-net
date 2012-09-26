using System;
using System.Net;

namespace node.cs
{
    internal class AsynchHttpServer
    {
        private readonly HttpListener _listener;
        private OnRequestCallback _onRequestCallback;

        public AsynchHttpServer()
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
            _onRequestCallback(context.Request, context.Response);
            
        }

        public void OnRequest(OnRequestCallback callback)
        {
            _onRequestCallback = callback;
        }
    }
}