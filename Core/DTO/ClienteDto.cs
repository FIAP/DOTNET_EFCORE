namespace Core.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public ICollection<PedidoDto> Pedidos { get; set; }
    }
}
