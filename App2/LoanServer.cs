using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Fakes;

namespace App2
{
    public class LoanServer
    {
        public static void Main(string[] args)
        {
            HttpServer httpServer = new HttpServer(8080);
            httpServer.SetHandler(new LoanHandler());
            httpServer.Start();
            httpServer.Join();
        }
    }
}
