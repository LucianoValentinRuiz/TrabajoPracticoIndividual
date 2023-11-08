using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Mappers
{
    public interface ITicketMapper
    {
        public Task<CreateTicketRequest> createResponse(Tickets ticket, Funciones funcion, Peliculas pelicula, Salas sala, Generos genero);
    }
}
