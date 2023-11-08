using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CreateFuncionCompletaRequest
    {
        public int funcionId { get; set; }
        public CreatePeliculaRequest pelicula { get; set; }
        public CreateSalaRequest sala { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horario { get; set; }
    }
}
