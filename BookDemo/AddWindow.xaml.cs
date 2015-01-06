﻿using BookDemo.Models;
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

namespace BookDemo
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void btnOk(object sender, System.Windows.RoutedEventArgs e)
        {
            var book = this.DataContext as TextBook;
            if (string.IsNullOrEmpty(book.ISBN))
            {
                MessageBox.Show("Please enter ISBN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(book.Title))
            {
                MessageBox.Show("Please enter Title", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(book.Author))
            {
                MessageBox.Show("Please enter Author", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (book.Price < 20 || book.Price > 80)
            {
                MessageBox.Show("Price should be between 20 and 80", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
        }

        private void btnCancel(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}