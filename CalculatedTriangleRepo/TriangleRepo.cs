using System.Linq;
using Triangles.Model;
using Triangles.TriangleByPosition;
using Triangles.TriangleByVertices;

namespace CalculatedTriangleRepo
{
    public class TriangleRepo: ITriangleByPositionRepo, ITiangeByVerticesRepo
    {
        private readonly int _triangleSideLength;
        private readonly int _numberOfColumns;
        private readonly int _numberOfRows;

        public TriangleRepo(int numberOfRows, int numberOfColumns, int triangleSideLength)
        {
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _triangleSideLength = triangleSideLength;
        }


        public Triangle FindTriangleByRowAndColumn(char row, int column)
        {
            var rowIndex = GetRowIndex(row);
            
            if (!IsValidLocation(rowIndex, column)) return null;
         
            var inversionFactor = (column - 1) % 2;

            var topLeftVertex = FindTopLeftVertex(rowIndex, column);
            var bottomRightVertex = FindBottomRightVertex(topLeftVertex);
            var remainingVertex = FindRemainingVertex(topLeftVertex, inversionFactor);

            return new Triangle(
                topLeftVertex,
                bottomRightVertex,
                remainingVertex,
                column,
                row
            );
        }

        public Triangle FindTriangleByVertices(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            if (!(IsValidVertex(v1X, v1Y) && IsValidVertex(v2X, v2Y) && IsValidVertex(v3X, v3Y))) return null;

            var vertices = new[] {new Vertex(v1X, v1Y), new Vertex(v2X, v2Y), new Vertex(v3X, v3Y)};
            var topLeftVertex = FindTopLeftVertex(vertices);
            var topRightVertex = FindTopRightVertex(vertices, topLeftVertex);
            var bottomRightVertex = FindBottomRightVertex(vertices, topLeftVertex);
            var bottomLeftVertex = FindBottomLeftVertex(vertices, topLeftVertex);

            if (!AllVerticesPresent(topRightVertex, bottomLeftVertex, bottomRightVertex)) return null;
            
            var row = (char) ('A' + topLeftVertex.Y / _triangleSideLength);
            var column = topLeftVertex.X / (_triangleSideLength / 2) + 1 + (topRightVertex != null ? 1 : 0);
            return new Triangle(vertices[0], vertices[1], vertices[2], column, row);
        }

        private bool AllVerticesPresent(Vertex topRightVertex, Vertex bottomLeftVertex, Vertex bottomRightVertex)
        {
            return bottomRightVertex != null && (topRightVertex != null || bottomLeftVertex != null);
        }

        private Vertex FindBottomLeftVertex(Vertex[] vertices, Vertex topLeftVertex)
        {
            return vertices.FirstOrDefault(v => v.X == topLeftVertex.X && v.Y == topLeftVertex.Y + _triangleSideLength);
        }

        private Vertex FindTopRightVertex(Vertex[] vertices, Vertex topLeftVertex)
        {
            return vertices.FirstOrDefault(v => v.X == topLeftVertex.X + _triangleSideLength && v.Y == topLeftVertex.Y);
        }

        private Vertex FindBottomRightVertex(Vertex[] vertices, Vertex topLeftVertex)
        {
            return vertices.FirstOrDefault(v => v.X == topLeftVertex.X + _triangleSideLength && v.Y == topLeftVertex.Y + _triangleSideLength);
        }

        private Vertex FindTopLeftVertex(Vertex[] vertices)
        {
            return vertices.OrderBy(v => v.X * _triangleSideLength * (_numberOfColumns / 2) + v.Y).First();
        }

        private bool IsValidLocation(int row, int column)
        {
            return column > 0 && row > 0 && column <= _numberOfColumns && row <= _numberOfRows;
        }

        private Vertex FindTopLeftVertex(int row, int column)
        {
            return new Vertex((column - 1) / 2 * _triangleSideLength, (row - 1) * _triangleSideLength);
        }

        private Vertex FindBottomRightVertex(Vertex topLeftVertex)
        {
            return new Vertex(
                topLeftVertex.X + _triangleSideLength, 
                topLeftVertex.Y + _triangleSideLength);
        }

        private Vertex FindRemainingVertex(Vertex topLeftVertex, int inversionFactor)
        {
            return new Vertex(
                topLeftVertex.X + inversionFactor * _triangleSideLength,
                topLeftVertex.Y + _triangleSideLength - inversionFactor * _triangleSideLength);
        }

        private static int GetRowIndex(char row)
        {
            return row - 'A' + 1;
        }

        private bool IsValidVertex(int x, int y)
        {
            
            return x % _triangleSideLength == 0 && y % _triangleSideLength == 0 &&
                   x >= 0 && x <= _triangleSideLength * (_numberOfColumns / 2) &&
                   y >= 0 && y <= _triangleSideLength * _numberOfRows;
        }
        
        
    }
}