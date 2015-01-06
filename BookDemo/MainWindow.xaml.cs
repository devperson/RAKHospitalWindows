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
    /// This is a window that shows up on app launch.
    /// </summary>
    public partial class MainWindow : Window
    {
        //TextBook and CoffeeTableBooks lists 
        public static ObservableCollection<Book> TextBooksList = new ObservableCollection<Book>();
        public static ObservableCollection<Book> CoffeeTableBooksList = new ObservableCollection<Book>();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        //Load event fires when current window is showed
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            booksGrid.ItemsSource = TextBooksList;
            coffeebooksGrid.ItemsSource = CoffeeTableBooksList;
        }
        
        /// <summary>
        /// //Add textbook event
        /// </summary>
        private void btnAddTextBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Bind TextBook object to Window.
            //So when we type to Name TextBox control it will be reflected to TextBook.Name property
            var newBook = new TextBook();
            var win = new AddWindow();
            win.DataContext = newBook;
            if(win.ShowDialog().GetValueOrDefault())// if window result ok add populated textbook to list
            {
                TextBooksList.Add(newBook);
            }
        }

        /// <summary>
        /// Add CoffeeTextBook event
        /// </summary>        
        private void btnAddCoffeeBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Bind TextBook object to Window.
            //So when we type to Name TextBox control it will be reflected to CoffeeTableBook.Name property
            var newBook = new CoffeeTableBook();
            var win = new AddCoffeeTableBookWindow();
            win.DataContext = newBook;
            if (win.ShowDialog().GetValueOrDefault())// if window result ok add populated coffeeTablebook to list
            {
                CoffeeTableBooksList.Add(newBook);
            }
        }
    }
}
