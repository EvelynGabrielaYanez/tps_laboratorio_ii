using System.Text;

namespace EntidadesAsociacion
{
    public class Empleado : Persona
    {
        string nombreCuenta;
        string contrasenia;

        /// <summary>
        /// Propiedad de solo lectura del nombre de la cuenta del empelado
        /// </summary>
        public string NombreCuenta
        {
            get { return this.nombreCuenta; }
        }

        /// <summary>
        /// Propiedad de sólo lectura de la contraseña del usuario
        /// </summary>
        public string Contrasenia
        {
            get { return this.contrasenia; }
        }

        /// <summary>
        /// Método constructor del empleado
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellido">Apellido del empleado</param>
        /// <param name="dni">Dni del empleado</param>
        protected Empleado(string nombre, string apellido, int dni) : base(nombre, apellido, dni)
        {
        }
        /// <summary>
        /// Método constructor del empleado
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellido">Apellido del empleado</param>
        /// <param name="dni">Dni del empleado</param>
        /// <param name="nombreCuenta">Nombre de la cuenta del empleado</param>
        /// <param name="contraseña">Contraseña del empleado</param>
        public Empleado(string nombre, string apellido, int dni, string nombreCuenta, string contraseña) : this(nombre, apellido, dni)
        {
            this.nombreCuenta = nombreCuenta;
            this.contrasenia = contraseña;
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// Método encargado de generar una cadena con todas laspropiedadees y valores del empleado.
        /// </summary>
        /// <returns>Cadena con todas las propiedades y valores del empleado</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Nombre de la Cuenta: {this.NombreCuenta}");

            return sb.ToString();
        }
    }
}
