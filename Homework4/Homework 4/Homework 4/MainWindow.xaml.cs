// Author: Luke Bushey
// Title: Homework 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Homework_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have entered a valid zip code: " + uxZipCode.Text);
        }

        // Event responsible for determining if the user is entering a valid zip code, per character entered
        private void uxZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsValidInput(e.Text))
            {
                e.Handled = true;
            }
        }

        // Checks if valid input is coming into the text box.
        private bool IsValidInput(string text)
        {
            var _validInputsRegex = @"((^\d{1,5}(-\d{0,4})?$)|((^[ABCEGHJKLMNPRSTVXY](\d?){1})|(^[ABCEGHJKLMNPRSTVXY]\d[A-Z]\d?)|(^[ABCEGHJKLMNPRSTVXY]\d([A-Z]\d[A-Z]\d?)))$)";

            if (!Regex.Match((uxZipCode.Text + text), _validInputsRegex).Success)
            {
                return false;
            }

            return true;
        }

        // Responsible for validating the full input. Sample solution of using the below regex taken from:
        // https://stackoverflow.com/questions/14942602/c-validation-for-us-or-canadian-zip-code
        private static bool IsValidZipCode(string zipCode)
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                return false;
            }
            return true;
        }

        // Checks if the uxSubmit button can be enabled if a valid zip code is present
        private void uxSubmit_Enabled(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = IsValidZipCode(uxZipCode.Text);
        }
    }
}
