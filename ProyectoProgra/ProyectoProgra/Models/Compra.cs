using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaHora { get; set; }

    public int CantidadBoleto { get; set; }

    public decimal TotalCompra { get; set; }

    public int IdTickets { get; set; }

    public virtual Ticket IdTicketsNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
