using Triangles.Model;
using Triangles.TriangleByPosition;

namespace CalculatedTriangleRepo
{
    public class TriangleRepo: ITriangleByPositionRepo
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
            
            if (!IsValidLocation(rowIndex, column))
            {
                return null;
            }
         
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
            return row - 64;
        }
    }
}