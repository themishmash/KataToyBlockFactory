using System.Collections.Generic;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class PriceCalculatorTests
    {
        [Fact]
        public void GetsShapePrice()
        {
            var circlePrice = PriceCalculator.GetShapePrice(new Dictionary<Shape, int> {{Shape.Circle, 1}});
            Assert.Equal(3, circlePrice);
        }
        
        [Fact]
        public void GetsColorPrice()
        {
            var redPrice = PriceCalculator.GetColorPrice(new Dictionary<Color, int> {{Color.Red, 1}});

            Assert.Equal(1, redPrice);
        }
    }
}