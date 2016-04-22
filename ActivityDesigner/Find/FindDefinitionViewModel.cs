using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ActivityDesigner.Find
{
    public class FindDefinitionViewModel
    {

        private const string WORKFLOW_URL = "/api/workflow";

        public List<WorkflowDefinition> Items { get; private set; }
        public WorkflowDefinition SelectedDefinition { get; set; }

        public FindDefinitionViewModel()
        {
            Items = new List<WorkflowDefinition>();
            LoadItems();
        }

        private void LoadItems()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8675");
                
                var response = client.GetAsync(WORKFLOW_URL).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                Items = JsonConvert.DeserializeObject<List<WorkflowDefinition>>(json);

            }
        }
    }
}