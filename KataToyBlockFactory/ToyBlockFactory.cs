using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> _totalToyBlockOrders = new List<Order>();
        //private readonly List<Block> _totalPaintBlocks = new List<Block>();
        private int _count;

        public Order CreateOrder(string name, string address, string date, int redSquare, int blueSquare, int 
        yellowSquare)
        {
            var order = new Order(name, address, date, redSquare, blueSquare, yellowSquare) {OrderNumber = CreateOrderNumber()};
            //order.GetRedSquares();
            _totalToyBlockOrders.Add(order);
         
            return order;
        }

        private int CreateOrderNumber()
        {
            _count++;
            return _count;
        }
        
        public int GetTotalOrders()
        {
            return _totalToyBlockOrders.Count;
        }


        public int GetRedSquaresToBePainted()
        {
            var numberOfRed = 0;
            foreach (var order in _totalToyBlockOrders)
            {
                numberOfRed += order.GetRedSquares();
            }
            return numberOfRed;
        }
        
        public int GetBlueSquaresToBePainted()
        {
            var numberOfBlue = 0;
            foreach (var order in _totalToyBlockOrders)
            {
                numberOfBlue += order.GetBlueSquares();
            }
            return numberOfBlue;
        }

        public int GetYellowSquaresToBePainted()
        {
            var numberOfyellow = 0;
            foreach (var order in _totalToyBlockOrders)
            {
                numberOfyellow += order.GetYellowSquares();
            }
            return numberOfyellow;
        }
    }
}