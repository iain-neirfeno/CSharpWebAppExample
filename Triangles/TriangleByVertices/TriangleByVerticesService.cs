using System;
using System.Linq;
using Triangles.TriangleByPosition;

namespace Triangles.TriangleByVertices
{
    public class TriangleByVerticesService
    {
        private readonly ITiangeByVerticesRepo _repo;

        public TriangleByVerticesService(ITiangeByVerticesRepo repo)
        {
            _repo = repo;
        }

        public TrianglePositionDto GetTriangleByVertices(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            var triangle = _repo.FindTriangleByVertices(v1X, v1Y, v2X, v2Y, v3X, v3Y);
            if (triangle == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new TrianglePositionDto
            {
                Row = triangle.Row,
                Column = triangle.Column
            };
        }
    }
}