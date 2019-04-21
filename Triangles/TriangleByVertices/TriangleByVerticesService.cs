using System;
using AutoMapper;
using Triangles.Model;

namespace Triangles.TriangleByVertices
{
    public class TriangleByVerticesService
    {
        private readonly ITiangeByVerticesRepo _repo;
        private readonly IMapper _mapper;

        public TriangleByVerticesService(ITiangeByVerticesRepo repo)
        {
            _repo = repo;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Triangle, TrianglePositionDto>();
            }).CreateMapper();
        }

        public TrianglePositionDto GetTriangleByVertices(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            var triangle = _repo.FindTriangleByVertices(v1X, v1Y, v2X, v2Y, v3X, v3Y);
            if (triangle == null)
                throw new ArgumentOutOfRangeException();

            return _mapper.Map<TrianglePositionDto>(triangle);
        }
    }
}