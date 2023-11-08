using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CreateTicketRequest
    {
        public Guid ticketId { get; set; }
        public CreateFuncionCompletaRequest funcion {  get; set; }
        public string usuario { get; set; }

    }
}
