using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAlunos()
        {
            var alunos = _repo.GetAllAlunos(true);
            
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAlunosById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return NotFound();

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        [HttpPost]
        public IActionResult PostAluno(AlunoDto model)
        {   
            var aluno = _mapper.Map<Aluno>(model);

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