using Aplication.Interface_Mappers;
using Aplication.Interface_Service;
using Aplication.Models;
using Aplication.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class PeliculaMapper : IPeliculaMapper
    {
        public async Task<CreatePeliculaCompletaRequest> createResponse(Peliculas pelicula, Generos genero, IFIltrosService fIltrosService)
        {
            var lista = await fIltrosService.FuncionesFiltro(DateTime.MinValue, pelicula.Titulo,null);
            var funcionLista = new List<CreateFuncionRequest>();
            foreach (Funciones fun in lista)
            {
                var nuevaFuncion = new CreateFuncionRequest
                {
                    funcionId = fun.FuncionId,
                    fecha = fun.Fecha,
                    horario = fun.Horario,
                };
                funcionLista.Add(nuevaFuncion);
            }

            var result = new CreatePeliculaCompletaRequest
            {
                peliculaId = pelicula.PeliculaId,
                titulo = pelicula.Titulo,
                poster = pelicula.Poster,
                trailer = pelicula.Trailer,
                sinopsis = pelicula.Sinopsis,
                genero = new CreateGeneroRequest
                {
                    id = genero.GeneroId,
                    nombre = genero.Nombre,
                },
                funciones = funcionLista,
            };
            return result;
        }
    }
}
