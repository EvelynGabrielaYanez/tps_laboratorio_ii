using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Empleados;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAsociacion
{
    [TestClass]
    public class TestEmpleado
    {
        /// <summary>
        /// Test encargado de validar el caso correcto de la validación de inicio de sesión.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario del empleado a validar</param>
        /// <param name="contrasenia">Contraseña de los empleados a validar</param>
        [DataRow("empleado1", "contra1234")]
        [TestMethod]
        public void Test_ValidarEIniciarSesion_01(string nombreUsuario, string contrasenia)
        {
            #region Arrange
            Empleado empleadoEsperado = new Empleado("nombreEmpleado1", "apellidoEmpelado1", 39429755, "empleado1", "contra1234");
            #endregion

            #region Act
            Empleado empleadoRetorno = EmpleadoControlador.ValidarSesion(nombreUsuario, contrasenia);
            #endregion

            #region Assert
            Assert.AreEqual(empleadoEsperado.Apellido, empleadoRetorno.Apellido);
            Assert.AreEqual(empleadoEsperado.Nombre, empleadoRetorno.Nombre);
            Assert.AreEqual(empleadoEsperado.Contrasenia, empleadoRetorno.Contrasenia);
            Assert.AreEqual(empleadoEsperado.Dni, empleadoRetorno.Dni);
            Assert.AreEqual(empleadoEsperado.NombreCuenta, empleadoRetorno.NombreCuenta);
            #endregion
        }

        /// <summary>
        /// Test encargado de validar el caso incorrecto de la validacion de inicio de sesión.
        /// Realiza el test con un usuario con nombre de usuario incorrecto y contraseña correcta.
        /// Realiza el test con un usuario con nombre de usuario correcto y contraseña incorrecta.
        /// Realiza el test con un usuario con nombre de usuario incorrecto y contraseña incorrecta.
        /// </summary>
        /// <param name="nombreEmpleado">Nombre del usuario del empleado a validar</param>
        /// <param name="contrasenia">Contraseña de los empleados a validar</param>
        [ExpectedException(typeof(SesionInvalida))]
        [DataRow("empleadoNoRegistrado", "contra1234")]
        [DataRow("empleado1", "contraseniaNoRegistrada")]
        [DataRow("empleadoNoRegistrado", "contraseniaNoRegistrada")]
        [TestMethod]
        public void Test_ValidarEIniciarSesion_02(string nombreEmpleado, string contrasenia)
        {
            #region Arrange
            Empleado empleadoEsperado = new Empleado("nombreEmpleado1", "apellidoEmpelado1", 39429755, "empleado1", "contra1234");
            #endregion

            #region Act
            Empleado empleadoRetorno = EmpleadoControlador.ValidarSesion(nombreEmpleado, contrasenia);
            #endregion

            #region Assert
            Assert.AreEqual(empleadoEsperado, empleadoRetorno);
            #endregion
        }
    }
}
