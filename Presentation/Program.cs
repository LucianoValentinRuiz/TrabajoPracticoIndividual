using Aplication.Service;
using Aplication.Interface;
using Aplication.Interface_Service;
using Infraestructure.Command;
using Infrastructure.Querys;
using TrabajoPractico;
using Infraestructure.Querys;
using Infraestructure.Command;
using Domain.Entities;
using Presentation.Imprimir;
using Presentation.Validation;
using Aplication.Models;
using Aplication.Interface_Validation;
using Aplication.Interface_Imprimir;


using (var context = new CineDBContext())
{
    IFuncionesService funcion_serv;
    IPeliculasService pelicula_serv;
    IGenerosService genero_serv;
    ISalasService sala_serv;
    IFIltrosService filtros_serv;
    IimprimirFuncion ImprimirFun = new ImprimirFuncion();
    IimprimirPelicula ImprimirPel = new ImprimirPelicula();
    IValidationInt validarOpcion = new ValidationInt();
    IValidationDatetime validarDatetime = new ValidationDatetime();

    IFuncionesCommand _funcommand = new FuncionesCommand(context);
    IFuncionesQuerys _funquerys = new FuncionesQuerys(context);
    funcion_serv = new FuncionesService(_funcommand, _funquerys);

    IPeliculasCommand _pelcommand = new PeliculasCommand(context);
    IPeliculasQuerys _pelquerys = new PeliculasQuerys(context);
    pelicula_serv = new PeliculasService(_pelcommand, _pelquerys);

    IGenerosCommand _gencommand = new GenerosCommand(context);
    IGenerosQuerys _genquerys = new GenerosQuerys(context);
    genero_serv = new GenerosService(_gencommand, _genquerys);

    ISalasCommand _salcommand = new SalasCommand(context);
    ISalasQuerys _salquerys = new SalasQuerys(context);
    sala_serv = new SalasService(_salcommand, _salquerys);

    IFiltrosQuerys _filquerys = new FiltrosQuerys(context);
    filtros_serv = new FiltrosService(_filquerys);

    bool menu = true;
    while (menu)
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
        Console.WriteLine("1.Mostrar las funciones para un determinado dia y/o titulo de pelicula.");
        Console.WriteLine("2.Registrar una nueva funcion.");
        Console.WriteLine("3.Salir.");
        Console.Write("Ingresar opcion:");
        int opcionMenu = validarOpcion.IngresarInt();
        switch (opcionMenu)
        {
            case 1:
                Console.Clear();
                foreach (Peliculas pel in pelicula_serv.GetAll())
                {
                    ImprimirPel.Imprimir_Peliculas(pelicula_serv, pel.PeliculaId, genero_serv);
                }
                Console.WriteLine("Si no desea buscar funciones con alguna de las opciones, no ingresar ningun dato y solo apretar ENTER");
                Console.Write("1.TITULO:");
                string titulo = Console.ReadLine();
                Console.Write("2.DIA:");
                DateTime dia = validarDatetime.IngresarFecha(Console.ReadLine());
                List<Funciones> lista = await filtros_serv.FuncionesFiltro(dia, titulo,0);
                if (lista.Count != 0)
                {
                    foreach (Funciones fun in lista)
                        Console.WriteLine();
                        //ImprimirFun.Imprimir_Funcion(funcion_serv, fun.FuncionId, pelicula_serv, genero_serv, sala_serv);
                }
                else
                    Console.WriteLine("No se encontraron funciones que concuerden con los datos deseados");
                Console.ReadKey();
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                FuncionesDTOBuilder funcionRquest = new FuncionesDTOBuilder(pelicula_serv, sala_serv, genero_serv);
                funcion_serv.CreateFuncion(funcionRquest.CreateFuncionRequest());
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                menu = false;
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
}