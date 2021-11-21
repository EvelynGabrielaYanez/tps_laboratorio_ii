using System.Collections.Generic;
using System.Text;

namespace EntidadesAsociacion.Utils
{
    public static class ListExtension
    {
        /// <summary>
        /// Método ecargado de mostrar en un string los items de una lista
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la lista</typeparam>
        /// <param name="lista">Lista que se va a convertir en string</param>
        /// <returns>cadena de texto correspondiente a cada elemento de la lista convertido a string</returns>
        public static string Mostar<T>(this List<T> lista)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
