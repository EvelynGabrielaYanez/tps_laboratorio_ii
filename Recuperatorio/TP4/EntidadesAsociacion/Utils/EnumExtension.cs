using System;
using System.ComponentModel;
using System.Reflection;

namespace EntidadesAsociacion.Utils
{
    public static class EnumExtension
    {
        /// <summary>
        /// Método encargado de obtener la descripcion de un enumerado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerado"></param>
        /// <returns></returns>
        public static string ObtenerDescripcion<T>(this T enumerado) where T : struct, Enum
        {
            Type type = enumerado.GetType();

            // Busca el atributo de descripcion
            MemberInfo[] informacionDelMiembro = type.GetMember(enumerado.ToString());
            if (informacionDelMiembro != null && informacionDelMiembro.Length > 0)
            {
                object[] atributos = informacionDelMiembro[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (atributos != null && atributos.Length > 0)
                {
                    return ((DescriptionAttribute)atributos[0]).Description;
                }
            }
            // Si no tiene un atributo descripcion entonces retorna el enumerado convertido a string.
            return enumerado.ToString();
        }
    }
}
