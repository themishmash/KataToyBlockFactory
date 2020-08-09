using System;

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


        public string AskQuestion(string question)
        {
            return "";
        }

        public int AskBlockQuantity(string question)
        {
            _counter++;
            switch (_counter)
            {
                case 1:
                    return _quantity;
                case 2:
                    return _quantity2;
                case 3:
                    return _quantity3;
                case 4:
                    return _quantity4;
                case 5:
                    return _quantity5;
                case 6:
                    return _quantity6;
                case 7:
                    return _quantity7;
                case 8:
                    return _quantity8;
                case 9:
                    return _quantity9;
                default:
                    return 0;
            }
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