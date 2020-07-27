using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class InvoiceReport
    {
        private readonly PriceCalculator _priceCalculator;
        public InvoiceReport()
        {
            _priceCalculator = new PriceCalculator();
        }
        public int GetPrice(Order order)
        {
            var total = 0;
            foreach (var block in order.GetBlocks())
            {
                total+=_priceCalculator.GetCost(block);
            }
            return total;
        }
    }
}