using System;

namespace KataToyBlockFactory
{
    public class ConsoleInputOutput : IInputOutput
    {
        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public int AskBlockQuantity(string question)
        {
            // Console.WriteLine(question);
            // var answer= Console.ReadLine();
            // var quantity = int.Parse(answer!); 
            // return quantity;
            
            Console.WriteLine(question);
            var answer= Console.ReadLine();
            int.TryParse(answer, out var quantity
            );
            return quantity;
            //return quantity;
        }
        
        public DateTime AskDate(string question)
        {
            Console.WriteLine(question);
            var answer = Console.ReadLine();
            var dateTime = Convert.ToDateTime(answer);
            return dateTime;
        }
        
        
    }
}