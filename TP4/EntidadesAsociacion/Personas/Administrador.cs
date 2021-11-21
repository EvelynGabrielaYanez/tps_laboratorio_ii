namespace EntidadesAsociacion
{
    public class Administrador : Empleado
    {
        /// <summary>
        /// Método constructor de la clase administrador
        /// </summary>
        /// <param name="nombre">Nombre del administrador</param>
        /// <param name="apellido">Apellido del administrador</param>
        /// <param name="dni">Dni del administrador</param>
        /// <param name="nombreCuenta">Nombre de la cuenta del administrador</param>
        /// <param name="contraseña">Contraseña del administrador</param>
        public Administrador(string nombre, string apellido, int dni, string nombreCuenta, string contraseña) : base(nombre, apellido, dni, nombreCuenta, contraseña)
        {
        }
    }
}
