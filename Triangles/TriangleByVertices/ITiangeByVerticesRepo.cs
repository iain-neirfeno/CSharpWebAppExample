using Triangles.Model;

namespace Triangles.TriangleByVertices
{
    public interface ITiangeByVerticesRepo
    {

        /// <summary>
        /// Find triangle by vertices.
        /// </summary>
        /// <param name="v1X">Vertex 1 X value</param>
        /// <param name="v1Y">Vertex 1 Y value</param>
        /// <param name="v2X">Vertex 2 X value</param>
        /// <param name="v2Y">Vertex 2 Y value</param>
        /// <param name="v3X">Vertex 3 X value</param>
        /// <param name="v3Y">Vertex 3 Y value</param>
        /// <returns>The triangle at this position or null if not found</returns>
        Triangle FindTriangleByVertices(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y);
    }
}