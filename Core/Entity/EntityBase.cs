using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
