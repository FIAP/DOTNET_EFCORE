namespace Core.DTO
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public ClienteDto Cliente { get; set; }
        public LivroDto Livro { get; set; }
    }
}
