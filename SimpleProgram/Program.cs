using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;
using test;

namespace SimpleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new ThriftServiceHandler();
            var processor = new MultiplicationService.Processor(handler);

            TServerTransport transport = new TServerSocket(9090);
            TServer server = new TThreadPoolServer(processor, transport);

            Console.WriteLine("going to serve...");

            server.Serve();
            
        }

    }

    public class ThriftServiceHandler : MultiplicationService.Iface
    {
        public int multiply(int n1, int n2)
        {
            return n1 * n2;
        }
    }
}
