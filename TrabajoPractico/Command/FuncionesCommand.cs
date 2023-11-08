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
        public async Task<Funciones> InsertFuncion(Funciones fun)
        {
            _context.Add(fun);
            _context.SaveChanges();
            return fun;
        }
        public async Task<Funciones> RemoveFuncion(int funId)
        {
            var funcion = await _context.Funciones.FindAsync(funId);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                _context.SaveChanges();
                return funcion;
            }
            else return null;
        }
    }
}
