using System;
using Microsoft.Owin.Hosting;
using WorkflowServiceManager.API;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        [Fact]
        public void PostEntrySucceeds()
        {
            using (var server = HostFactory.Create())
            {
                using (var client = HostFactory.CreateClient())
                {

                    var jsonObj = new
                    {
                        id = 1,
                        name = "test1",
                        definition = "blah blah"
                    };

                    var response = client.PostAsJsonAsync(WORKFLOW_URL, jsonObj).Result;

                    Assert.True(
                        response.IsSuccessStatusCode,
                        "Actual status code: " + response.StatusCode);
                }
            }
        }

        [Fact]
        public void PostThenGetRetunsPost()
        {
            using (var server = HostFactory.Create())
            {
                using (var client = HostFactory.CreateClient())
                {

                    var jsonObj = new
                    {
                        id = 1,
                        name = "test1",
                        definition = "blah blah"
                    };

                    var jsonOut = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                    var r = client.PostAsJsonAsync(WORKFLOW_URL, jsonObj).Result;

                    var response = client.GetAsync(WORKFLOW_URL).Result;

                    var jsonIn = JArray.Parse(response.Content.ReadAsStringAsync().Result).First.ToString();

                    Assert.Equal(jsonOut, jsonIn);

                }
            }
        }


    }
}
