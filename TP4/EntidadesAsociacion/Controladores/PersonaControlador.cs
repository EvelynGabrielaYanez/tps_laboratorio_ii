using System.Collections.Generic;
using System.Linq;

namespace EntidadesAsociacion.Controladores
{
    public static class PersonaControlador
    {
        /// <summary>
        /// Método de extensión de la lista de tipo T generica que herede o sea del tipo Persona, 
        /// encargado de buscar el listado de usuarios que contengan el dni en la lista.
        /// </summary>
        /// <typeparam name="T">Tipo generico que Herede o sea del tipo Persona</typeparam>
        /// <param name="lista"> lista que se filtrara</param>
        /// <param name="dni">Dni del que se validara la contensión</param>
        /// <returns></returns>
        public static List<T> BuscarDniQueContanga<T>(this List<T> lista, string dni) where T : Persona
        {
            List<T> datosFiltrados = lista.ToList().Where(persona =>
            {
                return persona.Dni.ToString().Contains(dni);
            }).ToList();

            return datosFiltrados;
        }

    }
}
