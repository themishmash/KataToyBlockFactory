using System.Collections.Generic;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CreateOrderFromInput()
        {
            var customerInput = new CustomerInput("James", "12 Smith Street", "10/10/20");
            
        }
    }
}