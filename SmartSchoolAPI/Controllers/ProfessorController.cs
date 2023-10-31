using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolAPI.Data;
using SmartSchoolAPI.Models;

namespace SmartSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            
            return Ok(result);
        }
        // api/professor/ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {  
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado.");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {  
                return Ok(professor);
            }

            return BadRequest("Professor não alterado.");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {  
                return Ok("Professor alterado.");
            }

            return BadRequest("Professor não alterado.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado.");

            _repo.Remove(prof);
            if (_repo.SaveChanges())
            {  
                return Ok("Professor removido.");
            }

            return BadRequest("Professor não removido.");
        }
    }
}