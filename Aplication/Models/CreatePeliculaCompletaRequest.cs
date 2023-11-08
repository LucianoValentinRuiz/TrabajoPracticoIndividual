using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CreatePeliculaCompletaRequest
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public string trailer { get; set; }
        public string sinopsis { get; set; }
        public CreateGeneroRequest genero { get; set; }
        public List<CreateFuncionRequest> funciones { get; set; }
    }
}
