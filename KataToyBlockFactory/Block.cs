namespace KataToyBlockFactory
{
    public class Block
    {
        public Shape Shape { get; }
        public Color Color { get; }
        
        public int Price { get; set; }
        
        public Block(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
          //  Price = 0;
        }
    }
}