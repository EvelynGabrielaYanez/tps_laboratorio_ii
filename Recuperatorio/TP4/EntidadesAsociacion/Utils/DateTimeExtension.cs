using System;
using System.Globalization;

namespace EntidadesAsociacion.Utils
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Método encargado de calcular la cantidad de meses transcurridos hasta la fehca actual
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static int CalcularMesesHastaLaActualidad(this DateTime fecha)
        {
            DateTime fechaActual = DateTime.Now;
            return ((fechaActual.Year - fecha.Year) * 12) + fechaActual.Month - fecha.Month;
        }

        /// <summary>
        /// Método encargado de validar si un dia corresponde a una fecha.
        /// Por ejemplo: si el 20/11/2021 es Sábado
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="diaIngresado"></param>
        /// <returns></returns>
        public static bool ValidarSiFechaYDia(this DateTime fecha, string diaIngresado)
        {
            string diaDeLaFecha = fecha.ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES"));
            return diaDeLaFecha.ToLower().Equals(diaIngresado.ToLower());
        }
    }
}
