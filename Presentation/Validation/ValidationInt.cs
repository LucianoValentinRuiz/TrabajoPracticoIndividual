using Aplication.Interface_Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class ValidationInt : IValidationInt
    {
        public int IngresarInt() 
        {
            Console.WriteLine("Ingresar dato numerico valido:");
            try
            {
                int dato = int.Parse(Console.ReadLine());
                return dato;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Formato de entrada no válido. Ingrese un número entero válido.");
                return this.IngresarInt();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: El número ingresado es demasiado grande o demasiado pequeño para ser representado como un número entero.");
                return this.IngresarInt();
            }
        }
    }
}
