using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAlunos(){
            return Ok(_context.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAlunosById(int id){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null){
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetAlunosByName(string nome){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

            if(aluno == null){
                return NotFound();
            }
            
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult PostAluno(Aluno aluno){
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno){
            var alu = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(alu == null){
                return NotFound();
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null){
                return NotFound();
            }

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}