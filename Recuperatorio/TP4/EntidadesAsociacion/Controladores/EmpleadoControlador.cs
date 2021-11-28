using EntidadesAsociacion.Excepciones.Empleados;
using EntidadesAsociacion.Excepciones.Genericas;
using System.Collections.Generic;

namespace EntidadesAsociacion.Controladores
{
    public static class EmpleadoControlador
    {
        /// <summary>
        /// Método encargado de validar una sesión (por usuario y contraseña) y en caso de ser
        /// correcta retornar la instancia del empleado correspondiente.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de la cuenta</param>
        /// <param name="contrasenia">Contraseña de la cuenta</param>
        /// <returns>Retorno empleado Validar</returns>
        /// <exception cref="SesionInvalida">El nombre de usuario o la contraseña son invalidos y no se pudo instanciar el empleado</exception>
        public static Empleado ValidarSesion(string nombreUsuario, string contrasenia)
        {
            Empleado retorno = null;
            foreach (Empleado empleado in Asociacion.ListaEmpleados)
            {
                if (empleado.NombreCuenta == nombreUsuario && empleado.Contrasenia == contrasenia)
                {
                    retorno = empleado;
                    break;
                }
            }
            if (retorno is null)
            {
                throw new SesionInvalida("El usuario o la contraseña son invalidos");
            }

            return retorno;
        }

        /// <summary>
        /// Método encargado de obtener un usuario del tipo T que sea de la clase Empleado o herede de la misma
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Empleado ObtenerUnUsuarioDelTipo<T>() where T : Empleado
        {
            List<T> auxLista;

            auxLista = Asociacion.ListaEmpleados.FiltrarPorTipoEmpleado<T,Empleado>();

            if (auxLista.Count == 0)
            {
                throw new NoEncontrado($"No se encontro ningún empleado del tipo {typeof(T)}");
            }

            return auxLista[0];
        }

        /// <summary>
        /// Método de extension encargado de filtrar una lista que sea o herede del tipo persona los empleados por el tipo T que sea de la clase Empleado o herede de la misma.
        /// </summary>
        /// <typeparam name="T">Tipo T generico que hereda o es del tipo empleado por el que se filtrara</typeparam>
        /// <typeparam name="U">Tipo de dato de la lista a filtrar</typeparam>
        /// <param name="lista">Lista que se extendera con el metodo</param>
        /// <returns>Lista del tipo T generico filtrada</returns>
        public static List<T> FiltrarPorTipoEmpleado<T, U>(this List<U> lista) where T : Empleado
                                                                              where U : Persona
        {
            List<T> datosFiltrados = new List<T>();

            foreach (Persona persona in lista)
            {
                if (typeof(T) == persona.GetType())
                {
                    datosFiltrados.Add((T)persona);
                }
            }

            return datosFiltrados;
        }
    }
}
