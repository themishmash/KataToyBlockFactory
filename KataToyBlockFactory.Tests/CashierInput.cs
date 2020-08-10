using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory.Tests
{
    public class CashierInput : IInputOutput
    {
        private readonly int _quantity;
        private readonly int _quantity2;
        private readonly int _quantity3;
        private readonly int _quantity4;
        private readonly int _quantity5;
        private readonly int _quantity6;
        private readonly int _quantity7;
        private readonly int _quantity8;
        private readonly int _quantity9;
        public List<int> _amounts = new List<int>();
        private int _counter;


        public CashierInput(int quantity, int quantity2, int quantity3, int quantity4, int quantity5, int quantity6, 
        int quantity7, int quantity8, int quantity9)
        {
            _quantity = quantity;
            _quantity2 = quantity2;
            _quantity3 = quantity3;
            _quantity4 = quantity4;
            _quantity5 = quantity5;
            _quantity6 = quantity6;
            _quantity7 = quantity7;
            _quantity8 = quantity8;
            _quantity9 = quantity9;
        }

        public CashierInput(List<int> amounts)
        {
            _amounts = amounts;
        }


        public string AskQuestion(string question)
        {
            return "";
        }

        public int AskBlockQuantity(string question)
        {
            _counter++;
            return _counter switch
            {
                1 => _quantity,
                2 => _quantity2,
                3 => _quantity3,
                4 => _quantity4,
                5 => _quantity5,
                6 => _quantity6,
                7 => _quantity7,
                8 => _quantity8,
                9 => _quantity9,
                _ => 0
            };
        }

        public int AskBlockQuantity2(string question)
        {
            _counter++;
            return _amounts.FirstOrDefault();
        }

        public DateTime AskDate(string question)
        {
           return DateTime.Today.AddDays(7);
        }

        public void output(string message)
        {
        }
    }
}