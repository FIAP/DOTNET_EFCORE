using Core.Entity;

namespace Core.Repository
{
    public interface ILivroRepository : IRepository<Livro>
    {
        void CadastrarEmMassa(IEnumerable<Livro> livros);
    }
}
