using Microsoft.EntityFrameworkCore;
using TesteVize.Data;
using TesteVize.Models;
using TesteVize.Repository.Interfaces;

namespace TesteVize.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutosDBContext _dbContext;

        public ProdutoRepositorio(ProdutosDBContext produtosDBContext) 
        { 
            _dbContext = produtosDBContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync (x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
           await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoId = await BuscarPorId(id);

            if (produtoId == null)
            {
                throw new Exception($"Produto para o ID {id} não foi encontrado.");
            }
            produtoId.Name = produto.Name;
            produtoId.Type = produto.Type;
            produtoId.PriceUnit = produto.PriceUnit;

            _dbContext.Produtos.Update(produtoId);
            _dbContext.SaveChanges();

            return produtoId;
        }

        public async Task<bool> Deletar(int id)
        {
            ProdutoModel produtoId = await BuscarPorId(id);

            if (produtoId == null)
            {
                throw new Exception($"Produto para o ID {id} não foi encontrado.");
            }

            _dbContext.Remove(produtoId);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
