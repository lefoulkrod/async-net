using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace node.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            new AsynchHttpServer().OnRequest((req, res) =>
                                                 {
                                                     var responseString = "hello worlds!" + req.QueryString["req"];
                                                     byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                                     res.ContentLength64 = buffer.Length;
                                                     res.OutputStream.BeginWrite(buffer, 0, buffer.Length, ar => ((HttpListenerResponse)ar.AsyncState).OutputStream.Close(), res);
                                                 });
            Console.ReadLine();
        }
    }
}
