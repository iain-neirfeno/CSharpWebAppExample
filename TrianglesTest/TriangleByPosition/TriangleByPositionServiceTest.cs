using Triangles.TriangleByPosition;
using Xunit;

namespace TrianglesTest.TriangleByPosition
{
    public class TriangleByPositionServiceTest
    {
        private readonly TriangleByPositionService _testSubject;

        public TriangleByPositionServiceTest()
        {
            _testSubject = new TriangleByPositionService();
        }
    
        [Fact]
        public void TestGetTriangleByPositionReturnsVertices()
        {
            var result = _testSubject.GetTriangleByPosition('A', 1);
            Assert.IsType<TriangleVertices>(result);
        }
        
    }
}