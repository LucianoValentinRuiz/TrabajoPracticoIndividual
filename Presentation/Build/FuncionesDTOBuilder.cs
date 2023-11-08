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
using Aplication.Interface_Validation;
using Presentation.Validation;

namespace Aplication.Models
{
    public class FuncionesDTOBuilder
    {
        private readonly IPeliculasService _pelServ;
        private readonly ISalasService _salServ;
        private readonly IGenerosService _genServ;

        public FuncionesDTOBuilder(IPeliculasService pelServ, ISalasService salServ, IGenerosService genServ)
        {
            _pelServ = pelServ;
            _salServ = salServ;
            _genServ = genServ;
        }

        public FuncionDTO CreateFuncionRequest()
        {
            FuncionDTO funcion = new FuncionDTO();
            Console.WriteLine("- - - - - - - - - - - - - - - - - ");

            int id_pelicula = this.IngresarIDPelicula();
            if (id_pelicula == 0 || id_pelicula > _pelServ.GetAll().Count || id_pelicula < 0)
            {
                Console.WriteLine("Error al ingresar ID de peliculas.");
                return null;
            }
            funcion.PeliculaId = id_pelicula;

            int id_salas = this.IngresarIDSalas();
            if (id_salas == 0 || id_salas > _salServ.GetAll().Count || id_salas < 0)
            {
                Console.WriteLine("Error al ingresar ID de salas.");
                return null;
            }
            funcion.SalaId = id_salas;

            IValidationDatetime validationDate = new ValidationDatetime();
            DateTime fecha = validationDate.IngresarFecha(Console.ReadLine());
            if (fecha == DateTime.MinValue)
            {
                Console.WriteLine("Error al ingresar la fecha.");
                return null;
            }
            funcion.Fecha = fecha;

            IValidationTimeSpan validationTime = new ValidationTimespan();
            TimeSpan horario = validationTime.IngresarHorario();
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
            ImprimirPelicula impr_peli = new ImprimirPelicula();
            Console.WriteLine("Ingresar el Id de una de las siguientes peliculas:");
            foreach (Peliculas pelis in _pelServ.GetAll())
            {
                impr_peli.Imprimir_Peliculas(_pelServ, pelis.PeliculaId, _genServ);
            }
            IValidationInt validationInt = new ValidationInt();
            return validationInt.IngresarInt();
        }
        protected int IngresarIDSalas()
        {
            ImprimirSala impr_sala = new ImprimirSala();
            Console.WriteLine("Ingresar el Id de una de las siguientes salas:");
            foreach (var sala in _salServ.GetAll())
            {
                impr_sala.Imprimir_Sala(_salServ, sala.SalaId);
            }
            IValidationInt validationInt = new ValidationInt();
            return validationInt.IngresarInt();
        }

    }
}
