using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
        //private readonly List<Order> _orders;
        private static Dictionary<Shape, int> _shapesCount = new Dictionary<Shape, int>();

       
        private CuttingReport(Dictionary<Shape, int> shapesCount)
        {
            _shapesCount = shapesCount;
        }

        public static void CreateCuttingReport(Order order)
        {
            foreach (var shape in GetAvailableShapes())
            {
                _shapesCount.Add(shape, order.CountShape(shape));
            }

            if (_shapesCount != null) new CuttingReport(_shapesCount);
        }
        
        //cutting report store dictionary of shapes and numbers. index is shape. and store count. 
        //creat dictionary
        //pass dictionary to constructor to be stored
        //constructor is private. 
        
        //static means never need instnace to exist. 
        

        public static int GetShape(Shape shape)
        {
            return _shapesCount.GetValueOrDefault(shape, 0);
        }
        
        private static IEnumerable<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }

    }
}