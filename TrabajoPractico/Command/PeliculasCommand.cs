using Aplication.DTO;
using Aplication.Interface;
using Domain.Entities;
using TrabajoPractico;

namespace Infraestructure.Command
{
    public class PeliculasCommand : IPeliculasCommand
    {
        private readonly CineDBContext _context;

        public PeliculasCommand(CineDBContext context)
        {
            _context = context;
        }
        public async Task InsertPeliculas(Peliculas pel)
        {
            _context.Add(pel);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePeliculas(int pelId)
        {
            var peli = await _context.Peliculas.FindAsync(pelId);
            if (peli != null)
            {
                _context.Peliculas.Remove(peli);
                _context.SaveChanges();
            }
        }
        public async Task<Peliculas> UpdatePeliculas(int pelID, PeliculaDTO pel)
        {
            var pelicula = await _context.Peliculas.FindAsync(pelID);
            if (pelicula != null)
            {
                pelicula.Titulo = pel.Titulo;
                pelicula.Poster = pel.Poster;
                pelicula.Trailer = pel.Trailer;
                pelicula.Sinopsis = pel.Sinopsis;
                pelicula.Genero = pel.Genero;
                _context.Peliculas.Update(pelicula);
                await _context.SaveChangesAsync();
                return pelicula;
            }
            else 
            { 
                return null; 
            }
        }
    }
}
