using System;

namespace Triangles.Model
{
    public class Vertex : IComparable
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

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public int CompareTo(object obj)
        {
            var other = (Vertex) obj;
            var diff = X.CompareTo(other.X);
            if (diff == 0)
            {
                diff = Y.CompareTo(other.Y);
            }

            return diff;
        }
    }
}