using Core.DTO;
using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ClienteDto ObterPedidosSeisMeses(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Esse cliente não existe");

            return new ClienteDto()
            {
                Id = cliente.Id,
                DataCriacao = cliente.DataCriacao,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Pedidos = cliente.Pedidos
                    .Where(c => c.DataCriacao >= DateTime.Now.AddMonths(-6))
                    .Select(pedido => new PedidoDto()
                    {
                        Id = pedido.Id,
                        DataCriacao = pedido.DataCriacao,
                        LivroId = pedido.LivroId,
                        ClienteId = pedido.ClienteId,
                        Livro = new LivroDto()
                        {
                            Id = pedido.Livro.Id,
                            DataCriacao = pedido.Livro.DataCriacao,
                            Nome = pedido.Livro.Nome,
                            Editora = pedido.Livro.Editora
                        }
                    }).ToList()
            };
        }
    }
}
