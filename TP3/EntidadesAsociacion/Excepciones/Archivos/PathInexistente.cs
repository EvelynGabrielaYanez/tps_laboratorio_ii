using System;

namespace EntidadesAsociacion.Excepciones.Archivos
{    
     /// <summary>
     /// Excepción para casos en los que la ruta es inexistente
     /// </summary>
    public class PathInexistente : Exception
    {
        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        public PathInexistente(string mensaje) : base(mensaje)
        {
        }
    }
}
