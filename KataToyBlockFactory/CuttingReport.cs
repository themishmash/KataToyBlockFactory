using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
        private readonly Order _order;

        public CuttingReport(Order order)
        {
            _order = order;
           
        }

        public int GetShape(Shape shape)
        {
            return _order.CountShape(shape);
        }
        
        
    }
}