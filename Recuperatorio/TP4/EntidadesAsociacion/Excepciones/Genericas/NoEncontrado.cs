using System;

namespace EntidadesAsociacion.Excepciones.Genericas
{
    /// <summary>
    /// Excepción utilizada para indicar que una petición que debia obtener resultado no pudo encontrar ninguno
    /// </summary>
    public class NoEncontrado : Exception
    {
        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensage">Mensaje de error</param>
        public NoEncontrado(string mensage) : base(mensage)
        {
        }
    }
}
