using Aplication.DTO;
using Aplication.Service;
using Domain.Entities;
using System;
using Aplication.Interface_Service;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Imprimir;

namespace Aplication.Models
{
    public class FuncionesRequest
    {
        private readonly IPeliculasService _serv1;
        private readonly ISalasService _serv2;
        private readonly IGenerosService _serv3;
        public FuncionesRequest(IPeliculasService serv1, ISalasService serv2, IGenerosService serv3)
        {
            _serv1 = serv1;
            _serv2 = serv2;
            _serv3 = serv3;
        }

        public FuncionDTO CreateFuncionRequest()
        {
            FuncionDTO funcion = new FuncionDTO();
            Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            //Ingresa Id Peliculas
            int id_pelicula = this.IngresarIDPelicula();
            if (id_pelicula == 0 || id_pelicula > _serv1.GetAll().Count || id_pelicula < 0)
            {
                Console.WriteLine("Error al ingresar ID de peliculas.");
                return null;
            }
            funcion.PeliculaId = id_pelicula;
            //Ingresa Id Salas
            int id_salas = this.IngresarIDSalas();
            if (id_salas == 0 || id_salas > _serv2.GetAll().Count || id_salas < 0)
            {
                Console.WriteLine("Error al ingresar ID de salas.");
                return null;
            }
            funcion.SalaId = id_salas;
            //Ingresar Fecha
            DateTime fecha = this.IngresarFecha();
            if (fecha == DateTime.MinValue)
            {
                Console.WriteLine("Error al ingresar la fecha.");
                return null;
            }
            funcion.Fecha = fecha;
            //Ingresar Horario
            TimeSpan horario = this.IngresarHorario();
            if (horario == (TimeSpan.Zero))
            {
                Console.WriteLine("Error al ingresar el horario.");
                return null;
            }
            funcion.Horario = horario;
            return funcion;
        }
        protected int IngresarIDPelicula()
        {
            int op1;
            ImprimirPelicula impr_peli = new ImprimirPelicula();
            Console.WriteLine("Ingresar el Id de una de las siguientes peliculas:");
            foreach (Peliculas pelis in _serv1.GetAll())
            {
                impr_peli.Imprimir_Peliculas(_serv1,pelis.PeliculaId,_serv3);
            }
            try
            {
                op1 = int.Parse(Console.ReadLine());
                return op1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al elegir el ID. Dato insertado no valido");
                return 0;
            }
        }
        protected int IngresarIDSalas()
        {
            int op2;
            ImprimirSala impr_sala = new ImprimirSala();
            Console.WriteLine("Ingresar el Id de una de las siguientes salas:");
            foreach (var sala in _serv2.GetAll())
            {
                impr_sala.Imprimir_Sala(_serv2,sala.SalaId);
            }
            try
            {
                op2 = int.Parse(Console.ReadLine());
                return op2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al elegir el ID. Dato insertado no valido");
                return 0;
            }
        }
        protected DateTime IngresarFecha()
        {
            DateTime actual = DateTime.Today;
            DateTime zero = DateTime.MinValue;
            DateTime fecha;
            Console.WriteLine("Ingresar la fecha con el siguiente formato:");
            try
            {
                Console.WriteLine("Ingresar dia (dd):");
                int dia = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresar mes (MM):");
                int mes = int.Parse(Console.ReadLine());
                return fecha = new DateTime(actual.Year, mes, dia);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ingresar datos de la fecha, valores ingresados no validos.");
                return zero;
            }
        }
        protected TimeSpan IngresarHorario()
        {
            TimeSpan horario;
            Console.WriteLine("Ingresar el horario con el siguiente formato:");
            try
            {
                Console.WriteLine("Ingresar hora (hh) - Rango aceptable desde las 00hs hasta las 23hs:");
                int hora = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresar minutos (mm) - Rango aceptable desde las 00min hasta los 59min:");
                int min = int.Parse(Console.ReadLine());
                if (hora >= 00 && hora < 24 && min >= 00 && min < 60)
                {
                    horario = TimeSpan.FromHours(hora).Add(TimeSpan.FromMinutes(min));
                }
                else
                {
                    Console.WriteLine("Rango de horario ingresado no valido.");
                    return TimeSpan.Zero;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ingresar datos del horario, valores ingresados no validos");
                return TimeSpan.Zero;
            }
            return horario;
        }

    }
}
