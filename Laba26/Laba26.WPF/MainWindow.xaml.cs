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
using Laba26.WPF.Models;
using Laba26.WPF.ViewModels;

namespace Laba26.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        private int _count;

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            _count = 0;
            DataContext = _mainViewModel;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DeleteLastSymbol(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_mainViewModel.InputText))
            {
                return;
            }

            _mainViewModel.InputText = _mainViewModel.InputText[0..^1];
        }

        private void CalculateResult(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_mainViewModel.Text) && !string.IsNullOrEmpty(_mainViewModel.InputText)
                    && _mainViewModel.Count == 0)
                {
                    char ch = _mainViewModel.Text.Trim().LastOrDefault();

                    if (!_mainViewModel.Text.Contains(','))
                    {
                        float firstDigit = Convert.ToSingle(_mainViewModel.Text.Trim()[..^1]);
                        float secondDigit = Convert.ToSingle(new string(_mainViewModel.InputText.Trim()
                            .TakeWhile(c => char.IsDigit(c)).ToArray()));

                        float result = ch switch
                        {
                            '+' => MathematicalOperation.Sum(firstDigit, secondDigit),
                            '-' => MathematicalOperation.Subtraction(firstDigit, secondDigit),
                            '/' => MathematicalOperation.Divide(firstDigit, secondDigit),
                            '*' => MathematicalOperation.Multiply(firstDigit, secondDigit),
                            _ => default
                        };

                        _mainViewModel.Text = _mainViewModel.Text + secondDigit.ToString();
                        _mainViewModel.InputText = Math.Round(result, 5).ToString();
                        _mainViewModel.Count++;
                    }
                    else
                    {
                        if (_mainViewModel.Text.Trim()[..^1] == ",")
                        {
                            _mainViewModel.InputText = "Вы ввели не корректное число";
                            _mainViewModel.Text = "";
                            return;
                        }

                        float firstDigit = Convert.ToSingle(_mainViewModel.Text.Trim()[..^1]);
                        float secondDigit = Convert.ToSingle(_mainViewModel.InputText.Trim());

                        float result = ch switch
                        {
                            '+' => MathematicalOperation.Sum(firstDigit, secondDigit),
                            '-' => MathematicalOperation.Subtraction(firstDigit, secondDigit),
                            '/' => MathematicalOperation.Divide(firstDigit, secondDigit),
                            '*' => MathematicalOperation.Multiply(firstDigit, secondDigit),
                            _ => default
                        };

                        _mainViewModel.Text = _mainViewModel.Text + secondDigit.ToString();
                        _mainViewModel.InputText = Math.Round(result, 5).ToString();
                        _mainViewModel.Count++;
                    }
                }
            }
            catch (DivideByZeroException)
            {
                _mainViewModel.Text = "";
                _mainViewModel.InputText = "Нельзя делить на ноль";
            }
        }

        private void ClearAllFields(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Text = "";
            _mainViewModel.InputText = "";
            _mainViewModel.Count = 0;
        }
    }
}