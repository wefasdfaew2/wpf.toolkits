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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WTFToolkits
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public SimpleViewModel ViewModel { get; set; }

        public UserControl1()
        {
            this.ViewModel = new SimpleViewModel();
            this.ViewModel.OnSaveRequest += OnSaveModel;
            this.DataContext = this.ViewModel;

            InitializeComponent();
        }

        public void OnSaveModel()
        {
            MessageBox.Show("saved");
            // this.ViewModel.on
        }
    }
}
