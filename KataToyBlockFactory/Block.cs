using System;

namespace KataToyBlockFactory
{
    public class Block
    {
        protected bool Equals(Block other)
        {
            return Shape == other.Shape && Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Block) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Shape, (int) Color);
        }

        public Shape Shape { get; }
        public Color Color { get; }
        
        
        public Block(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
        }

     
    }
}