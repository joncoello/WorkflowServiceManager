using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ActivityDesigner.Save
{
    /// <summary>
    /// Interaction logic for SaveDefinition.xaml
    /// </summary>
    public partial class SaveDefinition : Window
    {

        private readonly SaveDefinitionViewModel VM;

        public SaveDefinition()
        {
            InitializeComponent();
        }

        public SaveDefinition(string definition)
        {
            InitializeComponent();
            this.VM = new SaveDefinitionViewModel(definition);
            this.DataContext = this.VM;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.VM.OKClicked();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.VM.CancelClicked();
        }
    }
}
