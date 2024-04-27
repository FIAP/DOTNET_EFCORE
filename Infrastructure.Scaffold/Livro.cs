using System;
using System.Collections.Generic;

namespace Infrastructure.Scaffold;

public partial class Livro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Editora { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
