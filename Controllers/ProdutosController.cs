using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_API.Data;
using ASPNetCore_API.Models;
using System;
using System.Linq;

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
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Id Inválido", error = e});
            }
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            Produto produto_new = new Produto();

            produto_new.Nome  = produto.Nome;
            produto_new.Preco = produto.Preco;

            _database.Add(produto_new);
            _database.SaveChanges();

            Response.StatusCode = 201;
            var result = new ObjectResult(
                new 
                { 
                    msg = "Produto salvo com sucesso",
                    produto = produto_new 
                }
            );

            return result;
        }


        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                
                var Produto = _database.Produtos.Find(id);
                _database.Produtos.Remove(Produto);
                _database.SaveChanges();

                return Ok(new { msg = "Recurso deletado", produto = Produto } );

            } catch (Exception e) {
                
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "Id Inválido", error = e});
            }            
        }
    }
}
