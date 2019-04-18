namespace Triangles.Model
{
    public class Triangle
    {
        public Vertex[] Vertices { get; }
        public int Column { get; }
        public char Row { get; }

        public Triangle(Vertex v1, Vertex v2, Vertex v3, int column, char row)
        {
            Vertices = new[]{v1, v2, v3};
            Column = column;
            Row = row;
        }
    }
}