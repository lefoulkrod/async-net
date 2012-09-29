using System;
using System.Text;

namespace asyncnet.app
{
    class Program
    {
        static void Main(string[] args)
        {
            new AsyncHttpServer().OnRequest((req, res) =>
                                                 {
                                                     var responseString = "hello worlds!" + req.QueryString["req"];
                                                     byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                                     res.OnWrite(responseString, response => response.End());
                                                 });
            Console.ReadLine();
        }
    }
}
