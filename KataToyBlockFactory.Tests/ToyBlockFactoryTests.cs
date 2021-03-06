using KataToyBlockFactory;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ToyBlockFactoryTests
    {
        private readonly KataToyBlockFactory.ToyBlockFactory _toyBlockFactory;
        public ToyBlockFactoryTests()
        {
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(new NullInputOutput());
            _toyBlockFactory = toyBlockFactory;
        }
        [Fact]
        public void OrdersStartFrom1()
        {
            var order = _toyBlockFactory.CreateOrder("", "");

            Assert.Equal(1, order.OrderNumber);
        }
        
        [Fact]
        public void CanCreateOrderWithIncreasingOrderNumber()
        {
            _toyBlockFactory.CreateOrder("", "");
            var order = _toyBlockFactory.CreateOrder("", "");
            
            Assert.Equal(2, order.OrderNumber);
        }

        [Fact]
        public void OrdersStartWithNewStatus()
        {
            var order = _toyBlockFactory.CreateOrder("", "");
            Assert.Equal(OrderStatus.New, order.OrderStatus);
        }
        
        [Fact]
        public void OrdersStartWithNewStatusWhenStartOrderCalled()
        {
            var order = _toyBlockFactory.CreateOrder("", "");
            Assert.Equal(OrderStatus.New, order.OrderStatus);
        }
    }
}