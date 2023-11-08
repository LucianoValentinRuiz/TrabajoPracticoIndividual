using Aplication.Interface_Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class ValidationTimespan : IValidationTimeSpan
    {
        public TimeSpan IngresarHorario()
        {
            TimeSpan horario;
            Console.WriteLine("Ingresar el horario con el siguiente formato:");
            try
            {
                Console.WriteLine("Ingresar hora (hh) - Rango aceptable desde las 00hs hasta las 23hs:");
                int hora = int.Parse(Console.ReadLine());

                if (hora < 0 || hora >= 24)
                {
                    Console.WriteLine("Error: La hora ingresada está fuera del rango válido.");
                    return TimeSpan.Zero;
                }

                Console.WriteLine("Ingresar minutos (mm) - Rango aceptable desde las 00min hasta los 59min:");
                int min = int.Parse(Console.ReadLine());

                if (min < 0 || min >= 60)
                {
                    Console.WriteLine("Error: Los minutos ingresados están fuera del rango válido.");
                    return TimeSpan.Zero;
                }

                horario = TimeSpan.FromHours(hora).Add(TimeSpan.FromMinutes(min));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Formato de entrada no válido. Ingrese números enteros para la hora y los minutos.");
                return TimeSpan.Zero;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: El valor de hora o minutos ingresado es demasiado grande o demasiado pequeño.");
                return TimeSpan.Zero;
            }
            return horario;
        }
    }
}
