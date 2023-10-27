using Microsoft.AspNetCore.Mvc;

namespace SmartSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("TesteProfessor");
        }
    }
}