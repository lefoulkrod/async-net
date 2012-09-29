namespace asyncnet
{
    public interface IAsyncHttpResponse
    {
        void OnWrite(string response, OnWriteCallback callback);
        void End();
    }
}