using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivityDesigner.Save
{
    internal class SaveDefinitionViewModel
    {

        private const string WORKFLOW_URL = "/api/workflow";

        public int DefinitionID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        
        public SaveDefinitionViewModel(string definition)
        {
            this.Definition = definition;
        }

        internal void OKClicked()
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8675");
                
                var response = client.PostAsJsonAsync(WORKFLOW_URL, this).Result;
                response.EnsureSuccessStatusCode();
                
            }

        }

        internal void CancelClicked()
        {
            
        }

        
    }
}