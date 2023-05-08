using Microsoft.EntityFrameworkCore;
using ProyectoProgra.DAO;
using ProyectoProgra.Models;

CrudTickets CrudTickets = new CrudTickets();
Usuario usuario = new Usuario();
Compra compra = new Compra();
Ticket Ticket = new Ticket();

bool salir = false;

while (!salir)
{
    Console.WriteLine("Bienvenido a SuperTicket");
    Console.WriteLine("¿Ya está registrado?");
    Console.WriteLine("Si lo está presione 1, si es nuevo cliente presione 2, para salir presione salir 0");
    Console.WriteLine("si es nuevo presione 2 para registrarse");
    Console.WriteLine("Para salir presione 0");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 0:
            salir = true;
            break;

        case 1:
            Console.WriteLine("Acceda a su Usuario");
            Console.WriteLine("Lista de Usuarios");

            var lUsuarios = CrudTickets.ListarUsuarios();

            foreach (var iteracionUsuario in lUsuarios)
            {
                Console.WriteLine($"ID ID: {iteracionUsuario.IdUsuario}:, Nombre: {iteracionUsuario.Nombre} ");
            }
            Console.WriteLine("Ingrese su ID ");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese su Nombre:");
            usuario.Nombre = Console.ReadLine();

            bool Resultado = CrudTickets.Acceso(usuario);
            if (Resultado == true)
            {
                Console.WriteLine("usted esta haciendo una compra ");
                var tickets = CrudTickets.ListarProductos();

                foreach (var iteracionProducto in tickets)
                {
                    Console.WriteLine($"ID ID: {iteracionProducto.IdTicket}:, Nombre: {iteracionProducto.NombreTicket.PadRight(25)}, Precio: ${iteracionProducto.PrecioTicket.ToString("0.00").PadRight(10)}");
                }
                Console.WriteLine("Ingrese el id del Cliente ");
                compra.IdUsuario = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ingrese el id del pructo ");
                compra.IdCompra = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad");
                compra.CantidadBoleto = Convert.ToInt32(Console.ReadLine());

                decimal total = CrudTickets.CalcularCompra(Ticket, compra);
                compra.TotalCompra = total;

                CrudTickets.AgregarCompra(compra);
                Console.WriteLine($"su total es {compra.TotalCompra}");
                Console.WriteLine("Se guardó en la base de datos ");

            }
            else
            {
                Console.WriteLine("Su usuario es incorrecto ");
            }
            break;
        case 2:
            Console.WriteLine("Por favor ingrese sus datos para continuar: ");
            Console.WriteLine("ingrese su Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("ingrese el su telefono ");
            usuario.NúmeroTeléfono = Console.ReadLine();
            Console.WriteLine("ingrese su correo electronico ");
            usuario.Correo = Console.ReadLine();
            Console.WriteLine("ingrese su Contraseña: ");
            usuario.Contraseña = Console.ReadLine();
            CrudTickets.AgregarCliente(usuario);
            Console.WriteLine("sus datos se registraron correctamente: ");
            Console.WriteLine($"su id es: {usuario.IdUsuario} ");
            Console.WriteLine("por favor acceda: ");
            var lclientes = CrudTickets.ListarUsuarios();

            foreach (var iteracionCliente in lclientes)
            {
                Console.WriteLine($"ID ID: {iteracionCliente.IdUsuario}:, Nombre: {iteracionCliente.Nombre} ");
            }
            Console.WriteLine("Ingrese su ID ");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese su Nombre ");
            usuario.Nombre = Console.ReadLine();

            bool Rersultado = CrudTickets.Acceso(usuario);
            if (Rersultado == true)
            {
                Console.WriteLine("usted esta haciendo una compra ");
                var productos = CrudTickets.ListarProductos();

                foreach (var iteracionProducto in productos)
                {
                    Console.WriteLine($"ID ID: {iteracionProducto.IdTicket}:, Nombre: {iteracionProducto.NombreTicket.PadRight(25)}, Precio: ${iteracionProducto.PrecioTicket.ToString("0.00").PadRight(10)}");
                }
                Console.WriteLine("Ingrese el id del Cliente ");
                compra.IdUsuario = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ingrese el id del pructo ");
                compra.IdTickets = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad");
                compra.CantidadBoleto = Convert.ToInt32(Console.ReadLine());

                decimal total = CrudTickets.CalcularCompra(Ticket, compra);
                compra.TotalCompra = total;

                CrudTickets.AgregarCompra(compra);
                Console.WriteLine($"su total es {compra.TotalCompra}");
                Console.WriteLine("Se guardo en la base de datos ");


            }
            else
            {
                Console.WriteLine("el cliente es incorrecto ");
            }
            break;



    }




























}
