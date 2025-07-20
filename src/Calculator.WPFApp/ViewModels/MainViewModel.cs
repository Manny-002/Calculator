using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator.WPFApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualCommand { get; }
        public ICommand ClearCommand { get; }

        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber;

        private string display = "";
        public string Display
        {
            get => display;
            set
            {
                if (display != value)
                {
                    display = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            NumberCommand = new RelayCommand(param => AppendNumber(param?.ToString()));
            OperatorCommand = new RelayCommand(param => SetOperator(param?.ToString()));
            EqualCommand = new RelayCommand(_ => Calculate());
            ClearCommand = new RelayCommand(_ => Clear());
        }

        private void AppendNumber(string? number)
        {
            if (number != null)
            {
                currentInput += number;
                Display = currentInput;
            }
        }

        private void SetOperator(string? op)
        {
            if (!string.IsNullOrEmpty(currentInput) && double.TryParse(currentInput, out firstNumber))
            {
                currentInput = "";
                currentOperator = op ?? "";
            }
        }

        private void Calculate()
        {
            if (!string.IsNullOrEmpty(currentInput) && double.TryParse(currentInput, out double secondNumber))
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

        private void Clear()
        {
            currentInput = "";
            currentOperator = "";
            firstNumber = 0;
            Display = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
