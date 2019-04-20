using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Triangles.TriangleByPosition;
using Triangles.TriangleByVertices;
using WebApp.Dto;

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
                return Ok(_triangleByPositionService.GetTriangleByPosition(char.ToUpper(row), column));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(new {
                    message = e.Message
                });
            }
        }
        
        [HttpGet]
        public ActionResult FindTriangle([Required] Vertex vertex1, [Required] Vertex vertex2, [Required] Vertex vertex3)
        {
            try
            {
                return Ok(_triangleByVerticesService.GetTriangleByVertices(vertex1.X, vertex1.Y, vertex2.X, vertex2.Y, vertex3.X, vertex3.Y));
            }
            catch (ArgumentException e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
        }
    }
}