using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Validation
{
    public interface IValidationHorario
    {
        public TimeSpan validarHorario(string horario);
    }
}
