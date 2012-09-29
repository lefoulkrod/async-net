using System.Net;
using System.Text;

namespace asyncnet
{
    internal class AsyncHttpResponse : IAsyncHttpResponse
    {
        private HttpListenerResponse _respone;
        private OnWriteCallback _callback;

        internal AsyncHttpResponse(HttpListenerResponse respone)
        {
            _respone = respone;
        }

        public void OnWrite(string response, OnWriteCallback callback)
        {
            _callback = callback;
            byte[] buffer = Encoding.UTF8.GetBytes(response);
            _respone.ContentLength64 = buffer.Length;
            _respone.OutputStream.BeginWrite(buffer, 0, buffer.Length, 
                ar =>
                    {
                        var httpRes = ar.AsyncState as HttpListenerResponse;
                        httpRes.OutputStream.EndWrite(ar);
                        _callback(this);
                    }, 
                _respone);
        }

        public void End()
        {
            _respone.OutputStream.Dispose();
        }
    }
}
