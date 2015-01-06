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
    /// Interaction logic for PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        public PatientsWindow()
        {
            InitializeComponent();
            this.Loaded += PatientsWindow_Loaded;

        }

        private void PatientsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PatientViewModel).LoadData();
        }
    }
}
