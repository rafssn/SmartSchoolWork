using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context){
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetProfessores(){
            return Ok(_context.Professores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProfessorById(int id){
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            if(professor != null){
                return Ok(professor);
            } else{
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostProfessor(Professor professor){
            try{
                _context.Add(professor);
                _context.SaveChanges();
            } catch{
                return BadRequest();
            }

            return Ok(professor);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutProfessor(int id, Professor prof){
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            try{
                if(professor != null){
                    _context.Update(prof);
                    _context.SaveChanges();
                    return Ok(prof);
                }
                return BadRequest();
            } catch{
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProfessor(int id){
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            try{
               _context.Remove(professor); 
               _context.SaveChanges();
            }
            catch{
                return BadRequest();
            }

            return Ok();
        }

    }
}