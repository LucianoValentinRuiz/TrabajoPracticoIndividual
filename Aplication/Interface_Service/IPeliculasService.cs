
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Service
{
    public interface IPeliculasService
    {
        Task<Peliculas> CreatePeliculas(Peliculas pel_DTO);
        void DeletePeliculas(int pelId);
        List<Peliculas> GetAll();
        Task <Peliculas> GetById(int pelId);

    }
}
