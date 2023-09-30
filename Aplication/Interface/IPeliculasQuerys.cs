using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IPeliculasQuerys
    {
        public List<Peliculas> GetListPeliculas();
        public Peliculas GetPeliculaById(int id);
        public List<Peliculas> GetPeliculasByIdAndTitulo(int pelId, string titulo);
    }
}
