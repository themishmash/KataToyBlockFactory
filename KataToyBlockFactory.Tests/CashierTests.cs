using System.Collections.Generic;
using KataToyBlockFactory;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class CashierTests
    {
        [Fact]
        public void CreateOrderFromInput()
        {
            var cashierInput = new CashierInput( new List<int>(){1, 1, 1, 1, 1, 1, 1, 1, 1});
           var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(cashierInput);
           toyBlockFactory.StartOrder();
           var cuttingReport = toyBlockFactory.GetCuttingReport(1);
           
           Assert.Equal(3, cuttingReport.GetShapeTotal(Shape.Circle));
        }
        
        [Fact]
        public void CreateOrderFromInputIncludingZeroQuantity()
        {
            var cashierInput = new CashierInput(new List<int>() {0, 0, 0, 1, 1, 1, 1, 1, 1});
            
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(cashierInput);
            toyBlockFactory.StartOrder();
            var cuttingReport = toyBlockFactory.GetCuttingReport(1);
           
            Assert.Equal(0, cuttingReport.GetShapeTotal(Shape.Square));
        }
        
        [Fact]
        public void OrderStatusProcessedWhenBlocksAdded()
        {
            var cashierInput = new CashierInput(new List<int>() {0, 0, 0, 1, 1, 1, 1, 1, 1});
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(cashierInput);
            toyBlockFactory.StartOrder();
            Assert.Equal(OrderStatus.Processed, toyBlockFactory.GetOrderStatus(1));
        }

        [Fact]
        public void OrderStatusNoneWhenNoBlocksAdded()
        {
            var cashierInput = new CashierInput(new List<int>() {0, 0, 0, 0, 0, 0, 0, 0, 0});
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(cashierInput);
            toyBlockFactory.StartOrder();
            Assert.Equal(OrderStatus.None, toyBlockFactory.GetOrderStatus(1));
        }
    }
}