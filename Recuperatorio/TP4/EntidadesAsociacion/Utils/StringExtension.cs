using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Utils
{
    public static class StringExtension
    {
        public static T ObtenerEnumeradoPorDescripcion<T>(this string descripcion) where T : struct, Enum
        {
            return (T)System.Enum.Parse(typeof(T), descripcion.Replace(" ", string.Empty));
        }
    }
}
