using System;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoCurso
    {
        public AlunoCurso() { }
        public AlunoCurso(int alunoId, int cursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
        }

        public DateTime DataIni { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;
        

        [Required]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Required]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}