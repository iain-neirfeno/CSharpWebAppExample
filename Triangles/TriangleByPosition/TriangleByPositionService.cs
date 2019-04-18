namespace Triangles.TriangleByPosition
{
    public class TriangleByPositionService
    {

        /// <summary>
        /// Retrieves a Triangles vertices by position
        /// </summary>
        /// <param name="row">The row letter representing the position</param>
        /// <param name="column">The column number within the row</param>
        /// <returns>The vertices of the triangle at the given position</returns>
        public TriangleVertices GetTriangleByPosition(char row, int column)
        {
            return new TriangleVertices();
        }
    }
}