using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAlunos()
        {
            var result = _repo.GetAllAlunos(true);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAlunosById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult PostAluno(Aluno aluno)
        {   
            _repo.Add(aluno);
            if(_repo.SaveChanges()){
                return Ok(aluno);
            } else{
                return BadRequest("Aluno não cadastrado!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return NotFound();

            _repo.Update(aluno);
            if(_repo.SaveChanges()){
                return Ok(aluno);
            } else{
                return BadRequest("Aluno não atualizado!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) return NotFound();

            _repo.Delete(aluno);
            if(_repo.SaveChanges()){
                return Ok("Aluno deletado!");
            } else{
                return BadRequest("Aluno não deletado!");
            }
        }
    }
}