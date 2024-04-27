namespace Core.Entity
{
    public class Livro : EntityBase
    {
        public required string Nome { get; set; }
        public required string Editora { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public Livro()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
