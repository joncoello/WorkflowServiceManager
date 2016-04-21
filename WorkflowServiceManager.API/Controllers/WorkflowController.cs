using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WorkflowServiceManager.API.Controllers
{
    public class WorkflowController : ApiController
    {
        private static readonly List<WorkflowDefinition> _definitions = new List<WorkflowDefinition>();

        public IEnumerable<WorkflowDefinition> Get() {
            return _definitions;
        }

        public void Post(WorkflowDefinition definition) {
            _definitions.Add(definition);
        }
    }
}
