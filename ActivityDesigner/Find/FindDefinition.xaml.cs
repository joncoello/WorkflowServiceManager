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

namespace ActivityDesigner.Find
{
    /// <summary>
    /// Interaction logic for FindDefinition.xaml
    /// </summary>
    public partial class FindDefinition : Window
    {
        private readonly FindDefinitionViewModel VM;

        public FindDefinition(FindDefinitionViewModel vm)
        {
            InitializeComponent();
            this.VM = vm;
            this.DataContext = this.VM;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
