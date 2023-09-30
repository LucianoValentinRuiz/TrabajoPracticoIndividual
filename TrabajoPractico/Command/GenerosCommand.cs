using System;
using Aplication.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using TrabajoPractico;

namespace Aplication.Command
{
    public class GenerosCommand : IGenerosCommand
    {
        private readonly CineDBContext _context;

        public GenerosCommand(CineDBContext context)
        {
            _context = context;
        }
        public async Task InsertGeneros(Generos gen)
        {
            _context.Add(gen);
            await _context.SaveChangesAsync();
            Console.WriteLine("Genero insertado correctamente");
        }

        public async Task RemoveGeneros(int genId)
        {
            var gen = await _context.Generos.FindAsync(genId);
            if (gen != null)
            {
                _context.Generos.Remove(gen);
                _context.SaveChanges();
                Console.WriteLine("Genero eliminado correctamente");
            }
            else { Console.WriteLine("No se encontro ningun Genero con el Id especificado para eliminar"); }

        }
    }
}
