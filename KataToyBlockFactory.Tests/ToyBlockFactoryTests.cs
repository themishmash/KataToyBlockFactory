using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class ToyBlockFactoryTests
    {
        [Fact]
        public void OrdersStartFrom1()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("", "");

            Assert.Equal(1, order.OrderNumber);
        }
        
        [Fact]
        public void CanCreateOrderWithIncreasingOrderNumber()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("", "");
            var order = toyBlockFactory.CreateOrder("", "");
            
            Assert.Equal(2, order.OrderNumber);
        }
    }
}