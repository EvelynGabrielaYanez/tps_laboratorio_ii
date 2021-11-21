using System;

namespace EntidadesAsociacion.Excepciones.Genericas
{
    /// <summary>
    /// Excepción utilizada para indicar que el valor ingresado en un campo de un formulario es invalido
    /// </summary>
    public class CampoInvalido : Exception
    {
        /// <summary>
        /// Nombre del campo del formulario que posee el error
        /// </summary>
        string nombreCampo;

        /// <summary>
        /// Método constructor de la excepción
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="nombreCampo">Campo del formulario que posee el error</param>
        public CampoInvalido(string mensaje, string nombreCampo) : base(mensaje)
        {
            this.nombreCampo = nombreCampo;
        }

        /// <summary>
        /// Propiedad de solo lectura con del nombre del campo del formulario que posee el error
        /// </summary>
        public string NombreCampo
        {
            get { return this.nombreCampo; }
        }
    }
}
