using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class InvoiceReport
    {
        [Fact]
        public void Return_Total_Price_Based_On_Order_Number()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Triangle, Color.Red);
            
            var invoiceReport = toyBlockFactory.GetInvoiceReport(1);
            
            Assert.Equal(7, invoiceReport.GetPrice());
        }
        
        
        
        [Fact]
        public void Default_Price_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");

            var invoiceReport = toyBlockFactory.GetInvoiceReport(1);

            Assert.Equal(0, invoiceReport.GetPrice());
        }
    }
}