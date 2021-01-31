using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor){
                query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaid, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor){
                query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaid));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoid, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor){
                query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(aluno => aluno.Id == alunoid);

            return query.FirstOrDefault();        
            }

        public Professor[] GetAllProfessores(bool includealunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includealunos){
                query = query
                .Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunosDisciplina)
                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                    .OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaid, bool includealunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includealunos){
                query = query
                .Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunosDisciplina)
                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
            .OrderBy(aluno => aluno.Id)
            .Where(aluno => aluno.Disciplinas.Any(
                d => d.AlunosDisciplina.Any(ad => ad.DisciplinaId == disciplinaid)
            ));

            return query.ToArray();
        }

        public Professor GetProfessorById(int profid, bool includealunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includealunos){
                query = query
                .Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunosDisciplina)
                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
            .Where(prof => prof.Id == profid);

            return query.FirstOrDefault();
        }
    }
}