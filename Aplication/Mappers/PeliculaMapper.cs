using Aplication.Interface_Mappers;
using Aplication.Interface_Service;
using Aplication.Models;
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
            var lista = await fIltrosService.FuncionesFiltro(null, pelicula.Titulo, pelicula.Genero);
            List<CreateFuncionRequest> funcionesLista = new List<CreateFuncionRequest>();
            foreach (var funcion in lista)
            {
                var createFuncion = new CreateFuncionRequest
                {
                    funcionId = funcion.FuncionId,
                    fecha = funcion.Fecha,
                    horario = funcion.Horario,
                };
                funcionesLista.Add(createFuncion);
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
                funciones = funcionesLista,
            };
            return result;
        }
    }
}
