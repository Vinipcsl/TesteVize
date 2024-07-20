using TesteVize.Models;

namespace TesteVize.Repository.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);
        Task<bool> Deletar(int id);

    }   
}
