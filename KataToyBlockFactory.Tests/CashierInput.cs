using System;
using System.Collections.Generic;
using System.Linq;
using KataToyBlockFactory;

namespace ToyBlockFactory.Tests
{
    public class CashierInput : IInputOutput
    {
        private readonly List<int> _amounts = new List<int>();

        public CashierInput(IEnumerable<int> amounts)
        {
            foreach (var amount in amounts)
            {
                _amounts.Add(amount);
            }
        }
        
        public string AskQuestion(string question)
        {
            return "";
        }

        public int AskBlockQuantity(string question)
        {
            var amount = 0;
            for (var i = 1; i <= _amounts.Count; i++)
            {
                amount = _amounts.FirstOrDefault();
                _amounts.Remove(amount);
                return amount;
            }
            return amount;
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