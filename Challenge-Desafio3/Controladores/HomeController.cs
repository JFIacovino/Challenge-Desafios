using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge_Desafio3.Repository;
using Challenge_Desafio3.Models;
namespace Challenge_Desafio3.Controladores
{



    [Produces("application/json")]

    [Route("MyRestFulApp/")]

    [ApiController]
    public class HomeController : Controller
    {
        private readonly IRepository<Usuario> _repository;
        public HomeController(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        
        [HttpGet("Usuarios")]
        public IEnumerable<Usuario> Get()
        {
            return _repository.Get();
        }

        [HttpGet("Usuarios/{id}")]
        public Usuario Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost("Usuarios")]
        public void Post([FromBody] Usuario value)
        {
            _repository.Add(value);
            _repository.Save();
        }

        [HttpPut("Usuarios")]
        public void Put( [FromBody] Usuario value)
        {
            _repository.Update(value);
            _repository.Save();
        }

        [HttpDelete("Usuarios/{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }






















    }
}
