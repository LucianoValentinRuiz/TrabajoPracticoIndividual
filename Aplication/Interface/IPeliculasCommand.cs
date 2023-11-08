using Aplication.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IPeliculasCommand
    {
        public Task InsertPeliculas(Peliculas pel);
        public Task RemovePeliculas(int pelId);
        public Task<Peliculas> UpdatePeliculas(int pelID, PeliculaDTO pel);
    }
}
