using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ActivityDesigner
{
    public class MainWindowViewModel
    {

        #region properties
        public string Title { get; private set; }
        public ToolboxControl Toolbox { get; private set; }
        public WorkflowDesigner Designer { get; set; }
        public UIElement PropertyInspector { get; set; }
        #endregion

        public MainWindowViewModel()
        {
            this.Title = "Activity Designer";
            this.Toolbox = new ToolboxProvider().Toolbox;
            SetupDesigner();
        }

        private void SetupDesigner()
        {

            this.Designer = new WorkflowDesigner();

            ActivityBuilder activityBuilderType = new ActivityBuilder();
            activityBuilderType.Name = "Activity Builder";
            activityBuilderType.Implementation = new Flowchart()
            {
                DisplayName = "Default Template"
            };
            this.Designer.Load(activityBuilderType);

            PropertyInspector = this.Designer.PropertyInspectorView;

        }

    }
}
