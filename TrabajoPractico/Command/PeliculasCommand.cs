﻿using Aplication.DTO;
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
            var peli = _context.Peliculas.Where(x => x.Titulo == pel.Titulo).FirstOrDefault();
            if (peli == null)
            {
                var pelicula = await _context.Peliculas.FindAsync(pelID);
                if (pel.Titulo != null || pel.Titulo != "string")
                    pelicula.Titulo = pel.Titulo;
                if ( pel.Poster != "string")
                    pelicula.Poster = pel.Poster;
                if ( pel.Trailer != "string")
                    pelicula.Trailer = pel.Trailer;
                if ( pel.Sinopsis != "string")
                    pelicula.Sinopsis = pel.Sinopsis;
                if ( pel.Genero != 0)
                    pelicula.Genero = pel.Genero;
                _context.Peliculas.Update(pelicula);
                await _context.SaveChangesAsync();
                return pelicula;
            }
            else
                return null;
        }
    }
}
