using Aplication.Interface;
using Domain.Entities;
using TrabajoPractico;

namespace Infraestructure.Command
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
        }

        public async Task RemoveGeneros(int genId)
        {
            var gen = await _context.Generos.FindAsync(genId);
            if (gen != null)
            {
                _context.Generos.Remove(gen);
                _context.SaveChanges();
            }
        }
    }
}
