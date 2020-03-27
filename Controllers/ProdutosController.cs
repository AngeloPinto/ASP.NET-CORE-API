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
            return Ok(new { msg = "Produto salvo com sucesso", produto = produto });
        }
    }
}
