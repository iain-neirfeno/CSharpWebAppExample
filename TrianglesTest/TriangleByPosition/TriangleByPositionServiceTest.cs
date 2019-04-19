using System;
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
            _repo.Setup(_ => _.FindTriangleByRowAndColumn(
                It.IsAny<char>(), 
                It.IsAny<int>())
            ).Returns(new Triangle(
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
        
        [Fact]
        public void TestGetTriangleCoordinatesThrowsExceptionIfNotExists()
        {
            _repo.Setup(_ => _.FindTriangleByRowAndColumn(
                It.IsAny<char>(), 
                It.IsAny<int>())
            ).Returns((Triangle) null);
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _testSubject.GetTriangleByPosition('A', 1)
                );
        }
        
        [Fact]
        public void TestGetTriangleCoordinatesResponseMatchesTriangleReturned()
        {
            _repo.Setup(_ => _.FindTriangleByRowAndColumn(It.IsAny<char>(), It.IsAny<int>())).Returns(
                new Triangle(
                    new Vertex(1, 4),
                    new Vertex(2, 5),
                    new Vertex(3, 6),
                    1,
                    'A'
                )
            );
            var result = _testSubject.GetTriangleByPosition('A', 1);
            Assert.Equal(1, result.Vertices[0].X);
            Assert.Equal(2, result.Vertices[1].X);
            Assert.Equal(3, result.Vertices[2].X);
            Assert.Equal(4, result.Vertices[0].Y);
            Assert.Equal(5, result.Vertices[1].Y);
            Assert.Equal(6, result.Vertices[2].Y);
        }
        
        [Fact]
        public void TestGetTriangleCoordinatesRequestsByColumnAndRowToRepo()
        {
            _repo.Setup(_ => _.FindTriangleByRowAndColumn(It.IsAny<char>(), It.IsAny<int>())).Returns(
                new Triangle(
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    1,
                    'A'
                )
            );
            _testSubject.GetTriangleByPosition('A', 1);
            _repo.Verify(_ => _.FindTriangleByRowAndColumn(
                It.Is<char>(r => r == 'A'), 
                It.Is<int>(c => c == 1)
                ), Times.AtLeastOnce);
        }
        
    }
}