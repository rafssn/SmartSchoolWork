using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

        //SEARCH ALUNOS
         Aluno[] GetAllAlunos(bool includeProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId(int disciplinaid, bool includeProfessor = false);
         Aluno GetAlunoById(int alunoid, bool includeProfessor = false);


        //SEARCH PROFESSORES
         Professor[] GetAllProfessores(bool includealunos = false);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaid, bool includealunos = false);
         Professor GetProfessorById(int profid, bool includealunos = false);
   
    }
}