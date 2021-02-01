using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int id, string nome, int professorId, int cursoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int CargaHoraria { get; set; }

        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; }

        [Required]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplina { get; set; }
    }
}