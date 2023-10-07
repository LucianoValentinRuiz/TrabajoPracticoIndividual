// See https://aka.ms/new-console-template for more information
using Aplication.Service;
using Aplication.Interface;
using Aplication.Interface_Service;
using Infrastructure;
using Infraestructure.Command;
using Infrastructure.Querys;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TrabajoPractico;
using Aplication.Querys;
using Aplication.Command;
using Domain.Entities;
using Presentation.Imprimir;
using Aplication.DTO;
using Aplication.Models;

IFuncionesService funcion_serv;
IPeliculasService pelicula_serv;
IGenerosService genero_serv;
ISalasService sala_serv;
IFIltrosService filtros_serv;

using (var context = new CineDBContext())
{
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
            Console.Write("1.TITULO");
            string titulo = Console.ReadLine();
            Console.Write("2.HORARIO");
            string dia = Console.ReadLine();
            try
            {
                List<Funciones> lista = await filtros_serv.ListaFunciones(titulo, dia);
                if (lista != null)
                {
                    ImprimirFuncion Imprimir = new ImprimirFuncion();
                    foreach (Funciones fun in lista)
                    {
                        Imprimir.Imprimir_Funcion(funcion_serv, fun.FuncionId, pelicula_serv, genero_serv, sala_serv);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Dato ingresado no valido");
            }

            Console.ReadKey();
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            FuncionesRequest funcionRquest = new FuncionesRequest(pelicula_serv,sala_serv,genero_serv);
            funcion_serv.CreateFuncion(funcionRquest.CreateFuncionRequest());
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