using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IFuncionesQuerys
    {
        public List<Funciones> GetListFunciones() ;
        public Funciones GetFuncionById(int id) ;
    }
}
