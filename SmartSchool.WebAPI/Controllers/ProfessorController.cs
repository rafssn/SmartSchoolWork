using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){ }
        
        [HttpGet]
        public IActionResult GetProfessores(){
            return Ok("Professores: Rafael, Marta, Lucas");
        }
    }
}