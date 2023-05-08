using Microsoft.EntityFrameworkCore;
using ProyectoProgra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgra.DAO
{
    public class CrudTickets
    {
        public void AgregarCliente(Usuario PUsuario)
        {
            using (SuperTicketContext db = new SuperTicketContext())
            {
                Usuario Usuario = new Usuario();
                Usuario.Nombre = PUsuario.Nombre;
                Usuario.NúmeroTeléfono = PUsuario.NúmeroTeléfono;
                Usuario.Correo = PUsuario.Correo;
                Usuario.Contraseña = PUsuario.Contraseña;
                db.Add(Usuario);
                db.SaveChanges();

            }
        }
        public Usuario UsuarioInd(int id)
        {
            using (SuperTicketContext db = new SuperTicketContext())
            {

                var buscar = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

                return buscar;


            }
        }
        public void ActualizarUsuario(Usuario PUsuario, int Lector)
        {
            using (SuperTicketContext db = new SuperTicketContext())
            {

                var buscar = UsuarioInd(PUsuario.IdUsuario);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = PUsuario.Nombre;
                    }
                    db.Update(buscar);
                    db.SaveChanges();

                }
            }


        }
        public List<Usuario> ListarUsuarios()
        {
            using (SuperTicketContext db = new SuperTicketContext())
            { return db.Usuarios.ToList(); }
        }

        public bool Acceso(Usuario Usuario)
        {
            using (SuperTicketContext db = new SuperTicketContext())
            {
                var Acceder = db.Usuarios.Where(x => x.IdUsuario == Usuario.IdUsuario &&
                x.Nombre == Usuario.Nombre
                ).ToList();

                return Acceder.Any() ? true : false;
            }


        }


        public List<Ticket> ListarProductos()
        {
            using (SuperTicketContext db = new SuperTicketContext())
            { return db.Tickets.ToList(); }
        }

        public void AgregarCompra(Compra Compra)
        {
            using (SuperTicketContext db = new SuperTicketContext())
            {
                // Agrega la venta a la base de datos
                db.Add(Compra);

                try
                {
                    // Guarda los cambios en la base de datos
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    ;
                    Console.WriteLine(e);
                }
            }
        }

        public decimal CalcularCompra(Ticket Ticket, Compra Compra)
        {
            decimal total = 0;

            using (SuperTicketContext db = new SuperTicketContext())
            {
                Ticket = db.Tickets.FirstOrDefault(p => p.IdTicket == Compra.IdTickets);

                if (Ticket != null)
                {
                    //cambiar base de datos Cantidad boletos = int
                    total = Ticket.PrecioTicket * Compra.CantidadBoleto;
                }
                else
                {
                    Console.WriteLine($"El producto con ID {Compra.IdTickets} no existe en la base de datos.");
                }
            }

            return total;
        }






    }
}