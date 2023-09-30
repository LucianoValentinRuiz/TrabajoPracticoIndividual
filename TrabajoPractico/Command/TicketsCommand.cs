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
            Console.WriteLine("Ticket insertado correctamente");
        }

        public async Task RemoveTickets(Guid ticId)
        {
            var ticket = await _context.Tickets.FindAsync(ticId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
                Console.WriteLine("Ticket eliminado correctamente");
            }
            else { Console.WriteLine("No se encontro ningun Ticket con el Id especificado para eliminar"); }
        }
    }
}
