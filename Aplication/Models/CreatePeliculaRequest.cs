using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CreatePeliculaRequest
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public CreateGeneroRequest genero { get; set; }
    }
}
