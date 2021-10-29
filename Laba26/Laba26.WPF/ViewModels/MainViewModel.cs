using Laba26.WPF.Commands;
using System.Linq;
using System.Windows.Input;
using Laba26.WPF.Models;
using System;

namespace Laba26.WPF.ViewModels
{
    public class MainViewModel : ViewModeBase
    {
        private string _inputText;

        public string InputText
        {
            get => _inputText;
            set
            {
                if (value.ToList().FindAll(ch => ch == ',').Count >= 2)
                {
                    return;
                }

                if (value.StartsWith("-") && (value.Contains("+") || value.Contains("/")
                    || value.Contains("*")))
                {
                    Text = value;
                    _inputText = "";
                    Count = 0;
                    OnPropertyChanged(nameof(InputText));
                    return;
                }

                if ((value.Contains("+") || value.Contains("-") || value.Contains("/")
                    || value.Contains("*")) && !value.StartsWith("-"))
                {
                    Text = value;
                    _inputText = "";
                    Count = 0;
                    OnPropertyChanged(nameof(InputText));
                    return;
                }

                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public ICommand AddZero { get; }
        public ICommand AddOneNumber { get; }
        public ICommand AddTwo { get; }
        public ICommand AddThree { get; }
        public ICommand AddFour { get; }
        public ICommand AddFive { get; }
        public ICommand AddSix { get; }
        public ICommand AddSeven { get; }
        public ICommand AddEight { get; }
        public ICommand AddNine { get; }

        public ICommand AddPlus { get; }
        public ICommand AddMinus { get; }
        public ICommand AddMultiply { get; }
        public ICommand AddDivide { get; }
        public ICommand AddComma { get; }

        public MainViewModel()
        {
            Text = "";
            InputText = "";
            Count = 0;

            AddZero = new AddEntityAsyncCommand<int>(this, 0);
            AddOneNumber = new AddEntityAsyncCommand<int>(this, 1);
            AddTwo = new AddEntityAsyncCommand<int>(this, 2);
            AddThree = new AddEntityAsyncCommand<int>(this, 3);
            AddFour = new AddEntityAsyncCommand<int>(this, 4);
            AddFive = new AddEntityAsyncCommand<int>(this, 5);
            AddSix = new AddEntityAsyncCommand<int>(this, 6);
            AddSeven = new AddEntityAsyncCommand<int>(this, 7);
            AddEight = new AddEntityAsyncCommand<int>(this, 8);
            AddNine = new AddEntityAsyncCommand<int>(this, 9);

            AddPlus = new AddEntityAsyncCommand<string>(this, "+");
            AddMinus = new AddEntityAsyncCommand<string>(this, "-");
            AddDivide = new AddEntityAsyncCommand<string>(this, "/");
            AddMultiply = new AddEntityAsyncCommand<string>(this, "*");
            AddComma = new AddEntityAsyncCommand<string>(this, ",");
        }
    }
}