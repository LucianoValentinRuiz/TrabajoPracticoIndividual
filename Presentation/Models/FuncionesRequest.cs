using Aplication.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class FuncionesRequest
    {
        public int FuncionesId { get; set; }
        public int PeliculaID { get; set; }
        public int SalaID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }

        //public FuncionesRequest() {
        //    Console.WriteLine("- - - - - - - - - - - - - - - - - ");
        //    PeliculasService serv1 = new PeliculasService();
        //    SalasService serv2 = new SalasService();
        //    //Ingresa Id Peliculas
        //    int id_pelicula = this.IngresarIDPelicula();
        //    if ( id_pelicula == 0 || id_pelicula > serv1.GetAll().Count || id_pelicula < 0)
        //    {
        //        Console.WriteLine("Error al ingresar ID de peliculas.");
        //        return;
        //    }
        //    this.PeliculaID = id_pelicula;
        //    //Ingresa Id Salas
        //    int id_salas = this.IngresarIDSalas();
        //    if ( id_salas == 0 || id_salas > serv2.GetAll().Count || id_salas < 0)
        //    {
        //        Console.WriteLine("Error al ingresar ID de salas.");
        //        return;
        //    }
        //    this.SalaID = id_salas;
        //    //Ingresar Fecha
        //    DateTime fecha = this.IngresarFecha();
        //    if (fecha == DateTime.MinValue)
        //    {
        //        Console.WriteLine("Error al ingresar la fecha.");
        //        return;
        //     }
        //    this.Fecha = fecha;
        //    //Ingresar Horario
        //    TimeSpan horario = this.IngresarHorario();
        //    if(horario == (TimeSpan.Zero)){
        //        Console.WriteLine("Error al ingresar el horario.");
        //        return;
        //    }
        //    this.Horario = horario;
        //}
        //protected int IngresarIDPelicula()
        //{
        //    PeliculasService serv1 = new PeliculasService();
        //    int op1;
        //    Console.WriteLine("Ingresar el Id de una de las siguientes peliculas:");
        //    foreach (Peliculas pelis in serv1.GetAll())
        //    {
        //        serv1.ImprimirPeliculas(pelis.PeliculaId);
        //    }
        //    try
        //    {
        //        op1 = int.Parse(Console.ReadLine());
        //        return op1;
        //    }
        //    catch (Exception ex) 
        //    { 
        //        Console.WriteLine("Error al elegir el ID. Dato insertado no valido");
        //        return 0;
        //    }
        //}
        //protected int IngresarIDSalas()
        //{
        //    SalasService serv2 = new SalasService();
        //    int op2;
        //    Console.WriteLine("Ingresar el Id de una de las siguientes salas:");
        //    foreach (var sala in serv2.GetAll())
        //    {
        //        serv2.ImprimirNombre(sala.SalasId);
        //    }
        //    try
        //    {
        //        op2 = int.Parse(Console.ReadLine());
        //        return op2;
        //    }
        //    catch (Exception ex) 
        //    { 
        //        Console.WriteLine("Error al elegir el ID. Dato insertado no valido");
        //        return 0;
        //    }
        //}
        //protected DateTime IngresarFecha()
        //{
        //    DateTime actual = DateTime.Today;
        //    DateTime zero = DateTime.MinValue;
        //    DateTime fecha;
        //    Console.WriteLine("Ingresar la fecha con el siguiente formato:");
        //    try
        //    {
        //        Console.WriteLine("Ingresar dia (dd):");
        //        int dia = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Ingresar mes (MM):");
        //        int mes = int.Parse(Console.ReadLine());
        //        return fecha = new DateTime(actual.Year,mes,dia);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al ingresar datos de la fecha, valores ingresados no validos.");
        //        return zero;
        //    }
        //}
        //protected TimeSpan IngresarHorario()
        //{
        //    TimeSpan horario;
        //    Console.WriteLine("Ingresar el horario con el siguiente formato:");
        //    try
        //    {
        //        Console.WriteLine("Ingresar hora (hh) - Rango aceptable desde las 00hs hasta las 23hs:");
        //        int hora = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Ingresar minutos (mm) - Rango aceptable desde las 00min hasta los 59min:");
        //        int min = int.Parse(Console.ReadLine());
        //        if (hora >= 00 && hora < 24 && min >= 00 && min < 60)
        //        {
        //            horario = TimeSpan.FromHours(hora).Add(TimeSpan.FromMinutes(min));
        //        }
        //        else
        //        {
        //            Console.WriteLine("Rango de horario ingresado no valido.");
        //            return TimeSpan.Zero;
        //        }
        //    }
        //    catch(Exception ex) {
        //        Console.WriteLine("Error al ingresar datos del horario, valores ingresados no validos");
        //        return TimeSpan.Zero;
        //    }
        //    return horario;
        //}

    }
}
