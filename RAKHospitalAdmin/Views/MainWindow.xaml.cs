using RAKHospitalAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RAKHospitalAdmin
{
    /// <summary>
    /// This is a window that shows up on app launch.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Set DataDirectory path which is used by LocalDb connectionstring to get path to the Database file.
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));

            this.DataContext = new MainViewModel();
        }

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
