using RAKHospitalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RAKHospitalAdmin.Views
{
    /// <summary>
    /// Interaction logic for DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        public DoctorsWindow()
        {
            InitializeComponent();
            this.Loaded += DoctorsWindow_Loaded;
        }

        private void DoctorsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DoctorsViewModel).LoadData();
        }
    }
}
