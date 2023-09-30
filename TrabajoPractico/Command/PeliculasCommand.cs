using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Aplication.Command
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
            Console.WriteLine("Pelicula insertada correctamente");
        }

        public async Task RemovePeliculas(int pelId)
        {
            var peli = await _context.Peliculas.FindAsync(pelId);
            if (peli != null)
            {
                _context.Peliculas.Remove(peli);
                _context.SaveChanges();
                Console.WriteLine("Pelicula eliminada correctamente");
            }
            else { Console.WriteLine("No se encontro ninguna Pelicula con el Id especificado para eliminar"); }
        }
    }
}
