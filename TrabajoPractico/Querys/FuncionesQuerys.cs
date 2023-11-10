using System;
using Domain.Entities;
using Aplication.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Infraestructure.Querys
{
    public class FuncionesQuerys : IFuncionesQuerys
    {
        private readonly CineDBContext _context;
        public FuncionesQuerys(CineDBContext context)
        {
            _context = context;
        }
        public List<Funciones> GetListFunciones() {
            IQueryable<Funciones> query = _context.Funciones;
            var fun = query.ToList();
            if (fun.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron Funciones Existentes");
            }
            return fun;
        }
        public Funciones GetFuncionById(int id) {
            IQueryable<Funciones>query = _context.Funciones;
            var fun = (Funciones)query.FirstOrDefault(x => x.FuncionId == id);
            return fun;
        }
    }
}
