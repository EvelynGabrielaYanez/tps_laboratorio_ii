using EntidadesAsociacion.DB_Controladores;
using EntidadesAsociacion.Excepciones.Usuarios;
using EntidadesAsociacion.Reportes;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Controladores
{
    public static class UsuarioControlador
    {
        /// <summary>
        /// Método encargado de agregar un usuario el listado de usuarios de la asociación
        /// </summary>
        /// <param name="nuevoUsuario">Usuario a agregar</param>
        /// <returns>true = usuario agregado con éxito | false = el usuario no fue agregado, ya estaba en la lista</returns>
        public static bool AgregarUsuario(Usuario nuevoUsuario)
        {
            int cantidadInsertada = 0;
            // Valido si el usuario ya esta en la lista y si no esta lo agrego
            List<Usuario> listadoUsuario = UsuarioControlador.Filtrar(dni: nuevoUsuario.Dni);

            if (listadoUsuario.Count == 0)
            {
                cantidadInsertada = UsuarioDB.Insertar(nuevoUsuario);
            }
            return cantidadInsertada > 0;
        }

        /// <summary>
        /// Método encargado de buscar los usurios de un grupo que no tienen registro de asistencia para la fecha especificada
        /// </summary>
        /// <param name="grupo">Grupo al que peretenecen los usuarios</param>
        /// <param name="fecha">Fecha de asistencia por la que se buscan los registros</param>
        /// <returns>Listado de usuarios sin registro de asistencia</returns>
        public static List<Usuario> BuscarUsuariosSinAsistencia(EGrupo grupo, DateTime fecha)
        {
            return UsuarioDB.BuscarUsuariosSinAsistencia(grupo,fecha);
        }

        /// <summary>
        /// Método encargado de filtrar por fecha el listado de usuarios de pasado por parametro. (Se filtra por intervalos que contengan a los extremos)
        /// </summary>
        /// <param name="fechaDesde">Fecha de ingreso desde</param>
        /// <param name="fechaHasta">Fecha de ingreso hasta</param>
        /// <param name="listadoaFiltrar">Listado de Usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarPorFecha(DateTime fechaDesde, DateTime fechaHasta, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (fechaDesde <= fechaHasta)
            {
                listadoRetorno = listadoaFiltrar.FindAll(usuario => usuario.FechaIngreso.Date >= fechaDesde.Date && usuario.FechaIngreso.Date <= fechaHasta.Date);
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar el listado de usuarios.
        /// Todos los parametros son opcionales.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="grupo"></param>
        /// <param name="cantidadDenunciasDesde"></param>
        /// <param name="cantidadDenunciasHasta"></param>
        /// <returns></returns>
        public static List<Usuario> Filtrar(int? dni = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, EGrupo? grupo = null, int? cantidadDenunciasDesde = null, int? cantidadDenunciasHasta = null)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (fechaDesde is null || fechaHasta is null || fechaDesde <= fechaHasta)
            {
                listadoRetorno = UsuarioDB.Filtrar(dni, fechaDesde, fechaHasta, grupo, cantidadDenunciasDesde, cantidadDenunciasHasta);
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar por cantidad de denuncias el listado de usuarios pasado por parametro (Se filtra por intervalos que contengan a los extremos)
        /// </summary>
        /// <param name="denunciasMinimo">Cantidad de denuncias mínimo</param>
        /// <param name="denunciasMaximo">Cantidad de denuncias máximo</param>
        /// <param name="listadoaFiltrar">Listado de usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarCantidadDenuncias(int denunciasMinimo, int denunciasMaximo, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (denunciasMinimo >= 0 && denunciasMinimo <= denunciasMaximo)
            {
                listadoRetorno = listadoaFiltrar.FindAll(usuario => usuario.DenunciasRegistradas >= denunciasMinimo && usuario.DenunciasRegistradas <= denunciasMaximo);
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar por causas de ingreso el listado de usuarios pasado por parametro.
        /// El método retornara aquellos usarios que contengan todas las caisas de ingreso ingresadas en el listado de causas.
        /// </summary>
        /// <param name="filtroCausaDeIngreso">Listado de causas de ingreso</param>
        /// <param name="listadoaFiltrar">Listado de usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarCausaDeIngreso(List<ETipoCausaIngreso> filtroCausaDeIngreso, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (filtroCausaDeIngreso is not null && filtroCausaDeIngreso.Count > 0)
            {
                listadoRetorno = listadoaFiltrar.FindAll(usuario => usuario.ValidarLasCausaDeIngreso(filtroCausaDeIngreso));
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de denuncias por intervalos considerando como intervalo de analisis
        /// el pasado por parametros. 
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada intervalo.
        /// </summary>
        /// <param name="intevaloDenuncias">Intervalo de cantodad de denuncias</param>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajePorDenuncias(int intevaloDenuncias)
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            if (intevaloDenuncias <= 0)
            {
                return listadoRetorno;
            }

            List<Usuario> listadoUsuarios = UsuarioControlador.Filtrar();
            int cantidadDeUsuarios = listadoUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            int totalRegistrosCalculados = 0;
            for (int i = 1; totalRegistrosCalculados < cantidadDeUsuarios; i++)
            {
                int intervaloDedese = (i - 1) * intevaloDenuncias;
                int intervaloHasta = i * intevaloDenuncias - 1;

                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje($"{intervaloDedese} a {intervaloHasta}");
                foreach (Usuario registro in listadoUsuarios)
                {
                    if (registro.DenunciasRegistradas >= intervaloDedese && registro.DenunciasRegistradas <= intervaloHasta)
                    {
                        nuevoRegistro.Cantidad++;
                        totalRegistrosCalculados++;
                    }
                }
                nuevoRegistro.Porcentaje = (double)(100 * nuevoRegistro.Cantidad) / cantidadDeUsuarios;
                listadoRetorno.Add(nuevoRegistro);
            }

            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de meses transcurridos en la asociacion por intervalos considerando 
        /// como intervalo de analisis el pasado por parametros. 
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada intervalo.
        /// </summary>
        /// <param name="intevaloDenuncias">Intervalo de cantodad de meses que el usuario lleva en la asociacion</param>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajesPorMeses(int inteveloMeses)
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            if (inteveloMeses <= 0)
            {
                return listadoRetorno;
            }

            List<Usuario> listadoUsuarios = UsuarioControlador.Filtrar();
            int cantidadDeUsuarios = listadoUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            int totalRegistrosCalculados = 0;
            for (int i = 1; totalRegistrosCalculados < cantidadDeUsuarios; i++)
            {
                int intervaloDedese = (i - 1) * inteveloMeses;
                int intervaloHasta = i * inteveloMeses - 1;

                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje($"{intervaloDedese} a {intervaloHasta}");
                foreach (Usuario registro in listadoUsuarios)
                {
                    int mesesTranscurridosDesdeIngreso = registro.FechaIngreso.CalcularMesesHastaLaActualidad();
                    if (mesesTranscurridosDesdeIngreso >= intervaloDedese && mesesTranscurridosDesdeIngreso <= intervaloHasta)
                    {
                        nuevoRegistro.Cantidad++;
                        totalRegistrosCalculados++;
                    }
                }
                nuevoRegistro.Porcentaje = (double)(100 * nuevoRegistro.Cantidad) / cantidadDeUsuarios;
                listadoRetorno.Add(nuevoRegistro);
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de usuarios por causa de ingreso.
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada causa de ingreso.
        /// Observacion: el porcentaje total podra no ser 100% dado que un usuario puede tener mas de una causa de ingreso
        /// </summary>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajesPorCausaIngreso()
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            List<Usuario> listadoUsuarios = UsuarioControlador.Filtrar();
            int cantidadDeUsuarios = listadoUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            foreach (ETipoCausaIngreso causaDeIngreso in Enum.GetValues(typeof(ETipoCausaIngreso)))
            {
                int CantidadPorCausa = UsuarioControlador.FiltrarCausaDeIngreso(new List<ETipoCausaIngreso>() { causaDeIngreso }, listadoUsuarios).Count;
                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje(CantidadPorCausa, (double)(CantidadPorCausa * 100) / cantidadDeUsuarios, causaDeIngreso.ToString());
                listadoRetorno.Add(nuevoRegistro);
            }

            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de buscar y retornar un listado con los Dni de los usuarios de la asociacion.
        /// </summary>
        /// <returns>Listado de dni</returns>
        public static List<int> BuscarListadoDni()
        {
            List<int> listaRetorno = new List<int>();
            List<Usuario> listadoUsuarios = UsuarioDB.Filtrar();
            foreach (Usuario usuario in listadoUsuarios)
            {
                listaRetorno.Add(usuario.Dni);
            }
            return listaRetorno;
        }

        /// <summary>
        /// Método encargado de buscar un usuario por número de dni
        /// </summary>
        /// <param name="dni">Número de dni a buscar</param>
        /// <returns>Instancia del usuario buscado</returns>
        /// <exception cref="UsuarioNoEncontrado">Excepción arrojada cuando no se encuentre ningún usuario con el dni pasado por parametro.</exception>
        public static Usuario BuscarUsuario(int dni)
        {
            List<Usuario> retornoFiltro = UsuarioDB.Filtrar(dni:dni);
            if (retornoFiltro.Count > 0)
            {
                return retornoFiltro[0];
            }
            else
            {
                throw new UsuarioNoEncontrado($"No se encontro ningun usuario con DNI: {dni}");
            }
        }

        public static int Eliminar(int dni)
        {
            return UsuarioDB.Eliminar(dni);
        }
    }
}
