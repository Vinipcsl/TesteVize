using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteVize.Models;
using TesteVize.Repository.Interfaces;

namespace TesteVize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio) 
        {
            _produtoRepositorio = produtoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutoModel>> Deletar( int id)
        {
           
            bool deletado = await _produtoRepositorio.Deletar( id);
            return Ok(deletado);
        }

    }
}
