using Triangles.Model;
using Xunit;

namespace TrianglesTest.Model
{
    public class TriangleTest
    {
        [Fact]
        public void TestTwoTrianglesWithEqualVerticesAreEqual()
        {
            var one = MakeTriangle(1);
            var other = MakeTriangle(1);

            Assert.Equal(one, other);
        }

        [Fact]
        public void TestHashCodeMatchesOfTwoEqualTriangles()
        {
            var one = MakeTriangle(1);
            var other = MakeTriangle(1);
            
            Assert.Equal(one.GetHashCode(), other.GetHashCode());
        }
        
        [Fact]
        public void TestTwoTrianglesWithUnequalCoordsAreNotEqual()
        {
            var one = MakeTriangle(1);
            var other = MakeTriangle(2);

            Assert.NotEqual(one, other);
        }

        [Fact]
        public void TestHashCodeDoesNotMatchOfTwoUnequalTriangles()
        {
            var one = MakeTriangle(1);
            var other = MakeTriangle(2);
            
            Assert.NotEqual(one.GetHashCode(), other.GetHashCode());
        }
        
        [Fact]
        public void TestTwoTrianglesWithEqualVerticesInstantiatedOutOfOrderAreEqual()
        {
            var one = MakeTriangle(1, 1, 2, 2, 3, 3);
            var other = MakeTriangle(3, 3, 2, 2, 1, 1);

            Assert.Equal(one, other);
        }

        [Fact]
        public void TestHashCodeMatchesOfTwoEqualTrianglesWithOutOfOrderVertices()
        {
            var one = MakeTriangle(1, 1, 2, 2, 3, 3);
            var other = MakeTriangle(3, 3, 2, 2, 1, 1);

            Assert.Equal(one.GetHashCode(), other.GetHashCode());
        }

        private static Triangle MakeTriangle(int c)
        {
            return MakeTriangle(c, c, c, c, c, c);
        }

        private static Triangle MakeTriangle(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            return new Triangle(
                new Vertex(v1X, v1Y), 
                new Vertex(v2X, v2Y), 
                new Vertex(v3X, v3Y), 
                1,
                'A');
        }
    }
}