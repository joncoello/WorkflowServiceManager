using Microsoft.Win32;
using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ActivityDesigner
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region properties

        public string Title { get; private set; }
        public ToolboxControl Toolbox { get; private set; }
        private WorkflowDesigner _designer;
        public WorkflowDesigner Designer { get { return _designer; } set { _designer = value; FireProeprtyChanged("Designer"); } }
        private UIElement _propertyInspector;
        public UIElement PropertyInspector { get { return _propertyInspector; } set { _propertyInspector = value; FireProeprtyChanged("PropertyInspector"); } }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void FireProeprtyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModel()
        {
            this.Title = "Activity Designer";
            this.Toolbox = new ToolboxProvider().Toolbox;
            SetupDesigner(true);
        }

        private void SetupDesigner(bool addDefaultWorkflow)
        {

            this.Designer = new WorkflowDesigner();

            if (addDefaultWorkflow)
            {
                ActivityBuilder activityBuilderType = new ActivityBuilder();
                activityBuilderType.Name = "Activity Builder";
                activityBuilderType.Implementation = new Flowchart()
                {
                    DisplayName = "Default Template"
                };
                this.Designer.Load(activityBuilderType);
            }

            PropertyInspector = this.Designer.PropertyInspectorView;

        }

        internal void SaveClicked()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Xaml File | *.xaml";
            sfd.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Activities");
            sfd.ShowDialog();
            Designer.Save(sfd.FileName);
            MessageBox.Show("Done");
        }

        public void LoadClicked()
        {
            SetupDesigner(false);
            var ofd = new OpenFileDialog();
            ofd.Filter = "Xaml File | *.xaml";
            ofd.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Activities");
            var result = ofd.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Designer.Load(ofd.FileName);
            }
            PropertyInspector = Designer.PropertyInspectorView;
            
        }
    }
}
