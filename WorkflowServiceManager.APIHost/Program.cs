using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowServiceManager.API;

namespace WorkflowServiceManager.APIHost
{
    class Program
    {

        private const string BASE_ADDRESS = "http://localhost:8675";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(BASE_ADDRESS))
            {
                Console.WriteLine("press any key to close");
                Console.ReadKey();
            }
        }
    }
}
