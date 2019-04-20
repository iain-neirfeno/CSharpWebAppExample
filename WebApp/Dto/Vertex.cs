using System.ComponentModel;
using WebApp.Converters;

namespace WebApp.Dto
{
    [TypeConverter(typeof(VertexTypeConverter))]
    public class Vertex
    {
        public int X;
        public int Y;
    }
}