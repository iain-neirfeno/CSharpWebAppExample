using System;
using Moq;
using Triangles.Model;
using Triangles.TriangleByVertices;
using Xunit;

namespace TrianglesTest.TriangleByVertices
{
    public class TriangleByVerticesServiceTest
    {
        private readonly Mock<ITiangeByVerticesRepo> _repo;
        private readonly TriangleByVerticesService _testSubject;

        public TriangleByVerticesServiceTest()
        {
            _repo = new Mock<ITiangeByVerticesRepo>();
            _testSubject = new TriangleByVerticesService(_repo.Object);
        }
        
        [Fact]
        public void TestGetTriangleByPositionReturnsVertices()
        {
            _repo.Setup(_ => _.FindTriangleByVertices(
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>())
            ).Returns(new Triangle(
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    1,
                    'A'
                )
            );
            var result = _testSubject.GetTriangleByVertices(1, 1, 1, 1, 1, 1);
            Assert.IsType<TrianglePositionDto>(result);
        }
        
        [Fact]
        public void TestGetTriangleCoordinatesThrowsExceptionIfNotExists()
        {
            _repo.Setup(_ => _.FindTriangleByVertices(
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>())
            ).Returns(
                (Triangle) null
            );
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _testSubject.GetTriangleByVertices(1, 1, 1, 1, 1, 1)
                );
        }
        
        [Fact]
        public void TestGetTriangleCoordinatesResponseMatchesTriangleReturned()
        {
            _repo.Setup(_ => _.FindTriangleByVertices(
                    It.IsAny<int>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>())
            ).Returns(new Triangle(
                    new Vertex(1, 4),
                    new Vertex(2, 5),
                    new Vertex(3, 6),
                    1,
                    'A'
                )
            );
            var result = _testSubject.GetTriangleByVertices(1, 1, 1, 1, 1, 1);
            Assert.Equal('A', result.Row);
            Assert.Equal(1, result.Column);
        }
        
        [Fact]
        public void TestGetTriangleCoordinatesRequestsByColumnAndRowToRepo()
        {
            _repo.Setup(_ => _.FindTriangleByVertices(
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<int>())
            ).Returns(new Triangle(
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    new Vertex(1, 1),
                    1,
                    'A'
                )
            );
            _testSubject.GetTriangleByVertices(1, 2, 3, 4, 5, 6);
            _repo.Verify(_ => _.FindTriangleByVertices(
                It.Is<int>(c => c == 1), 
                It.Is<int>(c => c == 2), 
                It.Is<int>(c => c == 3),
                It.Is<int>(c => c == 4),
                It.Is<int>(c => c == 5),
                It.Is<int>(c => c == 6)),
                Times.AtLeastOnce);
        }
    }
}