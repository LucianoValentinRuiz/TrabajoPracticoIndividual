using Domain.Entities;
using Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interface_Mappers;

namespace Aplication.Mappers
{
    public class FuncionMapper : IFuncionMapper
    {
        public async Task<CreateFuncionCompletaRequest> createResponse(Funciones funcion, Peliculas pelicula, Salas sala, Generos genero)
        {
            var result = new CreateFuncionCompletaRequest
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
            };
            return result;
        }
    }
}
