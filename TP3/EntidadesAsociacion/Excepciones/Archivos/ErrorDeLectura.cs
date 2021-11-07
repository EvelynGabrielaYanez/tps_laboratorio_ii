using System;

namespace EntidadesAsociacion.Excepciones.Archivos
{
    /// <summary>
    /// Excepción para los errores de lectura y deserialización de archivos
    /// </summary>
    public class ErrorDeLectura : Exception
    {
        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensaje">Mensaje que retorna la excepcion</param>
        /// <param name="excepcion">Expecion interna</param>
        public ErrorDeLectura(string mensaje, Exception error) : base(mensaje, error)
        {
        }
    }
}
