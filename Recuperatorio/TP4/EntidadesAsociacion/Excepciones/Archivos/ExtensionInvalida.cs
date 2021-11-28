using System;

namespace EntidadesAsociacion.Excepciones.Archivos
{
    /// <summary>
    /// Excepción para casos en que las extensiones de archivos sean invalidas
    /// </summary>
    public class ExtensionInvalida : Exception
    {
        /// <summary>
        /// Método constructor de la excepcion
        /// </summary>
        /// <param name="mensaje"></param>
        public ExtensionInvalida(string mensaje) : base(mensaje)
        {
        }
    }
}
