using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Mappers
{
    public interface IFuncionMapper
    {
        public Task<CreateFuncionCompletaRequest> createResponse(Funciones funcion, Peliculas pelicula, Salas sala, Generos genero);
    }
}
