using Microsoft.AspNetCore.Mvc;
using SmartSchoolAPI.Models;

namespace SmartSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Leo",
                Sobrenome = "Pele",
                Telefone = "362781"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Paulinho",
                Sobrenome = "Paula",
                Telefone = "342387"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Lucas",
                Sobrenome = "Pitton",
                Telefone = "65646546"
            }
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        // api/aluno/byId/ID
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }
        // api/aluno/byName?nome=NOME&sobrenome=SOBRENOME
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
                );
            if(aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}