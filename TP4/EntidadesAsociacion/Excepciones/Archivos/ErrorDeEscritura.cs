using System;

namespace EntidadesAsociacion.Excepciones.Archivos
{
    /// <summary>
    /// Excepción para los errores de escritura y serialización de archivos
    /// </summary>
    public class ErrorDeEscritura : Exception
    {
        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensaje">Mensaje que retorna la excepcion</param>
        /// <param name="excepcion">Expecion interna</param>
        public ErrorDeEscritura(string mensaje, Exception excepcion) : base(mensaje, excepcion)
        {

        }
    }
}
