using System;
using Microsoft.Owin.Hosting;
using WorkflowServiceManager.API;
using Xunit;

namespace WorkflowServiceManager.AcceptanceTests
{

    public class WorkflowDefinitionTests
    {

        private const string WORKFLOW_URL = "/api/workflow";

        [Fact]
        public void GetReturnsResponseWithCorrectStatusCode()
        {
            using (var server = HostFactory.Create())
            {
                using (var client = HostFactory.CreateClient())
                {

                    var response = client.GetAsync(WORKFLOW_URL).Result;

                    Assert.True(
                        response.IsSuccessStatusCode,
                        "Actual status code: " + response.StatusCode);

                }

            }
        }

    }
}
