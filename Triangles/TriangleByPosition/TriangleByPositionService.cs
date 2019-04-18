using System;
using System.Linq;

namespace Triangles.TriangleByPosition
{
    public class TriangleByPositionService
    {
        private readonly ITriangleByPositionRepo _repo;
        
        public TriangleByPositionService(ITriangleByPositionRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retrieves a Triangles vertices by position
        /// </summary>
        /// <param name="row">The row letter representing the position</param>
        /// <param name="column">The column number within the row</param>
        /// <returns>The vertices of the triangle at the given position</returns>
        /// <exception cref="ArgumentOutOfRangeException">If no triangle exists at the given location</exception>
        public TriangleVerticesDto GetTriangleByPosition(char row, int column)
        {
            var triangle = _repo.FindTriangleByRowAndColumn(row, column);
            if (triangle == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new TriangleVerticesDto
            {
                Vertices = triangle.Vertices.Select(v => new VertexDto
                {
                    X = v.X,
                    Y = v.Y
                }).ToArray()
            };
        }
    }
}