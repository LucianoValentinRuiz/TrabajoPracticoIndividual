using Aplication.Interface_Imprimir;
using Aplication.Interface_Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Imprimir
{
    public class ImprimirFuncion : IimprimirFuncion
    {
        //public async Task<CreateFuncionResponse> createResponse(Funciones funcion, Peliculas pelicula, Salas sala, Generos genero)
        //{
        //    var result = new CreateFuncionResponse
        //    {
        //        FuncionID = funcion.FuncionesID,
        //        Pelicula = new CreatePeliculaResponse
        //        {
        //            PeliculaId = pelicula.PeliculaID,
        //            Titulo = pelicula.Titulo,
        //            Poster = pelicula.Poster,
        //            Generos = new CreateGeneroResponse
        //            {
        //                GenerosId = genero.GenerosID,
        //                Nombre = genero.Nombre,
        //            }
        //        },
        //        Sala = new CreateSalasResponse
        //        {
        //            SalaId = sala.SalasId,
        //            Nombre = sala.Nombre,
        //            Capacidad = sala.Capacidad
        //        },
        //        Fecha = funcion.Fecha,
        //        Horario = funcion.Horario
        //    };
        //    return result;
        //}
    }
}
