using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class PeliculasRequest
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
    }
}
