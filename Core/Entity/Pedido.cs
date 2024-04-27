namespace Core.Entity
{
    public class Pedido : EntityBase
    {
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Livro Livro { get; set; }
    }
}