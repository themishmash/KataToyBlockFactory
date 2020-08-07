using System;
using System.Collections.Generic;
using KataToyBlockFactory;

namespace KataToyBlockFactory.Tests
{
    public class CustomerInput : IInputOutput
    {
        private string Name { get; }
        private string Address { get; }
        private DateTime DueDate { get; }
        public int OrderNumber { get; }

        private readonly List<Block> BlockOrder = new List<Block>();
        public readonly string BlueSquare;
        
        
        //todo create order like this: with blocks though
        // public static PlayerSpy CreateBlackJackPlayer()
        // {
        //     return new PlayerSpy(new DeckMock(new[]
        //     {
        //         new Card(CardFace.Jack, Suit.Hearts),
        //         new Card(CardFace.Ace, Suit.Hearts),
        //     }), 0);
        // }

        public CustomerInput(string name, string address, string dueDate)
        {
            Name = name;
            Address = address;
            DueDate = AskDate(dueDate);
        }
        
        

        public List<Block> GetBlueSquareOrder(string blueSquare)
        {
            var numberOfBlueSquares = int.Parse(blueSquare);
            for (var i = 1; i <= numberOfBlueSquares; i++)
            {
                var block = new Block(Shape.Square, Color.Blue);
                BlockOrder.Add(block);
            }
            return BlockOrder;
        }

        public DateTime AskDate(string question)
        {
            var dateTime = Convert.ToDateTime(question);
            return dateTime;
        }

        public string AskQuestion(string question)
        {
            throw new NotImplementedException();
        }

        public void output(string message)
        {
            throw new NotImplementedException();
        }
    }
}