using Aplication.Interface_Mappers;
using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class TicketMapper : ITicketMapper
    {
        public async Task<CreateTicketRequest> createResponse(Tickets ticket,Funciones funcion, Peliculas pelicula, Salas sala, Generos genero)
        {
            var result = new CreateTicketRequest
            {
                ticketId = ticket.TicketId,
                funcion = new CreateFuncionCompletaRequest
                {
                    funcionId = funcion.FuncionId,
                    pelicula = new CreatePeliculaRequest
                    {
                        peliculaId = pelicula.PeliculaId,
                        titulo = pelicula.Titulo,
                        poster = pelicula.Poster,
                        genero = new CreateGeneroRequest
                        {
                            id = genero.GeneroId,
                            nombre = genero.Nombre,
                        }
                    },
                    sala = new CreateSalaRequest
                    {
                        id = sala.SalaId,
                        nombre = sala.Nombre,
                        capacidad = sala.Capacidad
                    },
                    fecha = funcion.Fecha,
                    horario = funcion.Horario
                },
                usuario = ticket.Usuario
            };
            return result;
        }
    }
}
