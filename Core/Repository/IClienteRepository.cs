using Core.DTO;
using Core.Entity;

namespace Core.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        ClienteDto ObterPedidosSeisMeses(int id);
    }
}
