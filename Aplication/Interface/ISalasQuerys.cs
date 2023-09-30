using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ISalasQuerys
    {
        public List<Salas> GetListSalas();
        public Salas GetSalasById(int id);
    }
}
