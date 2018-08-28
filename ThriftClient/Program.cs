using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var transport = new TSocket("localhost", 9090);
            var protocol = new TBinaryProtocol(transport);
            var client = new MultiplicationService.Client(protocol);

            transport.Open();

            var mult = client.multiply(2, 4);
            Console.WriteLine("mult: {0}", mult);
        }
    }
}
