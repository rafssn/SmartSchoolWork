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
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetProfessores()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProfessorById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);

            if (professor != null)
            {
                return Ok(professor);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostProfessor(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges()){
                return Ok(professor);
            }
            else{
                return BadRequest("Professor não cadastrado!");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult PutProfessor(int id, Professor prof)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor != null)
            {
                _repo.Update(professor);
                if(_repo.SaveChanges()){
                    return Ok(professor);
                } else{
                    return BadRequest("Não foi possível salvar as alterações");
                }            
            }else{
                return BadRequest("Informe um professor válido!");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor != null)
            {
                _repo.Delete(professor);
                if(_repo.SaveChanges()){
                    return Ok("O professor foi deletado!");
                } else{
                    return BadRequest("Não foi possível salvar as alterações");
                }            
            }else{
                return BadRequest("Informe um professor válido!");
            }
            
        }

    }
}