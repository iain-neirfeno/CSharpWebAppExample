using CalculatedTriangleRepo;
using Triangles.Model;
using Xunit;

namespace CalculatedTriangleRepoTest
{
    public class TriangleRepoTest
    {
        private readonly TriangleRepo _testSubject;

        public TriangleRepoTest()
        {
            _testSubject = new TriangleRepo();
        }
        
        [Theory]
        [InlineData(1, 'A', 0, 0, 0, 10, 10, 10)]
        [InlineData(2, 'A', 0, 0, 10, 0, 10, 10)]
        [InlineData(3, 'A', 10, 0, 10, 10, 20, 10)]
        [InlineData(4, 'A', 10, 0, 20, 0, 20, 10)]
        [InlineData(5, 'A', 20, 0, 20, 10, 30, 10)]
        [InlineData(6, 'A', 20, 0, 30, 0, 30, 10)]
        [InlineData(7, 'A', 30, 0, 30, 10, 40, 10)]
        [InlineData(8, 'A', 30, 0, 40, 0, 40, 10)]
        [InlineData(9, 'A', 40, 0, 40, 10, 50, 10)]
        [InlineData(10, 'A', 40, 0, 50, 0, 50, 10)]
        [InlineData(11, 'A', 50, 0, 50, 10, 60, 10)]
        [InlineData(12, 'A', 50, 0, 60, 00, 60, 10)]
        [InlineData(1, 'B', 0, 10, 0, 20, 10, 20)]
        [InlineData(12, 'B', 50, 10, 60, 10, 60, 20)]
        [InlineData(1, 'F', 0, 50, 0, 60, 10, 60)]
        [InlineData(12, 'F', 50, 50, 60, 50, 60, 60)]
        public void TestFindTrianglesByColumnAndRow(int column, char row, int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            var expected = new Triangle(new Vertex(v1X, v1Y), new Vertex(v2X, v2Y), new Vertex(v3X, v3Y), column, row);
            var result = _testSubject.FindTriangleByRowAndColumn(row, column);
            Assert.NotNull(result);
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(0, 'A')]
        [InlineData(13, 'A')]
        [InlineData(0, '0')]
        [InlineData(0, 'G')]
        public void TestOutOfBoundsReturnsNullForFindByColumnAndRow(int column, char row)
        {
            Assert.Null(_testSubject.FindTriangleByRowAndColumn(row, column));
        }
    }
}