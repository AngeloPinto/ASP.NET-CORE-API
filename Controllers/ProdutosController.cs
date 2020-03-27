using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_API.Data;
using ASPNetCore_API.Models;

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
            return Ok(new { nome = "Curso de AspNET Core", conteudo = "Criando um controller" });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new { nome = "Curso de AspNET Core", conteudo = "Criando um controller", key = id });
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
