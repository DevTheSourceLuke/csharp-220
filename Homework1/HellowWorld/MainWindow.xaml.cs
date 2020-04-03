// CHSP 220: Assignment 01
// Luke Bushey

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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);
        }

        /// <summary>
        /// Checks whether the password and username field are filled in after either field is changed.
        /// Will enable the Submit button if both fields are filled in.
        /// </summary>
        private void requiredFieldsCheck(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uxName.Text.ToString()) || string.IsNullOrWhiteSpace(uxPassword.Text.ToString()))
            {
                uxSubmit.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = true;
            }
        }       
    }
}
