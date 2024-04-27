using System;
using System.Collections.Generic;

namespace Infrastructure.Scaffold;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int LivroId { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Livro Livro { get; set; } = null!;
}
