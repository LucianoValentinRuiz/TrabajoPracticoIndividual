using Domain.Entities;
using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Infraestructure.Command
{
    public class FuncionesCommand: IFuncionesCommand
    {
        private readonly CineDBContext _context;

        public FuncionesCommand(CineDBContext context)
        {
            _context = context;
        }
        public async Task InsertFuncion(Funciones fun)
        {
            _context.Add(fun);
            _context.SaveChanges();
        }
        public async Task RemoveFuncion(int funId)
        {
            var funcion = await _context.Funciones.FindAsync(funId);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
                Console.WriteLine("Funcion eliminada correctamente");
            }
            else { Console.WriteLine("No se encontro ninguna Funcion con el Id especificado para eliminar"); }
        }
    }
}
