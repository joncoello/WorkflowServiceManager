using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using WorkflowServiceManager.API;

namespace WorkflowServiceManager.AcceptanceTests
{
    internal class HostFactory
    {
        private const string BASE_ADDRESS = "http://localhost:8675";

        internal static IDisposable Create()
        {
            return WebApp.Start<Startup>(BASE_ADDRESS);
        }

        internal static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            
            return client;
        }
    }
}