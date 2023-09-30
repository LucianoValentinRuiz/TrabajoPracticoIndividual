using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Service
{
    public interface IGenerosService
    {
        public  Task<Generos> CreateGenero(Generos gen);
        public void DeleteGenero(int genId);
        public List<Generos> GetAll();
        public Task <Generos> GetById(int genId);
        public void ImprimirNombre(int id);
    }
}
