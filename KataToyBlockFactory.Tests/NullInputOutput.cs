using System;
using KataToyBlockFactory;

namespace ToyBlockFactory.Tests
{
    public class NullInputOutput : IInputOutput
    {
        public string AskQuestion(string question)
        {
            return "";
        }

        public int AskBlockQuantity(string question)
        {
            throw new NotImplementedException();
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