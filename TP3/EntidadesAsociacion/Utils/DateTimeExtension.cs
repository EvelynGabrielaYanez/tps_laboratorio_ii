using System;
using System.Globalization;

namespace EntidadesAsociacion.Utils
{
    public static class DateTimeExtension
    {
        public static int CalcularMesesHastaLaActualidad(this DateTime fecha)
        {
            DateTime fechaActual = DateTime.Now;
            return ((fechaActual.Year - fecha.Year) * 12) + fechaActual.Month - fecha.Month;
        }

        public static bool ValidarSiFechaYDia(this DateTime fecha, string diaIngresado)
        {
            string diaDeLaFecha = fecha.ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES"));
            return diaDeLaFecha.ToLower().Equals(diaIngresado.ToLower());
        }
    }
}
