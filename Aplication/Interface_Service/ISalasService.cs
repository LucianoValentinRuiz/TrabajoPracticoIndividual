using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Service
{
    public interface ISalasService
    {
        public Task<Salas> CreateSalas(Salas sal);
        public void DeleteGenero(int salId);
        public List<Salas> GetAll();
        public Task <Salas> GetById(int salId);
    }
}
