using System;

namespace EntidadesAsociacion.Excepciones.Usuarios
{
    /// <summary>
    /// Excepcion utilizada cuando el usuario no fue encontrado en una peticion de busqueda y debiar serlo
    /// </summary>
    public class UsuarioNoEncontrado : Exception
    {
        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensage">Mensaje de error</param>
        public UsuarioNoEncontrado(string mensaje) : base(mensaje)
        {
        }
    }
}
