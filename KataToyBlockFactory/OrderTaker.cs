using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class OrderTaker
    {
        private readonly IInputOutput _iio;
        public readonly List<Block> BlockOrder = new List<Block>();

        public OrderTaker(IInputOutput iio)
        {
            _iio = iio;
        }

        public string GetName()
        {
            return _iio.AskQuestion("Please input your Name: ");
        }

        public string GetAddress()
        {
            return _iio.AskQuestion("Please input your address: ");
        }
        
        public DateTime GetDate()
        {
           return _iio.AskDate("Please input your Due Date: ");
        }
        
        public int GetOrderNumber()
        { 
            var count = 0;
            count++;
            return count;
        }
        
        public List<Block> GetSquareOrder()
        {
            //todo iterate through colour enum to ask this question to put into function
            var blueSquare = _iio.AskQuestion("Please input the number of Blue Squares: ");
            var numberOfBlueSquares = int.Parse(blueSquare);
            var yellowSquare = _iio.AskQuestion("Please input the number of Yellow Squares: ");
            var numberOfYellowSquares = int.Parse(yellowSquare);
            var redSquare = _iio.AskQuestion("Please input the number of Red Squares: ");
            var numberOfRedSquares = int.Parse(redSquare);
            
            GetShapeColorOrder(numberOfBlueSquares);
            GetShapeColorOrder(numberOfYellowSquares);
            GetShapeColorOrder(numberOfRedSquares);
            return BlockOrder;
        }

        private void GetShapeColorOrder(int numberOfColorSquare)
        {
            for (var i = 1; i <= numberOfColorSquare; i++)
            {
                var block = new Block(Shape.Square, Color.Blue);
                BlockOrder.Add(block);
            }
        }
    }
}