using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_API.Data;
using ASPNetCore_API.Models;
using System.Linq;
using System;

namespace ASPNetCore_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly ApplicationDbContext _database;
        
        // Constructor
        public ProdutosController(ApplicationDbContext database)
        {
            this._database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Produtos = _database.Produtos.ToList();
            return Ok(new { Produtos });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
                var Produto = _database.Produtos.Find(id);
                return Ok(Produto);
            } catch(Exception e) {
                return BadRequest(new {msg = "Id Inválido", error = e});
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            Produto produto_new = new Produto();

            produto_new.Nome  = produto.Nome;
            produto_new.Preco = produto.Preco;

            _database.Add(produto_new);
            _database.SaveChanges();

            return Ok(new { msg = "Produto salvo com sucesso", produto = produto_new });
        }
    }
}
