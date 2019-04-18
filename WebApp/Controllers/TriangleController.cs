using System;
using Microsoft.AspNetCore.Mvc;
using Triangles.TriangleByPosition;

namespace WebApp.Controllers
{
    [Route("api")]
    public class TriangleController: Controller
    {
        private readonly TriangleByPositionService _triangleByPositionService;

        public TriangleController(TriangleByPositionService triangleByPositionService)
        {
            _triangleByPositionService = triangleByPositionService;
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
    }
}