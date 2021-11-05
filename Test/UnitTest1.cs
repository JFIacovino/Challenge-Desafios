using NUnit.Framework;
using Challenge_Desafio3.Controladores;
using Challenge_Desafio3.Repository;
using Challenge_Desafio3.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Test
{
    public class Tests
    {
        private readonly HomeController _controller;
        private readonly IRepository<Usuario> _repository;
        private readonly ChallengeContext _context;
        public Tests()
        {
            _repository = new Repository<Usuario>(_context);
            _controller = new HomeController(_repository);


        }
        
        [SetUp]
        public void Setup()
        {
        }

        [Fact]
        public void Get()
        {
         
            var okResult = _controller.Get();
            // Assert
          //  Assert.(okResult as OkObjectResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }


        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
    }
}