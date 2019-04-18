using System;

namespace Triangles.Model
{
    public class Vertex
    {
        public int X { get; }
        public int Y { get; }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override bool Equals(object obj)
        {
            return obj is Vertex other &&
                   other.X == X && other.Y == Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}