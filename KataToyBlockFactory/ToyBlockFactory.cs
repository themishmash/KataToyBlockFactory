using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _count;

        public Order CreateOrder(string name, string address)
        {
           return new Order(name, address);
        }
        
        public Order CreateOrder(string name, string address, string date, int redSquare, int blueSquare, int 
        yellowSquare, int redTriangle, int blueTriangle, int yellowTriangle, int redCircle, int blueCircle, int yellowCircle)
        {
            var order = new Order(name, address, date, redSquare, blueSquare, yellowSquare, redTriangle, 
            blueTriangle, yellowTriangle, redCircle, blueCircle, yellowCircle) 
            {OrderNumber = 
            CreateOrderNumber()};
            
            _orders.Add(order);
            return order;
        }
        
        public Order CreateOrder(string name, string address, string date, int redSquare, int blueSquare, int 
            yellowSquare)
        {
            var order = new Order(name, address, date, redSquare, blueSquare, yellowSquare) 
            {OrderNumber = 
                CreateOrderNumber()};
            _orders.Add(order);
         
            return order;
        }

        private int CreateOrderNumber()
        {
            _count++;
            return _count;
        }
        
        public int GetTotalOrders()
        {
            return _orders.Count;
        }
        
        public int GetTotalRedSquares()
        {
            return _orders.Sum(order => order.GetRedSquares());
        }
        
        public int GetTotalBlueSquares()
        {
            return _orders.Sum(order => order.GetBlueSquares());
        }
        
        public int GetTotalYellowSquares()
        {
            return _orders.Sum(order => order.GetYellowSquares());
        }
        
        public int GetTotalRedTriangles()
        {
            return _orders.Sum(order => order.GetRedTriangles());
        }
        
        public int GetTotalBlueTriangles()
        {
            return _orders.Sum(order => order.GetBlueTriangles());
        }

        public int GetTotalYellowTriangles()
        {
            return _orders.Sum(order => order.GetYellowTriangles());
        }
        
        public int GetTotalRedCircles()
        {
            return _orders.Sum(order => order.GetRedCircles());
        }
        
        public int GetTotalBlueCircles()
        {
            return _orders.Sum(order => order.GetBlueCircles());
        }
        
        public int GetTotalYellowCircles()
        {
            return _orders.Sum(order => order.GetYellowCircles());
        }

        public int GetTotalSquares()
        {
            return _orders.Sum(order => order.GetSquares());
        }

        public int GetTotalTriangles()
        {
            return _orders.Sum(order => order.GetTriangles());
        }

        public int GetTotalCircles()
        {
            return _orders.Sum(order => order.GetCircles());
        }

        
    }
}