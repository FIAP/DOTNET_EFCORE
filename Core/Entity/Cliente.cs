namespace Core.Entity
{
    public class Cliente : EntityBase
    {
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
