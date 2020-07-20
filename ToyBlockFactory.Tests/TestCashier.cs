using System;
using System.Collections.Generic;
using KataToyBlockFactory;

namespace ToyBlockFactory.Tests
{
    public class TestCashier : IInputOutput
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime Date { get; }
        public int OrderNumber { get; }

        private readonly List<Block> BlockOrder = new List<Block>();
        public readonly string BlueSquare;
        

        public TestCashier(string name, string address, string date, int orderNumber, string blueSquare)
        {
            Name = name;
            Address = address;
            Date = AskDate(date);
            OrderNumber = orderNumber;
            BlueSquare = blueSquare;
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