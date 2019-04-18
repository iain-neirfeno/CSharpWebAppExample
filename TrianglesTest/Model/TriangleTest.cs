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

        private static Triangle MakeTriangle(int c)
        {
            return new Triangle(new Vertex(c, c), new Vertex(c, c), new Vertex(c, c), 1, 'A');
        }
    }
}