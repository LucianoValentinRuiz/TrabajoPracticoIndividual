using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTO
{
    public class FuncionDTO
    {
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
    }
}
