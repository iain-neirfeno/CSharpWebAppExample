using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using WebApp.Dto;

namespace WebApp.Converters
{
    public class VertexTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                int[] vertexCoords = (value as string).Split(',').Select(int.Parse).ToArray();
                if (vertexCoords.Length != 2)
                    throw new Exception();

                return new Vertex
                {
                    X = vertexCoords[0],
                    Y = vertexCoords[1]
                };
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}