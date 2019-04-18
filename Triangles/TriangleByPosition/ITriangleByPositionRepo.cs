using Triangles.Model;

namespace Triangles.TriangleByPosition
{
    public interface ITriangleByPositionRepo
    {

        /// <summary>
        /// Find a Triangle by row and column combination
        /// </summary>
        /// <param name="row">row position of triangle to be returned</param>
        /// <param name="column">column within the row for the triangle</param>
        /// <returns>The Triangle at the given position or null if no triangle found</returns>
        Triangle FindTriangleByRowAndColumn(char row, int column);
    }
}