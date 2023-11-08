using Aplication.Interface;
using Domain.Entities;
using TrabajoPractico;

namespace Infraestructure.Command
{
    public class TicketsCommand : ITicketsCommand
    {
        private readonly CineDBContext _context;

        public TicketsCommand(CineDBContext context)
        {
            _context = context;
        }

        public async Task InsertTickets(Tickets tic)
        {
            _context.Add(tic);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTickets(Guid ticId)
        {
            var ticket = await _context.Tickets.FindAsync(ticId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }
    }
}
