namespace Core.DTO
{
    public class LivroDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public required string Editora { get; set; }
        public ICollection<PedidoDto> Pedidos { get; set; }
    }
}
