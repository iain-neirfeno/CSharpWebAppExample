using System;
using System.Linq;

namespace Triangles.Model
{
    public class Triangle
    {
        public Vertex[] Vertices { get; }
        public int Column { get; }
        public char Row { get; }

        public Triangle(Vertex v1, Vertex v2, Vertex v3, int column, char row)
        {
            Vertices = new[]{v1, v2, v3}.OrderBy(v => v).ToArray();
            Column = column;
            Row = row;
        }

        public override bool Equals(object obj)
        {
            var other = (Triangle) obj;
            for (var i = 0; i < 3; ++i)
                if (!Vertices[i].Equals(other.Vertices[i])) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Vertices[0], Vertices[1], Vertices[2]);
        }

        public override string ToString()
        {
            return $"{Row}{Column} ({Vertices[0]} {Vertices[1]} {Vertices[2]})";
        }
    }
}