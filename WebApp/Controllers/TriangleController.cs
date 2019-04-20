using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Triangles.TriangleByPosition;
using Triangles.TriangleByVertices;

namespace WebApp.Controllers
{
    [Route("api")]
    public class TriangleController: Controller
    {
        private readonly TriangleByPositionService _triangleByPositionService;
        private readonly TriangleByVerticesService _triangleByVerticesService;

        public TriangleController(
            TriangleByPositionService triangleByPositionService, 
            TriangleByVerticesService triangleByVerticesService
            )
        {
            _triangleByPositionService = triangleByPositionService;
            _triangleByVerticesService = triangleByVerticesService;
        }
        
        [HttpGet("row/{row}/column/{column}")]
        public ActionResult GetTrianglePosition(char row, int column)
        {
            try
            {
                var triangleVertices = _triangleByPositionService.GetTriangleByPosition(char.ToUpper(row), column);
                return Ok(triangleVertices);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(new {
                    error = $"No triangle found at location {row}{column}"
                });
            }
        }
        
        [HttpGet]
        public ActionResult FindTriangle(string vertex1, string vertex2, string vertex3)
        {
            try
            {
                var vertex1Coords = ConvertVertices(vertex1);
                var vertex2Coords = ConvertVertices(vertex2);
                var vertex3Coords = ConvertVertices(vertex3);
                var t = _triangleByVerticesService.GetTriangleByVertices(vertex1Coords[0], vertex1Coords[1],
                    vertex2Coords[0], vertex2Coords[1], vertex3Coords[0], vertex3Coords[1]);
                return Ok(t);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        private static int[] ConvertVertices(string vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentException("All 3 vertices must be provided");
            }
            
            int[] vertexCoords;
            try
            {
                vertexCoords = vertex.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                throw new ArgumentException("Vertex argument must be comma separated X,Y coordinate");
            }

            if (vertexCoords.Length != 2) throw new ArgumentException("Each vertex must include the X and Y coordinate");

            return vertexCoords;
        }
    }
}