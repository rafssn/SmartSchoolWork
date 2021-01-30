using System.ComponentModel.DataAnnotations;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }

        [Required]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Required]
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}