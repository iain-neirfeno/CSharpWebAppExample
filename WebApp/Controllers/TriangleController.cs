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
        public ActionResult FindTriangle(string[] vertex)
        {
            try
            {
                var vertices = ConvertVertices(vertex);
                var t = _triangleByVerticesService.GetTriangleByVertices(vertices[0][0], vertices[0][1],
                    vertices[1][0], vertices[1][1], vertices[2][0], vertices[2][1]);
                return Ok(t);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        private static int[][] ConvertVertices(string[] vertex)
        {
            int[][] vertices;
            try
            {
                vertices = vertex.Select(v => v.Split(",").Select(int.Parse).ToArray()).ToArray();
            }
            catch
            {
                throw new ArgumentException("Vertex argument must be comma separated X,Y coordinate");
            }

            if (vertices.Length != 3)
            {
                throw new ArgumentException("Require 3 vertices to determine triangle name");
            }

            if (vertices.FirstOrDefault(a => a.Length != 2) != null)
            {
                throw new ArgumentException("Each vertex must include the X and Y coordinate");
            }

            return vertices;
        }
    }
}