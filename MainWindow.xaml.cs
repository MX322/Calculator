using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _nums = string.Empty; // nums from screen
        double _firstOperand = 0;
        double _secondOperand = 0;

        string _operation = string.Empty;
        bool _isOperationPressed = false; // button operation pressed?

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Type(object sender, RoutedEventArgs e) // num buttons
        {
            if (Convert.ToDouble(Screen.Text) == 0 || _isOperationPressed) // clear screen
            {
                Screen.Text = string.Empty;
            }

            var button = (Button)sender;
            
            _nums += Convert.ToString(button.Content);
            Screen.Text = _nums;
        }

        private void Operation(object sender, RoutedEventArgs e) // operation buttons
        {
            var button = (Button)sender;

            if (Convert.ToString(button.Content) == "=")
            {
                _isOperationPressed = false;
                Screen.Text = string.Empty;

                _secondOperand = Convert.ToDouble(_nums);

                switch (_operation) 
                {
                    case "+":
                        Screen.Text = $"{_firstOperand + _secondOperand}";
                        break;

                    case "-":
                        Screen.Text = $"{_firstOperand - _secondOperand}";
                        break;

                    case "x":
                        Screen.Text = $"{_firstOperand * _secondOperand}";
                        break;

                    case "÷":
                        Screen.Text = $"{_firstOperand / _secondOperand}";
                        break;
                }
            }

            _firstOperand = Convert.ToDouble(_nums);
            _nums = string.Empty;
            _operation = Convert.ToString(button.Content);
            _isOperationPressed = true; // to clear screen

        }


        private void Command(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (Convert.ToString(button.Content))
            {
                case "C": // default window
                    Screen.Text = "0";
                    _nums = string.Empty;
                    _operation = string.Empty;
                    _isOperationPressed = false;
                    _firstOperand = 0;
                    _secondOperand = 0;
                    break;

                case "+/-": // reverse sign 
                    if (_nums[0] != '-')
                    {
                        _nums = "-";
                        _nums += Screen.Text;
                        Screen.Text = _nums;
                    }

                    else
                    {
                        _nums = _nums.Split('-')[1];
                        Screen.Text = _nums;
                    }
                   

                    break;

                case "%": // percent 
                    _nums = (Convert.ToDouble(Screen.Text) / 100).ToString();
                    Screen.Text = $"{_nums}";
                    break;

            }
        }

    }
    
}
