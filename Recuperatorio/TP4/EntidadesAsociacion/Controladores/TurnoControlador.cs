using EntidadesAsociacion.DB_Controladores;
using EntidadesAsociacion.Excepciones.Genericas;
using System;
namespace EntidadesAsociacion.Controladores
{
    public static class TurnoControlador
    {
        /// <summary>
        /// Método encargado de insertar un turno.
        /// Si el turno ya se encontraba insertado entonces retorna -1.
        /// Si este no se encontraba insertado lo inserta y retorna la cantidad de turnos que inserto con éxito
        /// </summary>
        /// <param name="turno">Turno a insertar</param>
        /// <returns>Cantida de turnos insertados</returns>
        public static int Insertar(Turno turno)
        {
            if (TurnoControlador.Buscar(turno.Fecha) is not null)
                return -1;

            return TurnoDB.Insertar(turno);
        }

        /// <summary>
        /// Método encargado de actualizar el estado (abierto/cerrado) de un turno
        /// </summary>
        /// <param name="turno">Turno a actualizar con el nuevo estado</param>
        /// <returns>Cantidad de turnos modificados</returns>
        public static int Actualizar(Turno turno)
        {
            return TurnoDB.Actualizar(turno);
        }

        /// <summary>
        /// Método encargado de buscar un turno para una fecha.
        /// En caso de no encontrarlo arrojar ana expecion
        /// </summary>
        /// <param name="fecha">Fecha correspondiente al turno buscado</param>
        /// <returns>Instancia del turno encontrado</returns>
        /// <exception cref="NoEncontrado">Excepción arrojada en caso de no encontrar nigún turno para la fecha</exception>
        public static Turno Buscar(DateTime fecha)
        {
            return TurnoDB.Buscar(fecha);
        }

        /// <summary>
        /// Método encargado de buscar el turno que se encuentra abierto
        /// </summary>
        /// <returns>Instancia del turno que se encunetra abierto</returns>
        public static Turno BuscarTurnoAbierto()
        {
            return TurnoDB.BuscarTurnoAbierto();
        }

        /// <summary>
        /// Método encargado de buscar el último turno que se cerro
        /// </summary>
        /// <returns>Instancia del último turno que se cerro</returns>
        public static Turno BuscarUltimoTurnoCerrado()
        {
            return TurnoDB.BuscarUltimoTurnoCerrado();
        }

    }
}
