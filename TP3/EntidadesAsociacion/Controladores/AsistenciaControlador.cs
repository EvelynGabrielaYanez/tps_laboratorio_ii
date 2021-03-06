using EntidadesAsociacion.Excepciones.Usuarios;
using EntidadesAsociacion.Reportes;
using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Controladores
{
    public static class AsistenciaControlador
    {
        /// <summary>
        /// Método encargado de agregar una nueva asistencia.
        /// Validando antes de agregarla que la misma no este cargada en el registro de asistencias.
        /// Se cosndierara que una asistencia esta cargada cuando esta sea para el mismo usuario y la misma fecha
        /// En caso de no estar registardo en el listado de usuarios el usuario de la asistencia esta no se agregara
        /// </summary>
        /// <param name="nuevoRegistro">Asistencia a cargar</param>
        /// <returns>true = agregada con éxito | false = no se pudo agregar</returns>
        public static bool AgregarAsistencia(Asistencia nuevoRegistro)
        {
            bool retorno = true;
            try
            {
                // Valida si el usuario esta registrado en la aplicacion, caso contrario no se agregara
                UsuarioControlador.BuscarUsuario(nuevoRegistro.Usuario.Dni);
                // Valido si el usuario ya esta en la lista y si no esta lo agrego
                foreach (Asistencia registro in Asociacion.ListadoAsistencias)
                {
                    if (nuevoRegistro == registro)
                    {
                        retorno = false;
                        break;
                    }
                }
                if (retorno)
                {
                    Asociacion.ListadoAsistencias.Add(nuevoRegistro);
                }
            }
            catch (UsuarioNoEncontrado)
            {
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Método encargado de editar una asistencia.
        /// Este buscara por usuario y fecha de asistencia correspondiente a la pasada por parametro y
        /// editara unciamente el estado de presencialidad.
        /// </summary>
        /// <param name="registroDatosEditado">Asistencia a modificar con el nuevo estado de presencialidad</param>
        /// <returns>true = modificada con exito | false = asistencia no encontrada</returns>

        public static bool EditarAsistencia(Asistencia registroDatosEditado)
        {
            foreach (Asistencia registro in Asociacion.ListadoAsistencias)
            {
                if (registro == registroDatosEditado)
                {
                    registro.Presente = registroDatosEditado.Presente;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Método encargado de filtrar las asistencias por fecha de asistencia (desde y hasta) y por grupo de asistencia.
        /// </summary>
        /// <param name="fechaDesde">Fecha de asistencia desde</param>
        /// <param name="fecgaHasta">Fecha de asistencia hasta</param>
        /// <param name="grupo">Tipo de grupo al que se asiste</param>
        /// <returns>Lista de asistencias filtrada.</returns>
        public static List<Asistencia> FiltrarAsistencias(DateTime fechaDesde, DateTime fecgaHasta, EGrupo grupo)
        {
            List<Asistencia> retornoAsistencias = new List<Asistencia>();
            foreach (Asistencia registro in Asociacion.ListadoAsistencias)
            {
                if (registro.Fecha.Date >= fechaDesde.Date && registro.Fecha.Date <= fecgaHasta.Date && grupo == registro.Grupo)
                {
                    retornoAsistencias.Add(registro);
                }
            }
            return retornoAsistencias;
        }

        /// <summary>
        /// Método encargado de filtrar el listado de asistencias de la asociacion por grupo.
        /// </summary>
        /// <param name="grupo">Grupo por el que se filtrara</param>
        /// <returns>Listado de asistencias filtrado</returns>
        public static List<Asistencia> FiltrarPorGrupo(EGrupo grupo)
        {
            List<Asistencia> retornoAsistencias = new List<Asistencia>();
            foreach (Asistencia registro in Asociacion.ListadoAsistencias)
            {
                if (grupo == registro.Grupo)
                {
                    retornoAsistencias.Add(registro);
                }
            }
            return retornoAsistencias;
        }

        /// <summary>
        /// Método encargado de agregar un listado de asistencias a el listado de asistencias de la asociacion.
        /// En caso de existir alguna asistencia en el listado que se encuentre cargada perviamente en el listado de 
        /// la asociacion esta sera ignorada y se mantendra la cargada anteriormente.
        /// </summary>
        /// <param name="listadoDeAsistencias">Listado de asistencias a agregar</param>
        public static void AgregarListadoDeAsistencias(List<Asistencia> listadoDeAsistencias)
        {
            foreach (Asistencia asistencia in listadoDeAsistencias)
            {
                AsistenciaControlador.AgregarAsistencia(asistencia);
            }
        }

        /// <summary>
        /// Método encargado de filtrar por tipo de presencialidad y grupo un listado de asistencias
        /// </summary>
        /// <param name="tipoDeAsistencia">Tipo de asistencia(presencialidad)</param>
        /// <param name="grupo">Tipo de grupo</param>
        /// <param name="listadoAsistencias">Listado de asistencias a filtrar</param>
        /// <returns>Listado de asistencias filtrado</returns>
        private static List<Asistencia> FiltrarPorTipoPresencialidad(ETipoAsistencia tipoDeAsistencia, EGrupo grupo, List<Asistencia> listadoAsistencias)
        {
            List<Asistencia> listadoRetorno = new List<Asistencia>();
            foreach (Asistencia asistencia in listadoAsistencias)
            {
                if (asistencia.Presente == tipoDeAsistencia && asistencia.Grupo == grupo)
                {
                    listadoRetorno.Add(asistencia);
                }
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de usuarios por tipo de asistencias en un grupo.
        /// </summary>
        /// <param name="grupo">Grupo en el que se calculara</param>
        /// <returns>Listado de resigstros de porcentajes</returns>
        public static List<RegistroPorcentaje> CalcularPorcentaPorTipoAsistencia(EGrupo grupo)
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            int cantidadUsuariosPorGrupo = CalcularAsistenciasPorGrupo(grupo);
            if (cantidadUsuariosPorGrupo == 0)
            {
                cantidadUsuariosPorGrupo = 1;
            }
            foreach (ETipoAsistencia tipoDeAsistencia in Enum.GetValues(typeof(ETipoAsistencia)))
            {
                int CantidadPorCausa = AsistenciaControlador.FiltrarPorTipoPresencialidad(tipoDeAsistencia, grupo, Asociacion.ListadoAsistencias).Count;
                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje(CantidadPorCausa, (double)(CantidadPorCausa * 100) / cantidadUsuariosPorGrupo, $"{grupo}-{tipoDeAsistencia}");
                listadoRetorno.Add(nuevoRegistro);
            }

            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular la cantidad de asistencias (total sin diferenciar por tipo de presencialidad) en un grupo.
        /// </summary>
        /// <param name="grupo">Tipo de grupo para el que se contara</param>
        /// <returns>Cantidad de asistencias</returns>
        private static int CalcularAsistenciasPorGrupo(EGrupo grupo)
        {
            int cantidad = 0;
            foreach (Asistencia asistencia in Asociacion.ListadoAsistencias)
            {
                if (asistencia.Grupo == grupo)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

    }
}
