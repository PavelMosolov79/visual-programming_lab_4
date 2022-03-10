using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using lab_4.Models;

namespace lab_4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string _text = "";
        RomanNumberExtend n1;
        bool _error;
        char operand;

        public void Clear()
        {
            MainText = "";
            n1 = null;
        }

        private bool Error
        {
            get => _error;
            set 
            {
                if (value) 
                    SetInvalidExpression();
                else if (!value&&_error) 
                    MainText = "";
                _error = value;
            }
        }

        public string MainText
        {
            get
            {
                return _text;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _text, value);
            }
        }

        public void WriteChar(string x)
        {
            Error = false;
            MainText += x;
        }

        public void CalcAnswer()
        {
            var x = new RomanNumberExtend(MainText);
            try
            {
                if (operand == '+')
                    MainText = (x + n1).ToString();
                else if (operand == '-')
                    MainText = (n1 - x).ToString();
                else if (operand == '/')
                    MainText = (n1 / x).ToString();
                else if (operand == '*')
                    MainText = (n1 * x).ToString();
            } catch(RomanNumberException)
            {
                Error = true;
            }

        }

        private void SetInvalidExpression() => MainText = "Œÿ»¡ ¿";

        public void DoOperator(char operand) {
            try
            {
                n1 = new RomanNumberExtend(MainText);
                this.operand = operand;
            } 
            catch(RomanNumberException)
            {
                Error = true;
            }
            if(!Error) 
                MainText = "";
        }
    }
}
