using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class InvoiceReport
    {
        public int GetPrice(Order order)
        {
            var total = 0;
            foreach (var block in order.GetBlocks())
            {
                total+=PriceCalculator.GetCost(block);
            }
            return total;
        }
    }
}