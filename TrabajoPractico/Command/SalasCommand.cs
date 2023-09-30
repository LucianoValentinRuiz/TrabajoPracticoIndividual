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
            Console.WriteLine("Sala insertada correctamente");
        }

        public async Task RemoveSalas(int salId)
        {
            var sala = await _context.Salas.FindAsync(salId);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                _context.SaveChanges();
                Console.WriteLine("Sala eliminada correctamente");
            }
            else { Console.WriteLine("No se encontro ninguna Sala con el Id especificado para eliminar"); }
        }
    }
}
