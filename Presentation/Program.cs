// See https://aka.ms/new-console-template for more information
using Aplication.Command;
using Aplication.Interface;
using Aplication.Querys;
using Aplication.Service;
using Infraestructure.Command;
using TrabajoPractico;
using static System.Runtime.InteropServices.JavaScript.JSType;

FuncionesService funcion_serv;
PeliculasService pelicula_serv;
using (var context = new CineDBContext())
{
    IFuncionesCommand _funcommand = new FuncionesCommand(context);
    IFuncionesQuerys _funquerys = new FuncionesQuerys(context);
     funcion_serv = new FuncionesService(_funcommand, _funquerys);

    IPeliculasCommand _pelcommand = new PeliculasCommand(context);
    IPeliculasQuerys _pelquerys = new PeliculasQuerys(context);
     pelicula_serv = new PeliculasService(_pelcommand, _pelquerys);

    // Ahora puedes usar funcion_serv y pelicula_serv en tu proyecto actual.
}
string opcion = "s";
while (opcion == "s")
{
    Console.WriteLine("                     |~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
    Console.WriteLine("                     |         bienvenido a      |");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("                     |   ----------------------  |");
    Console.WriteLine("                     |   |      CINE.NET       | |");
    Console.WriteLine("                     |   ----------------------  |");
    Console.ResetColor();
    Console.WriteLine("                     |~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
    Console.WriteLine();
    Console.WriteLine("                         ~~~~~~~~~MENU~~~~~~~~~");
    Console.WriteLine("1.Mostrar las funciones para un determinado dia o titulo de pelicula.");
    Console.WriteLine("2.Registrar una nueva funcion.");
    Console.WriteLine("3.Salir.");
    Console.Write("Ingresar opcion:");
    int opcionMenu = 0 ;
    try
    {
        opcionMenu = int.Parse(Console.ReadLine());
    }
    catch 
    {
        Console.ReadKey();
    }
    switch (opcionMenu)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("¿Como deseas realizar el filtrado?");
            Console.WriteLine("1.TITULO");
            Console.WriteLine("2.HORARIO");
            Console.Write("Opcion: ");
            int filtrado = 0;
            try
            {
                filtrado = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Dato ingresado no valido");
            }
            switch (filtrado)
            {
                case 1:
                    foreach (var peli in pelicula_serv.GetAll())
                    {
                        pelicula_serv.ImprimirTitulo(peli.PeliculaId);
                    }
                    Console.Write("Ingresar titulo de pelicula: ");
                    try
                    {
                        string titulo = Console.ReadLine();
                        funcion_serv.ImprimirFunciones_Peliculas(titulo);
                    }
                    catch
                    {
                        Console.WriteLine("Error al ingresar el titulo.");
                    }
                    break;
                case 2:
                    Console.Write("Ingresar horario:");
                    DateTime actual = DateTime.Today;
                    DateTime fecha;
                    Console.WriteLine("Ingresar la fecha con el siguiente formato:");
                    try
                    {
                        Console.WriteLine("Ingresar dia (dd):");
                        int dia = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresar mes (MM):");
                        int mes = int.Parse(Console.ReadLine());
                        fecha = new DateTime(actual.Year, mes, dia);
                        funcion_serv.ImprimirFunciones_Horarios(fecha);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ingresar datos de la fecha, valores ingresados no validos.");
                    }
                    break;
                default:
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            //funcion_serv.CreateFuncion(new FuncionesRequest());
            Console.ReadKey();
            Console.Clear();
            break;
        case 3:
            opcion = "adios";
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
            break;
        default:
            Console.WriteLine("Opcion ingresada no valida.");
            Console.ReadKey();
            Console.Clear();
            break;

    }
}
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("                         ------------------------");
Console.WriteLine("                         |Gracias por visitarnos| ");
Console.WriteLine("                         ------------------------");
Console.ResetColor();