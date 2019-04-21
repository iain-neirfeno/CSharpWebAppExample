using System;
using AutoMapper;
using Triangles.Model;

namespace Triangles.TriangleByPosition
{
    public class TriangleByPositionService
    {
        private readonly ITriangleByPositionRepo _repo;
        private readonly IMapper _mapper;
        
        public TriangleByPositionService(ITriangleByPositionRepo repo)
        {
            _repo = repo;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Triangle, TriangleVerticesDto>();
                cfg.CreateMap<Vertex, VertexDto>();
            }).CreateMapper();
        }

        /// <summary>
        /// Retrieves a Triangles vertices by position
        /// </summary>
        /// <param name="row">The row letter representing the position</param>
        /// <param name="column">The column number within the row</param>
        /// <returns>The vertices of the triangle at the given position</returns>
        /// <exception cref="ArgumentOutOfRangeException">If no triangle exists at the given location</exception>
        public TriangleVerticesDto GetTriangleByPosition(char row, int column)
        {
            var triangle = _repo.FindTriangleByRowAndColumn(row, column);
            
            if (triangle == null)
                throw new ArgumentOutOfRangeException();

            return _mapper.Map<TriangleVerticesDto>(triangle);
        }
    }
}