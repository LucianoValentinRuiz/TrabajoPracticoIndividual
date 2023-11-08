using Aplication.Interface;
using Domain.Entities;
using TrabajoPractico;

namespace Infraestructure.Command
{
    public class SalasCommand : ISalasCommand
    {
        private readonly CineDBContext _context;

        public SalasCommand(CineDBContext context)
        {
            _context = context;
        }

        public async Task InsertSalas(Salas sal)
        {
            _context.Add(sal);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSalas(int salId)
        {
            var sala = await _context.Salas.FindAsync(salId);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                _context.SaveChanges();
            }
        }
    }
}
