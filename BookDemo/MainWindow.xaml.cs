using BookDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BookDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Book> TextBooksList = new ObservableCollection<Book>();
        public static ObservableCollection<Book> CoffeeTableBooksList = new ObservableCollection<Book>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            booksGrid.ItemsSource = TextBooksList;
            coffeebooksGrid.ItemsSource = CoffeeTableBooksList;
        }

        private void btnAddTextBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newBook = new TextBook();
            var win = new AddWindow();
            win.DataContext = newBook;
            if(win.ShowDialog().GetValueOrDefault())
            {
                TextBooksList.Add(newBook);
            }
        }

        private void btnAddCoffeeBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newBook = new CoffeeTableBook();
            var win = new AddCoffeeTableBookWindow();
            win.DataContext = newBook;
            if (win.ShowDialog().GetValueOrDefault())
            {
                CoffeeTableBooksList.Add(newBook);
            }
        }
    }
}
