using System;
using System.Windows.Input;

namespace Calculator.WPFApp.ViewModels
{
    public class MainViewModel
    {
        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualCommand { get; }

        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber;

        public string Display { get; set; } = "";

        public MainViewModel()
        {
            NumberCommand = new RelayCommand(param => AppendNumber(param?.ToString()));
            OperatorCommand = new RelayCommand(param => SetOperator(param?.ToString()));
            EqualCommand = new RelayCommand(_ => Calculate());
        }

        private void AppendNumber(string number)
        {
            currentInput += number;
            Display = currentInput;
        }

        private void SetOperator(string op)
        {
            if (double.TryParse(currentInput, out firstNumber))
            {
                currentInput = "";
                currentOperator = op;
            }
        }

        private void Calculate()
        {
            if (double.TryParse(currentInput, out double secondNumber))
            {
                double result = currentOperator switch
                {
                    "+" => firstNumber + secondNumber,
                    "-" => firstNumber - secondNumber,
                    "*" => firstNumber * secondNumber,
                    "/" => secondNumber != 0 ? firstNumber / secondNumber : 0,
                    _ => 0
                };

                Display = result.ToString();
                currentInput = result.ToString();
            }
        }
    }
}
