using Aplication.Interface_Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validation
{
    public class ValidationTimeSpan : IValidationHorario
    {
        public TimeSpan validarHorario (string horario)
        {
            try
            {
                if (TimeSpan.TryParseExact(horario, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan horarioNuevo))
                {
                    return horarioNuevo;
                }
                else
                    return TimeSpan.Zero;
            }
            catch { return TimeSpan.Zero; }
        }
    }
}
