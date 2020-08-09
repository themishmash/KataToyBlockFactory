using System;

namespace KataToyBlockFactory
{
    public class ConsoleInputOutput : IInputOutput
    {
        //int [] =
        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public int AskBlockQuantity(string question)
        {
            Console.WriteLine(question);
            var answer = Console.ReadLine();
            var quantity = int.Parse(answer);
            return quantity;
        }


        public DateTime AskDate(string question)
        {
            Console.WriteLine(question);
            var answer = Console.ReadLine();
            var dateTime = Convert.ToDateTime(answer);
            return dateTime;
        }

        public void output(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}