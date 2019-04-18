using Moq;
using Triangles.Model;
using Triangles.TriangleByPosition;
using Xunit;

namespace TrianglesTest.TriangleByPosition
{
    public class TriangleByPositionServiceTest
    {
        private readonly TriangleByPositionService _testSubject;
        private readonly Mock<ITriangleByPositionRepo> _repo;

        public TriangleByPositionServiceTest()
        {
            _repo = new Mock<ITriangleByPositionRepo>();
            _testSubject = new TriangleByPositionService(_repo.Object);
        }
    
        [Fact]
        public void TestGetTriangleByPositionReturnsVertices()
        {
            _repo.Setup(_ => _.FindTriangleByRowAndColumn(It.IsAny<char>(), It.IsAny<int>())).Returns(new Triangle(
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    1,
                    'A'
                )
            );
            var result = _testSubject.GetTriangleByPosition('A', 1);
            Assert.IsType<TriangleVerticesDto>(result);
        }
        
    }
}