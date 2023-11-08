using Aplication.Interface_Service;
using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Mappers
{
    public interface IPeliculaMapper
    {
        public Task<CreatePeliculaCompletaRequest> createResponse(Peliculas pelicula, Generos genero, IFIltrosService fIltrosService);
    }
}
