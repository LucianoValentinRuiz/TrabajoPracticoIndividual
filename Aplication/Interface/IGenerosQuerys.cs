using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IGenerosQuerys
    {
        public List<Generos> GetListGeneros();
        public Generos GetGenerosById(int id);
    }
}
