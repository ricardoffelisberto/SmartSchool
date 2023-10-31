using SmartSchoolAPI.Models;

namespace SmartSchoolAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        // ALUNOS
        Aluno[] GetAllAlunos(bool incluirProfessor);
        Aluno[] GetAllAlunosByDesciplinaId(int disciplinaId, bool incluirProfessor);
        Aluno GetAlunoById(int alunoId, bool incluirProfessor);

        // PROFESSORES
        Professor[] GetAllProfessores(bool incluirAlunos);
        Professor[] GetAllProfessoresByDesciplinaId(int disciplinaId, bool incluirAlunos);
        Professor GetProfessorById(int professorId, bool incluirAlunos);
    }
}