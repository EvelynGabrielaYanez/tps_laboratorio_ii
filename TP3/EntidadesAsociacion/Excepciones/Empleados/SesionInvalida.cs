using System;

namespace EntidadesAsociacion.Excepciones.Empleados
{
    /// <summary>
    /// Excepción utilizada cuando la sesion ingresada sea invalida (por usuario o contraseña)
    /// </summary>
    public class SesionInvalida : Exception
    {
        /// <summary>
        /// Método constrcutro de la excepcion
        /// </summary>
        public SesionInvalida(string mensaje) : base(mensaje)
        {
        }
    }
}
