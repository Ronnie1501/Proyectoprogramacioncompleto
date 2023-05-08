using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string NombreTicket { get; set; } = null!;

    public int PrecioTicket { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
